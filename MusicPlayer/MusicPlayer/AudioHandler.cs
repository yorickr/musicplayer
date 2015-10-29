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
        public enum AudioState { PLAYING, STOPPED, PAUSED }
        public AudioState State { get; set; }

        private Stream ms;

        private Thread network;
        private Thread audio;

        private Song CurrentSong;

        public AudioHandler()
        {
            ms = new MemoryStream();
            network = new Thread(LoadAudio);
            audio = new Thread(PlayAudio);
            network.IsBackground = true;
            audio.IsBackground = true;
            State = AudioState.STOPPED;
        }

        public void Play(Song s)
        {
            if (CurrentSong == s)
                State = AudioState.PLAYING;
            else
            {
                State = AudioState.STOPPED;

                network = new Thread(LoadAudio);
                audio = new Thread(PlayAudio);

                CurrentSong = s;
                network.Start(s);
                audio.Start();
            }
        }

        public void Stop()
        {
            State = AudioState.STOPPED;
        }

        public void Pause()
        {
            State = AudioState.PAUSED;
        }

        private void PlayAudio()
        {
            while (ms.Length < 65536 * 10)
                Thread.Sleep(1000);

            ms.Position = 0;
            using (WaveStream blockAlignedStream = new BlockAlignReductionStream(WaveFormatConversionStream.CreatePcmStream(new Mp3FileReader(ms))))
            {
                using (WaveOut waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
                {
                    waveOut.Init(blockAlignedStream);
                    waveOut.Play();
                    while (waveOut.PlaybackState != PlaybackState.Stopped)
                    {
                        System.Threading.Thread.Sleep(100);
                        if(State == AudioState.PAUSED && waveOut.PlaybackState == PlaybackState.Playing)
                        {
                            waveOut.Pause();
                        }
                        if (State == AudioState.PLAYING && waveOut.PlaybackState == PlaybackState.Paused)
                        {
                            waveOut.Play();
                        }
                        if (State == AudioState.STOPPED)
                        {
                            waveOut.Stop();
                        }
                    }
                    State = AudioState.STOPPED;
                }
            }
        }

        private void LoadAudio(object o)
        {
            Song s = (Song) o;
            var response = WebRequest.Create(s.Url).GetResponse();
            State = AudioState.PLAYING;
            using (var stream = response.GetResponseStream())
            {
                byte[] buffer = new byte[65536]; // 64KB chunks
                int read;
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    var pos = ms.Position;
                    ms.Position = ms.Length;
                    ms.Write(buffer, 0, read);
                    ms.Position = pos;
                    if(State == AudioState.STOPPED)
                    {
                        stream.Close();
                        return;
                    }
                }
            }
        }

    }
}
