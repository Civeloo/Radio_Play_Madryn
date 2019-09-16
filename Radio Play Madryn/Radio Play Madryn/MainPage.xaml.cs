using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Essentials;

namespace Radio_Play_Madryn
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private StreamingViewModel ViewModel { get { return (StreamingViewModel)this.BindingContext; } }

        public MainPage()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            BindingContext = new StreamingViewModel();
        }

        // Callbacks to images tapped
        private void Play_tapped(object sender, EventArgs e)
        {
            ViewModel.Play();
        }

        private void Pause_tapped(object sender, EventArgs e)
        {
            ViewModel.Pause();
        }

        private void Stop_tapped(object sender, EventArgs e)
        {
            ViewModel.Stop();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private void Open_web_tapped(object sender, EventArgs e)
        {         
            Uri uri = new Uri("http://"+lbBrowse.Text);
            Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }

    }
}