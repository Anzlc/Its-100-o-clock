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
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
    

        void timer_Tick(object sender, EventArgs e)
        {
            
            ClockLabel.Content = ParseToString((int)(ToSeconds(DateTime.Now) * ConvertTo100));
            
            
        }

        internal string ParseToString(int format100int)
        {
            string finish = "";
            int toRemove = 0;
            finish += format100int / 10000;
            toRemove = format100int / 10000 * 10000;
            format100int -= toRemove;
            finish += ":";
            finish += format100int / 100;
            toRemove = format100int / 100 * 100;
            format100int -= toRemove;
            finish += ":";
            finish += format100int;

            return finish;

        }


        internal float ToSeconds(DateTime time)
        { 
            
            return time.Hour * 3600f + time.Minute * 60f + time.Second + time.Millisecond * 0.001f;
        }

        

    }
}
