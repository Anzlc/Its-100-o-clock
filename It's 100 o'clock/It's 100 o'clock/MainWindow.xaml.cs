using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using It_s_100_o_clock.Pages;
using It_s_100_o_clock.Utils;

namespace It_s_100_o_clock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        
        TimeConverter timeConverter;
        
        ConvertScreen cs;
        public MainWindow()
        {
            InitializeComponent();
            CompositionTarget.Rendering += Rendered_EventHandler;

            timeConverter = new TimeConverter();
            cs = new ConvertScreen();
        }

        private void Rendered_EventHandler(object sender, EventArgs e)
        {
            ClockLabel.Content = timeConverter.ParseToString((int)(timeConverter.ToSeconds(DateTime.Now) * TimeConverter.ConvertTo100));
        }


        

        

        private void ClockButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = null;
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            
            
            
            Main.Content = cs;
            

            
            
           
        }
    }
}
