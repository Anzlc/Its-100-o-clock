using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using It_s_100_o_clock.Pages;

namespace It_s_100_o_clock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        public readonly float ConvertTo100 = 11.57407407407407f;
        
        internal readonly SolidColorBrush mouseOverColor = (SolidColorBrush)new BrushConverter().ConvertFrom("#33000000");
        internal DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            CompositionTarget.Rendering += Rendered_EventHandler;



        }

        private void Rendered_EventHandler(object sender, EventArgs e)
        {
            ClockLabel.Content = ParseToString((int)(ToSeconds(DateTime.Now) * ConvertTo100));
        }


        

        internal string ParseToString(int format100int)
        {
            string finish = "";
            finish += (format100int / 10000).ToString("00");
            int toRemove = format100int / 10000 * 10000;
            format100int -= toRemove;
            finish += ":";
            finish += (format100int / 100).ToString("00");
            toRemove = format100int / 100 * 100;
            format100int -= toRemove;
            finish += ":";
            finish += format100int.ToString("00");

            return finish;

        }


        internal float ToSeconds(DateTime time)
        { 
            
            return time.Hour * 3600f + time.Minute * 60f + time.Second + time.Millisecond * 0.001f;
        }

        private void ClockButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = null;
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Clicked");
            ConvertScreen cs = new ConvertScreen();
            MessageBox.Show("Created Class");
            Main.Content = cs;
            MessageBox.Show("Assigned Class");

            
            
           
        }
    }
}
