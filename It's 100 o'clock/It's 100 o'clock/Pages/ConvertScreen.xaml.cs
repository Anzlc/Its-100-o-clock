using It_s_100_o_clock.Utils;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace It_s_100_o_clock.Pages
{
    /// <summary>
    /// Interaction logic for ConvertScreen.xaml
    /// </summary>
    /// 



    public partial class ConvertScreen : Page
    {
        Dictionary<string, int> convertFields = new Dictionary<string, int>();
        Dictionary<string, TextBox> textBoxes = new Dictionary<string, TextBox>();
        TimeConverter timeConverter = new TimeConverter();
        internal bool skipTextChange = false;

        internal enum MaxTimeValues : int
        { 
            Hour100 = 100,
            Minute100 = 100,
            Second100 = 100,
            Hour24 = 24,
            Minute24 = 60,
            Second24 = 60
        }

        public ConvertScreen()
        {
            InitializeComponent();
        }

        private void Convert_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (skipTextChange) { return; }
            string sendersName = ((FrameworkElement)sender).Name;
            TextBox textBox = (TextBox)sender;
            if (!textBoxes.ContainsKey(sendersName))
            { 
                textBoxes.Add(sendersName, textBox);
            }


            if (!string.IsNullOrEmpty(textBox.Text))
            {

                if (convertFields.ContainsKey(sendersName))
                {

                    try
                    {
                        int converted = Convert.ToInt32(textBox.Text);
                        if (converted < GetMaxValue(sendersName))
                        {
                            convertFields[sendersName] = converted;
                            ConvertTime(sendersName);
                        }
                        else
                        { 
                            textBox.Text = convertFields[sendersName].ToString();
                            
                        }


                    }
                    catch
                    {

                        textBox.Text = convertFields[sendersName].ToString();
                    }
                }
                else
                {
                    convertFields.Add(sendersName, Convert.ToInt32(textBox.Text));
                }
            }
            else
            {
                textBox.Text = "0";
            }
        }

        private void ConvertTime(string sendersName)
        {
            if (sendersName.EndsWith("100"))
            {
                ConvertTo24();
            }
            else
            { 
                ConvertTo100();
                
            }
        }

        internal void ConvertTo100()
        {
            int seconds = 0;
            seconds += convertFields["Hour24"] * 3600;
            seconds += convertFields["Minute24"] * 60;
            seconds += convertFields["Second24"];

            seconds = (int)timeConverter.To100Second(seconds);
            int[] times = timeConverter.GetHoursMinutesSecondsFromSeconds100(seconds);
            skipTextChange = true;
            textBoxes["Hour100"].Text = times[0].ToString();
            textBoxes["Minute100"].Text = times[1].ToString();
            textBoxes["Second100"].Text = times[2].ToString();
            convertFields["Hour100"] = times[0];
            convertFields["Minute100"] = times[1];
            convertFields["Second100"] = times[2];
            skipTextChange = false;
        }

        internal void ConvertTo24()
        {
            int seconds = 0;
            seconds += convertFields["Hour100"] * 100 * 100;
            seconds += convertFields["Minute100"] * 100;
            seconds += convertFields["Second100"];

            seconds = (int)timeConverter.To24Second(seconds);
            int[] times = timeConverter.GetHoursMinutesSecondsFromSeconds24(seconds);
            skipTextChange = true;
            textBoxes["Hour24"].Text = times[0].ToString();
            textBoxes["Minute24"].Text = times[1].ToString();
            textBoxes["Second24"].Text = times[2].ToString();
            convertFields["Hour24"] = times[0];
            convertFields["Minute24"] = times[1];
            convertFields["Second24"] = times[2];
            skipTextChange = false;

        }

        internal int GetMaxValue(string _name)
        {

            return (int)Enum.Parse(typeof(MaxTimeValues), _name);
        }
    }
}
