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
    public partial class NewReminderPage : PhoneApplicationPage
    {

        public NewReminderPage()
        {
            InitializeComponent();
        }





        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            //checking if all inputs are entered by the user
            if (txta.Text == "" || txtb.Text == "" || txtName.Text == "" || txtX.Text == "")
            {
                MessageBox.Show("Make Sure You Provided all the information that is:\n Name\n Dosage \n The Number");
            }
            else
            {

                //variables used to calculate timings



                int a = int.Parse(txta.Text);
                int b = int.Parse(txtb.Text);
                int x = int.Parse(txtX.Text);
                //T=Time intervals
                int T = 24 / b;


                //finding out exact exipiry time
                int E = x / (a * b);
                int Z = x % b;
                DateTime date = DateTime.Now.AddDays(E);
                DateTime time = DateTime.Now.AddHours(Z * T);
                DateTime exipiryTime = date + time.TimeOfDay;
                DateTime rootTime = DateTime.Now;


                //begin time

                DateTime beginTime = DateTime.Now.AddHours(T);

                if (a * b < x)
                {



                    //use GUID to creat unique reminder
                    string reminderName = Guid.NewGuid().ToString();


                    //building reminder
                    Reminder reminder = new Reminder(reminderName);
                    reminder.Title = txtName.Text + " Reminder";
                    reminder.Content = "Your are suppose to take " + txtName.Text + " . ";
                    reminder.BeginTime = beginTime;
                    reminder.ExpirationTime = exipiryTime;
                    reminder.RecurrenceType = RecurrenceInterval.Daily;

                    //display to the user the timing of medication


                    TimingTxt.Text = "Hi You will receive reminder of " + txtName.Text + " every time when you medication time is due from " + beginTime +
                        " until " + exipiryTime + " When your medication period will end " + "\n" + " Quick recovery!";
                    //TimingTxt.Text = "The folowing are timings you will taking your Medicine until " + exipiryTime + "just familaries yourself but you will always be reminded" + "\r\n" + nextTime;


                    Drawer.Visibility = Visibility.Visible;



                    //add reminder to the schedule actions
                    ScheduledActionService.Add(reminder);

                    if (rootTime == exipiryTime)
                    {
                        ScheduledActionService.Remove("reminder");

                    }
                    //this.NavigationService.GoBack();
                    // NavigationService.Navigate(new Uri("/Mainpage.xaml?", UriKind.Relative));

                }
                else
                {
                    MessageBox.Show("Impossible Dosage!!\n Please re-enter your dosage correctly.");
                    NavigationService.Navigate(new Uri("/NewReminderPage.xaml", UriKind.Relative));
                    txta.Text = "";
                    txtb.Text = "";
                    txtName.Text = "";
                    txtX.Text = "";

                }
            }
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            this.NavigationService.GoBack();
        }



        private void txtgetIt_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Drawer.Visibility = Visibility.Collapsed;
            NavigationService.Navigate(new Uri("/Mainpage.xaml?", UriKind.Relative));
        }
    }

}

