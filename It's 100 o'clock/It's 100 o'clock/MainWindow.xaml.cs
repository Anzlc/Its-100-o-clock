using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace It_s_100_o_clock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        public readonly float ConvertTo100 = 11.57407407407407f;
        internal DateTime dt = DateTime.Now;
        internal DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            ClockLabel.Content = dt.Second;
            
            
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
    

        void timer_Tick(object sender, EventArgs e)
        {
            dt = DateTime.Now;
            ClockLabel.Content = dt.Second;
        }


    }
}
