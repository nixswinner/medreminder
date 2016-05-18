using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.Phone.Speech.Synthesis;

namespace DawaReminder
{
    public partial class about : PhoneApplicationPage
    {
        public about()
        {
            InitializeComponent();
        }

        private async void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            SpeechSynthesizer tell = new SpeechSynthesizer();
            await tell.SpeakTextAsync("Welcome to about page");
        }
    }
}