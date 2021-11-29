using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JLIDashboard.Classes
{
    public class HelperFunction
    {
        static int papersize = 38;
        static int cornerlength = 0;

        public static void ExportToExcelAndSaveDialog(SaveFileDialog dialog, GridView viewz)
        {
            dialog.Filter = "Excel files (*.xls)|*.xls";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = System.IO.Path.GetDirectoryName(dialog.FileName);
                string fname = System.IO.Path.GetFileName(dialog.FileName);
                if (viewz.RowCount > 0) { viewz.ExportToXls(filepath + "\\" + fname); }
                else { XtraMessageBox.Show("No Records to Export"); }
            }
        }
        public static void ExportToExcelAndSaveDialog(SaveFileDialog dialog, GridView viewz, string filename = "")
        {
            dialog.Filter = "Excel files (*.xls)|*.xls";
            dialog.FileName = filename;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = System.IO.Path.GetDirectoryName(dialog.FileName);
                string fname = System.IO.Path.GetFileName(dialog.FileName);
                if (viewz.RowCount > 0) { viewz.ExportToXls(filepath + "\\" + fname); }
                else { XtraMessageBox.Show("No Records to Export"); }
            }
        }

        public static string convertToNumericFormat(double value)
        {
            string str = "";
            str = String.Format("{0:0,0.00}", value);
            return str;
        }

        public static string numericFormat(double value)
        {
            string str = "";
            str = String.Format("{0:n2}", value);
            return str;
        }
        public static bool ConfirmDialog(string msg, string title)
        {
            DialogResult dr = XtraMessageBox.Show(msg, title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void isEnableAlpha(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        public static String sequencePadding(string reference, int max)
        {
            string isnum = "";
            string str = reference;
            for (int i = 0; i <= max - str.Length - 1; i++)
            {
                isnum = isnum + "0";
            }

            return isnum + str;
        }


        public static String PrintSpaceLine()
        {
            string spaceline = "";
            for (int i = 0; i <= papersize - (cornerlength * 2); i++)
            {
                spaceline += "-";
            }
            return PrintGetSpace(cornerlength) + spaceline;
        }

        public static String PrintCenterText(String align)
        {
            String str = "";
            for (int i = 0; i <= (papersize / 2) - (align.Length / 2); i++)
            {
                str = str + " ";
            }
            return str + align;
        }

        public static String PrintLeftText(String value)
        {
            return PrintGetSpace(cornerlength) + value;
        }

        public static String PrintLeftRigthText(String value_left, String value_right)
        {
            string str = "";
            if (value_left.Length > (papersize - value_right.Length))
            {
                value_left = Split1(value_left) + "..";
            }
            int a = (papersize - ((cornerlength * 2) + value_left.Length)) - value_right.Length;
            str = PrintGetSpace(cornerlength) + value_left + PrintGetSpace(a) + value_right;
            return str;
        }
        public static String AlignToCenter(String align)
        {
            string space = "";
            for (int i = 0; i <= (40 / 2) - (align.Length / 2); i++)
            {
                space = space + " ";
            }
            return space + align;
        }

        public static String AlignToRight(String align)
        {
            string space = "";
            for (int i = 0; i <= (40) - (align.Length); i++)
            {
                space = space + " ";
            }
            return space + align;
        }

        public static String createDottedLine()
        {
            string dottedline = "";
            for (int i = 0; i <= (papersize) - (cornerlength * 2); i++)
            {
                dottedline = dottedline + "-";
            }
            return PrintGetSpace(cornerlength) + dottedline;
        }

        public static String createAsteriskLine()
        {
            string dottedline = "";
            for (int i = 0; i <= (papersize) - (cornerlength * 2); i++)
            {
                dottedline = dottedline + "*";
            }
            return PrintGetSpace(cornerlength) + dottedline;
        }

        public static String createEqualLine()
        {
            string dottedline = "";
            for (int i = 0; i <= (papersize) - (cornerlength * 2); i++)
            {
                dottedline = dottedline + "=";
            }
            return PrintGetSpace(cornerlength) + dottedline;
        }


        public static String PrintGetSpace(int val)
        {
            string space = "";
            for (int i = 0; i <= val; i++)
            {
                space = space + " ";
            }
            return space;
        }
        public static string PrinttoRight(string righttext)
        {
            string str = "";
            for (int i = 0; i <= (39 - righttext.Length); i++)
            {
                str += " ";
            }
            return str + righttext;
        }

        public static String PrintRightToLeft(string leftstr, string rightstr)
        {
            string str = "";
            if (leftstr.Length > (40 - rightstr.Length))
            {
                leftstr = Split(leftstr) + "..";
            }
            int dob = (40 - ((0 * 2) + leftstr.Length)) - rightstr.Length;
            //   int ctr = (40 - (leftstr.Length))-rightstr.Length;
            str = PrintGetSpace(0) + leftstr + PrintGetSpace(dob) + rightstr;
            //   return str;
            int a = 32 - leftstr.Length;
            return leftstr + PrintGetSpace(a) + rightstr;
        }

        public static String PrintRightToMiddle(string leftstr, string rightstr)
        {
            string str = "";
            if (leftstr.Length > (40 - rightstr.Length))
            {
                leftstr = Split(leftstr) + "..";
            }
            int dob = (40 - ((0 * 2) + leftstr.Length)) - rightstr.Length;
            //   int ctr = (40 - (leftstr.Length))-rightstr.Length;
            str = PrintGetSpace(0) + leftstr + PrintGetSpace(dob) + rightstr;
            //   return str;
            int a = 24 - leftstr.Length;
            return leftstr + PrintGetSpace(a) + rightstr;
        }

        public static String Split1(String expression)
        {

            string str = expression;
            str = str.Remove(papersize - (18), str.Length - (papersize - (18)));
            return str;
        }

        public static String Split(string str)
        {
            string str1 = str;
            int a = 40 - Convert.ToInt32((40 / 4.25));
            int b = 40 - a;
            int c = str1.Length - b;
            str1 = str1.Remove(40 - (40 / 4), str1.Length - (40 - (40 / 4)));
            //str1 = str1.Remove((int)(40- (40 / 4.25)), (int)(str1.Length-(40-(40/4.25))));
            //str1 = str1.Remove(a,c);
            return str1;
        }

        public static String LastPagePaper()
        {
            string lastpage = "";
            lastpage = Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + (Char)27 + "i";
            return lastpage;
        }
        public static void embedToJournal(string filepath, string filepathJournal, string cashiertranscode, string replaceChar)
        {
            string details = String.Empty;
            var fileContent = string.Empty;
            using (var streamReader = new StreamReader(filepath, Encoding.UTF8))
            {
                fileContent = File.ReadAllText(filepath).Replace("*", replaceChar); //copy this or file
            }

            string txtorder = "\\" + cashiertranscode + "_E-JOURNAL.txt";
            string filetoprint = filepathJournal + txtorder;
            StreamWriter writer;//,writer22;

            if (!Directory.Exists(filepathJournal))
            {
                Directory.CreateDirectory(filepathJournal);
                writer = new StreamWriter(filetoprint);
            }
            else
            {
                writer = new StreamWriter(filetoprint, true);
            }
            writer.Write(fileContent);
            writer.Close();
        }

        public static void embedToJournal1(string filepath, string filepathJournal, string cashiertranscode, string replaceChar, string transcode)
        {
            string details = String.Empty;
            var fileContent = string.Empty;
            using (var streamReader = new StreamReader(filepath, Encoding.UTF8))
            {
                //fileContent = File.ReadAllText(filepath).Replace("*", replaceChar); //copy this or file
                fileContent = File.ReadAllText(filepath);
                if (fileContent.Contains("*"))
                {
                    fileContent = fileContent.Replace("*", replaceChar);
                }
                if (fileContent.Contains("$$$$$$"))
                {
                    fileContent = fileContent.Replace("$$$$$$", transcode);
                }
                //foreach (string line in File.ReadLines(filepath, Encoding.UTF8))
                //{fileContent
                //    // process the line
                //    if(line.Contains("$"))
                //    {
                //        fileContent += line.Replace("$", transcode);
                //    }
                //    if(line.Contains("*"))
                //    {
                //        fileContent += line.Replace("*", replaceChar);
                //    }
                //}
            }

            string txtorder = "\\" + cashiertranscode + "_E-JOURNAL.txt";
            string filetoprint = filepathJournal + txtorder;
            StreamWriter writer;//,writer22;

            if (!Directory.Exists(filepathJournal))
            {
                Directory.CreateDirectory(filepathJournal);
                writer = new StreamWriter(filetoprint);
            }
            else
            {
                writer = new StreamWriter(filetoprint, true);
            }
            writer.Write(fileContent);
            writer.Close();
        }

        public static String decimalParser(string value)
        {
            string strquantity = "";
            Decimal qty = Decimal.Parse(value);
            strquantity = String.Format("{0:00.000}", qty);
            return strquantity;
        }
        public static String decimalParser(string value, string pattern)
        {
            string strquantity = "";
            Decimal qty = Decimal.Parse(value);
            strquantity = String.Format(pattern, qty);
            return strquantity;
        }

        public static void exporttoexcel(GridView view, string title)
        {
            if (view.RowCount == 0)
            {
                XtraMessageBox.Show("No Data to Import!..");
                return;
            }
            else
            {

                string filepath = "C:\\MyFiles\\";
                Utilities.createDirectoryFolder(filepath);
                string filename = title + ".xls";
                string file = filepath + filename;
                view.ExportToXls(file);
                XtraMessageBox.Show("Successfully Exported.. Please Check your Drive C://MyFiles folder");
            }
        }

        public static string GetMACAddress2()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            return sMacAddress;
        }

        public static String getMacAddress()
        {
            string macaddress = "";
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.NetworkInterfaceType != NetworkInterfaceType.Ethernet)
                    continue;
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macaddress += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }

            return macaddress;
        }

        public static void exporttoexcel(GridView view, string title, string filepath)
        {
            if (view.RowCount == 0)
            {
                XtraMessageBox.Show("No Data to Import!..");
                return;
            }
            else
            {
                Utilities.createDirectoryFolder(filepath);
                string filename = title + ".xls";
                string file = filepath + filename;
                view.ExportToXls(file);
                XtraMessageBox.Show("Successfully Exported.. Please Check your Drive C://MyFiles folder");
            }
        }

    }
}
