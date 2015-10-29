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
        public enum AudioState { PLAYING, WAITING, STOPPED, PAUSED }
        public enum BufferState { EMPTY, BUFFERING, DONE }
        public AudioState AState { get; set; }
        public BufferState BState { get; set; }

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

            ms = new MemoryStream();

            network = new Thread(LoadAudio);
            audio = new Thread(PlayAudio);

            network.IsBackground = true;
            audio.IsBackground = true;

            
        }

        public void Play(Song s)
        {
            if (CurrentSong == s)
                AState = AudioState.PLAYING;
            else
            {
                Stop();

                CurrentSong = s;
                network.Start(s);
                audio.Start();
            }
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
            using (WaveStream blockAlignedStream = new BlockAlignReductionStream(WaveFormatConversionStream.CreatePcmStream(new Mp3FileReader(ms))))
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
                            ms.Position = position;
                            waveOut.Play();
                        }
                        if (AState == AudioState.PAUSED && waveOut.PlaybackState == PlaybackState.Playing)
                        {
                            position = ms.Position;
                            waveOut.Pause();
                        }
                        if(AState == AudioState.STOPPED)
                        {
                            waveOut.Stop();
                        }
                    }

                    AState = AudioState.STOPPED;
                }
            }
        }

        private void LoadAudio(object o)
        {
            Song s = (Song) o;
            var response = WebRequest.Create(s.Url).GetResponse();

            BState = BufferState.EMPTY;

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
                }
            }

            BState = BufferState.DONE;
        }

    }
}
