using Radio_Play_Madryn.Droid;
using Xamarin.Forms;
using Android.Media;

[assembly: Dependency(typeof(StreamingService))]
namespace Radio_Play_Madryn.Droid
{
    public class StreamingService : IStreaming
    {
        MediaPlayer player;
        string dataSource = "http://200.58.106.247:8120/stream";

        bool IsPrepared = false;

        public void Play()
        {
            if (!IsPrepared)
            {
                if (player == null)
                    player = new MediaPlayer();
                else
                    player.Reset();

                player.SetDataSource(dataSource);
                player.PrepareAsync();
            }

            player.Prepared += (sender, args) =>
            {
                player.Start();
                IsPrepared = true;
            };
        }

        public void Pause()
        {
            player.Pause();
            IsPrepared = false;
        }

        public void Stop()
        {
            player.Stop();
            IsPrepared = false;
        }
    }
}