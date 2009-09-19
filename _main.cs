using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using Binary_Clock.Properties;

namespace Binary_Clock
{
    public partial class _main : Form
    {
        public _main()
        {
            InitializeComponent();
        }

        string[] binaries = { "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001" };

        private string GetMonth(int month)
        {
            switch (month)
            {
                case 1:
                    return "Jan";
                    break;
                case 2:
                    return "Feb";
                    break;
                case 3:
                    return "Mar";
                    break;
                case 4:
                    return "Apr";
                    break;
                case 5:
                    return "May";
                    break;
                case 6:
                    return "Jun";
                    break;
                case 7:
                    return "Jul";
                    break;
                case 8:
                    return "Aug";
                    break;
                case 9:
                    return "Sep";
                    break;
                case 10:
                    return "Oct";
                    break;
                case 11:
                    return "Nov";
                    break;
                case 12:
                    return "Dec";
                    break;
                default:
                    return "???";
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string hour = DateTime.Now.Hour.ToString();
            string minute = DateTime.Now.Minute.ToString();
            string second = DateTime.Now.Second.ToString();
            TimeSpan span = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());
            if (hour.Length < 2) hour = "0" + hour;
            if (minute.Length < 2) minute = "0" + minute;
            if (second.Length < 2) second = "0" + second;
            lblTime.Text = hour + ":" + minute + ":" + second;
            lblDate.Text = DateTime.Now.Day + " " + GetMonth(DateTime.Now.Month) + " " + DateTime.Now.Year;
            lblTimestamp.Text = ((double)(int)span.TotalSeconds).ToString();

            string HRa = hour.Substring(0, 1), HRb = hour.Substring(1, 1);
            string MINa = minute.Substring(0, 1), MINb = minute.Substring(1, 1);
            string SECa = second.Substring(0, 1), SECb = second.Substring(1, 1);

            string[] HR = { binaries[Convert.ToInt32(HRa)], binaries[Convert.ToInt32(HRb)] };
            string[] MIN = { binaries[Convert.ToInt32(MINa)], binaries[Convert.ToInt32(MINb)] };
            string[] SEC = { binaries[Convert.ToInt32(SECa)], binaries[Convert.ToInt32(SECb)] };

            HRa2.Image = ToBlue(HR[0][2].ToString());
            HRa1.Image = ToBlue(HR[0][3].ToString());
            HRb8.Image = ToBlue(HR[1][0].ToString());
            HRb4.Image = ToBlue(HR[1][1].ToString());
            HRb2.Image = ToBlue(HR[1][2].ToString());
            HRb1.Image = ToBlue(HR[1][3].ToString());

            MINa4.Image = ToBlue(MIN[0][1].ToString());
            MINa2.Image = ToBlue(MIN[0][2].ToString());
            MINa1.Image = ToBlue(MIN[0][3].ToString());
            MINb8.Image = ToBlue(MIN[1][0].ToString());
            MINb4.Image = ToBlue(MIN[1][1].ToString());
            MINb2.Image = ToBlue(MIN[1][2].ToString());
            MINb1.Image = ToBlue(MIN[1][3].ToString());

            SECa4.Image = ToBlue(SEC[0][1].ToString());
            SECa2.Image = ToBlue(SEC[0][2].ToString());
            SECa1.Image = ToBlue(SEC[0][3].ToString());
            SECb8.Image = ToBlue(SEC[1][0].ToString());
            SECb4.Image = ToBlue(SEC[1][1].ToString());
            SECb2.Image = ToBlue(SEC[1][2].ToString());
            SECb1.Image = ToBlue(SEC[1][3].ToString());
        }

        public Image ToBlue(string binary)
        {
            if (binary == "1") return Resources.lightblue;
            return Resources.darkblue;
        }
    }
}