using Radio_Play_Madryn.iOS;
using Xamarin.Forms;
using AVFoundation;
using Foundation;

[assembly: Dependency(typeof(StreamingService))]

namespace Radio_Play_Madryn.iOS
{
    public class StreamingService : IStreaming
    {
        AVPlayer player;
        bool isPrepared;
        string dataSource = "http://200.58.106.247:8120/stream";

        public void Play()
        {
            AVAudioSession.SharedInstance().SetCategory(AVAudioSessionCategory.Playback);
            if (!isPrepared || player == null)
                player = AVPlayer.FromUrl(NSUrl.FromString(dataSource));

            isPrepared = true;
            player.Play();
        }

        public void Pause()
        {
            player.Pause();
        }

        public void Stop()
        {
            player.Dispose();
            isPrepared = false;
        }
    }

}