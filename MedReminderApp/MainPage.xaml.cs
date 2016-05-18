using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Scheduler;

namespace DawaReminder
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }


        private void RefreshReminderList()
        {

            IEnumerable<Reminder> reminders = ScheduledActionService.GetActions<Reminder>();
            this.lbReminders.ItemsSource = reminders;

        }

        private void btnAddNewReminder_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/NewReminderPage.xaml", UriKind.Relative));
        }


        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            this.RefreshReminderList();
        }

        private void lbReminders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        /*  private void txtremove_Tap(object sender, System.Windows.Input.GestureEventArgs e)
          {
              Reminder selectedReminder = this.lbReminders.SelectedItem as Reminder;
              if (selectedReminder != null)
              {
                  ScheduledActionService.Remove(selectedReminder.Name);
                  this.RefreshReminderList();
              }
          }
          */
        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {

            Reminder selectedReminder = this.lbReminders.SelectedItem as Reminder;
            if (selectedReminder != null)
            {
                ScheduledActionService.Remove(selectedReminder.Name);
                this.RefreshReminderList();
            }
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}