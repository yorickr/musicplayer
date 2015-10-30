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

        public int Buffered { get { return Math.Min((int)((bufpos / (double)LengthBuffer) * 1000), 1000); } }
        private long LengthBuffer { get; set; }
        private long bufpos = 0;


        public int Position { get { return Math.Min((int)((playpos / (double)Length) * 1000), 1000); } }
        private long Length { get; set; }
        private long playpos = 0;


        public int CurrentTime { get; set; }

        public int TotalTime { get { return CurrentSong != null ? CurrentSong.Seconds : 0; } }

        private long seek = 0;

        private Stream ms;

        private Thread network;
        private Thread audio;

        public Song CurrentSong;

        public AudioHandler()
        {
            CreateThreads();
        }

        private void CreateThreads()
        {
            AState = AudioState.STOPPED;
            BState = BufferState.EMPTY;

            CurrentSong = null;

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
            CurrentTime = 0;
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

            seek = Length / 1000 * position;
            AState = AudioState.SEEKING;
            
        }

        public void Stop()
        {
            CreateThreads();
        }

        public void Pause()
        {
            if(CurrentSong == null)
                AState = AudioState.STOPPED;
            else
                AState = AudioState.PAUSED;
        }

        private void StreamFromMP3(Stream s, long pos, bool firstrun)
        {
            long position = 0;
            ms.Position = position;
            Mp3FileReader mp3fr = null;

            try
            {
                mp3fr = new Mp3FileReader(ms);
            }
            catch(Exception e)
            {
                AState = AudioState.STOPPED;
                return;
            }
            
            
            using (WaveStream blockAlignedStream = new BlockAlignReductionStream(WaveFormatConversionStream.CreatePcmStream(mp3fr)))
            {
                blockAlignedStream.Position = pos;
                using (WaveOut waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
                {
                    waveOut.Init(blockAlignedStream);
                    waveOut.Play();

                    Length = CurrentSong.Seconds * waveOut.OutputWaveFormat.AverageBytesPerSecond;
                    CurrentTime = (int)(ms.Position / waveOut.OutputWaveFormat.AverageBytesPerSecond);

                    while (waveOut.PlaybackState != PlaybackState.Stopped)
                    {
                        System.Threading.Thread.Sleep(10);

                        if (AState == AudioState.PLAYING && waveOut.PlaybackState == PlaybackState.Paused)
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
                            blockAlignedStream.Seek(seek - (seek % blockAlignedStream.WaveFormat.BlockAlign), SeekOrigin.Begin);
                            AState = AudioState.PLAYING;
                            waveOut.Play();
                        }
                        if (AState == AudioState.STOPPED)
                        {
                            waveOut.Stop();
                        }
                        if (BState == BufferState.DONE && firstrun )
                        {
                            position = mp3fr.Position;
                            mp3fr.Close();
                            StreamFromMP3(ms,position, false);
                            break;
                        }

                        playpos = blockAlignedStream.Position;
                        CurrentTime = (int)(playpos / waveOut.OutputWaveFormat.AverageBytesPerSecond);

                    }

                    AState = AudioState.STOPPED;
                    playpos = 0;
                    CurrentTime = 0;
                }
            }
        }

        private void PlayAudio()
        {
            AState = AudioState.WAITING;
            while (ms.Length < 65536 * 10 && BState != BufferState.DONE)
                Thread.Sleep(1000);
            AState = AudioState.PLAYING;

            StreamFromMP3(ms,0, true);
            
        }

        private void LoadAudio(object o)
        {
            Song s = (Song) o;
            WebResponse response = null;

            try
            {
                response = WebRequest.Create(s.Url).GetResponse();
            }
            catch(Exception e)
            {
                BState = BufferState.EMPTY;
                AState = AudioState.STOPPED;
                return;
            }


            BState = BufferState.EMPTY;
            LengthBuffer = response.ContentLength;
            using (var stream = response.GetResponseStream())
            {
                //byte[] buffer = new byte[65536]; // 64KB chunks
                byte[] buffer = new byte[65536*4]; // 256KB chunks
                int read;
                BState = BufferState.BUFFERING;
                AState = AudioState.WAITING;

                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0 && AState != AudioState.STOPPED)
                {
                    var pos = ms.Position;
                    ms.Position = ms.Length;
                    ms.Write(buffer, 0, read);
                    ms.Position = pos;


                    this.bufpos = ms.Length;
                }
            }

            BState = BufferState.DONE;
        }

    }
}
