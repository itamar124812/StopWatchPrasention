using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using StopWatchImp;
using System.Windows.Shapes;

namespace StopWatchPrasention
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IStopWatch watch = StopWatchImp.Factory.GetStopWatch("2");
        public bool StartOrStop;
        public MainWindow()
        {
            InitializeComponent();
            Clock.DataContext = watch;
            
        }
        private void input_cheke(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch((sender as TextBox).Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                (sender as TextBox).Text = (sender as TextBox).Text.Remove((sender as TextBox).Text.Length - 1);
            }

        }

        private void OnOffButton_Click(object sender, RoutedEventArgs e)
        {
            if(StartOrStop)
            {
                watch.StopOperetion();
                OnOffButton.Content = "Start";
                Rate.IsReadOnly = false;
                Clock.IsReadOnly = false;
                StartOrStop = false;
            }
            else
            {
                TimeSpan time = TimeSpan.Zero;
                Rate.IsReadOnly = true;
                Clock.IsReadOnly = true;
                OnOffButton.Content = "Stop";
                TimeSpan.TryParse(Clock.Text, out time);
                watch.StartOperetion(uint.Parse(Rate.Text), time);
                StartOrStop = true;
            }
        }
    }
}
