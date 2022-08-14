using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace It_s_100_o_clock.Utils
{
    public class TimeConverter
    {
        public static readonly float ConvertTo100 = 11.57407407407407f;

        public string ParseToString(int format100int)
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


        public float ToSeconds(DateTime time)
        {

            return time.Hour * 3600f + time.Minute * 60f + time.Second + time.Millisecond * 0.001f;
        }

        public float To24Second(float seconds100)
        {
            return seconds100 / ConvertTo100;
        }
        
        public float To100Second(float seconds24)
        {
            return seconds24 * ConvertTo100;
        }

        public int[] GetHoursMinutesSecondsFromSeconds24(int seconds)
        { 
            int[] returns = new int[3];

            returns[0] = seconds / 3600;
            seconds -= returns[0] * 3600;
            returns[1] = seconds / 60;            
            seconds -= returns[1] * 60;
            returns[2] = seconds;
            return returns;

        }
        public int[] GetHoursMinutesSecondsFromSeconds100(int seconds)
        { 
            int[] returns = new int[3];

            returns[0] = seconds / 10000;
            seconds -= returns[0] * 10000;
            returns[1] = seconds / 100;            
            seconds -= returns[1] * 100;
            returns[2] = seconds;
            return returns;

        }
    }
}
