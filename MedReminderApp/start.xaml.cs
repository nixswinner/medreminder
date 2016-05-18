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
using Coding4Fun.Toolkit.Controls;

namespace DawaReminder
{
    public partial class start : PhoneApplicationPage
    {
        public start()
        {
            InitializeComponent();
        }

        private void Ellipse_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/NewReminderPage.xaml", UriKind.Relative));
        }

        private void viewmedreminders_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            // NavigationService.Navigate(new Uri("/help.xaml", UriKind.Relative));

            AboutPrompt help = new AboutPrompt();
            help.Title = "App Guide";
            help.Footer = "Developed by Nixon";
            help.VersionNumber = "Version 1.0.0.1";
            help.Body = new TextBlock
            {
                Text = "Please go to add new reminder on launching application or add new on list of reminders this to create a new medicine reminder\n\t\tHow To Add New Med Reminder\nEnter the name of Medicine,enter the prescribed dosage such as 1X3 then manually count the number of tablets then enter the number.\nYou will then be getting Reminders when to take your medicine.\n\tManaging you MedReminders.\n To delete a Medreminder\nOn list of reminders window touch on reminder to remove then remove reminder button\n\tInterpreting reminders list\nOn the list of reminders;the first is the reminder content .The first date shows the begin time of medication and the second date and time is the shows the end of medication period.\nThank You Wishing You a Quick Recovery. ",
                TextWrapping = TextWrapping.Wrap
            };
            help.Show();
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {


            AboutPrompt about = new AboutPrompt();
            about.Title = "About";
            about.Footer = "Developed by Nixon";
            about.VersionNumber = "Version 1.0.0.1";
            about.Body = new TextBlock
            {
                Text = "MedReminder is an application that ensures that you never miss your medicine during the medication your period for your quick recovery",
                TextWrapping = TextWrapping.Wrap
            };
            about.Show();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            //SpeechSynthesizer tell = new SpeechSynthesizer();
            //await tell.SpeakTextAsync("Welcome to MedReminder");
        }
    }
}