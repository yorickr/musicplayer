using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public class AudioHandler
    {
        public enum AudioState { PLAYING, WAITING, STOPPED, PAUSED, SEEKING }
        public enum BufferState { EMPTY, BUFFERING, DONE }
        public AudioState AState { get; set; }
        public BufferState BState { get; set; }

        public int Buffered { get { return Math.Min((int)((bufpos / (double)LengthBuffer) * 100), 100); } }
        public int Position { get { return Math.Min((int)((playpos / (double)Length) * 100), 100); } }
        public string CurrentTime { get; set; }
        public string TotalTime { get; set; }
        private long LengthBuffer { get; set; }
        private long Length { get; set; }
        private long bufpos = 0;
        private long playpos = 0;
        private long seek = 0;

        private Stream ms;

        private Thread network;
        private Thread audio;

        private Song CurrentSong;

        public AudioHandler()
        {
            CreateThreads();
        }

        private void CreateThreads()
        {
            AState = AudioState.STOPPED;
            BState = BufferState.EMPTY;

            Thread.Sleep(11);

            ms = new MemoryStream();

            network = new Thread(LoadAudio);
            audio = new Thread(PlayAudio);

            network.IsBackground = true;
            audio.IsBackground = true;

            Length = 1;
            LengthBuffer = 1;
            bufpos = 0;
            playpos = 0;
        }

        public void Play(Song s)
        {
            if (CurrentSong == s && AState == AudioState.PAUSED)
                AState = AudioState.PLAYING;
            else
            {
                Stop();

                CurrentSong = s;
                network.Start(s);
                audio.Start();
            }
        }

        public void Seek(int position)
        {
            if (position >= Buffered-1)
                return;

            seek = Length / 100 * position;
            AState = AudioState.SEEKING;
            
        }

        public void Stop()
        {
            CreateThreads();
        }

        public void Pause()
        {
            AState = AudioState.PAUSED;
        }

        private void PlayAudio()
        {
            AState = AudioState.WAITING;
            while (ms.Length < 65536 * 10 && BState != BufferState.DONE)
                Thread.Sleep(1000);
            AState = AudioState.PLAYING;

            long position = 0;

            ms.Position = position;
            Mp3FileReader mp3fr = new Mp3FileReader(ms);
            Length = mp3fr.Length;
            CurrentTime = mp3fr.CurrentTime + "";
            TotalTime = mp3fr.TotalTime + "";
            using (WaveStream blockAlignedStream = new BlockAlignReductionStream(WaveFormatConversionStream.CreatePcmStream(mp3fr)))
            {

                using (WaveOut waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
                {
                    waveOut.Init(blockAlignedStream);
                    waveOut.Play();

                    while (waveOut.PlaybackState != PlaybackState.Stopped)
                    {
                        System.Threading.Thread.Sleep(10);

                        if(AState == AudioState.PLAYING && waveOut.PlaybackState == PlaybackState.Paused)
                        {
                            blockAlignedStream.Position = position;
                            waveOut.Play();
                        }
                        if (AState == AudioState.PAUSED && waveOut.PlaybackState == PlaybackState.Playing)
                        {
                            position = blockAlignedStream.Position;
                            waveOut.Pause();
                        }
                        if (AState == AudioState.SEEKING)
                        {
                            blockAlignedStream.Position = seek - (seek % blockAlignedStream.WaveFormat.BlockAlign);
                            AState = AudioState.PLAYING;
                            waveOut.Play();
                        }
                        if (AState == AudioState.STOPPED)
                        {
                            waveOut.Stop();
                        }

                        playpos = blockAlignedStream.Position;
                        Length = mp3fr.Length;
                        CurrentTime = mp3fr.CurrentTime + "";
                        TotalTime = mp3fr.TotalTime + "";
                    }

                    AState = AudioState.STOPPED;
                    playpos = 0;
                }
            }
        }

        private void LoadAudio(object o)
        {
            Song s = (Song) o;
            var response = WebRequest.Create(s.Url).GetResponse();

            BState = BufferState.EMPTY;
            LengthBuffer = response.ContentLength;
            using (var stream = response.GetResponseStream())
            {
                byte[] buffer = new byte[65536]; // 64KB chunks
                int read;
                BState = BufferState.BUFFERING;
                AState = AudioState.WAITING;

                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0 && AState != AudioState.STOPPED)
                {
                    var pos = ms.Position;
                    ms.Position = ms.Length;
                    ms.Write(buffer, 0, read);
                    ms.Position = pos;


                    this.bufpos += buffer.Length;
                }
            }

            BState = BufferState.DONE;
        }

    }
}
