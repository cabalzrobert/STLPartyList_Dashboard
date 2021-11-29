using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using JLIDashboard.Classes;
using AbacosDashboard.Module.Enum;
using Comm.Common.Extensions;
using JLIDashboard.Module;

using static JLIDashboard.TREASURY._x0a;
using static JLIDashboard.TREASURY._x0a.Vyw;
using JLIDashboard._Module;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using static JLIDashboard.OPERATION._x0i;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Reflection;
using JLIDashboard._Module.Classes.Common;

namespace JLIDashboard.TREASURY
{
    public partial class ResultConfirmation : DevExpress.XtraEditors.XtraForm
    {
        public ResultConfirmation()
        {
            InitializeComponent();
        }
        private void ResultConfirmation_Load(object sender, EventArgs e)
        {
            tbdatefrom.EditValue = tbdateto.EditValue = DateTime.Now;
            tbdatefrom.Enabled = tbdateto.Enabled = false;
            Timeout.Set(() => this.Invoke(new Action(() => btngenerate.PerformClick())), 250);
        }

        private Input result = new Input();
        private Filter filter = new Filter();
        private void gridViewwinningsandlimit_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            DataRow row = gvResult.GetFocusedDataRow();
            bool hasSelected = (row != null);
            bool isPending = (hasSelected && row["STAT"].Str().Equals("0"));
            cmsResultBtn0b.Visible = isPending;
            cmsResultBtn0c.Visible = isPending;
            cmsResultSep0a.Visible = isPending;
            if (!hasSelected) return;
            result.GameID = row["GM_TYP"].Str();
            result.DrawSchedule = row["DRW_TYP"].Str();
            result.DrawDate = row["DRW_TRN_DT"].Str();
            result.Result = row["NUM_RES"].Str();
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isPending = rgstatus.EditValue.Str().Equals("0");
            tbdatefrom.Enabled = !isPending;
            tbdateto.Enabled = !isPending;
        }
        private void btngenerate_Click(object sender, EventArgs e)
        {
            filter.Status = rgstatus.EditValue.Str();
            filter.DateFrom = tbdatefrom.EditValue.Str();
            filter.DateTo = tbdateto.EditValue.Str();
            loadResultsWProgress();
        }

        private void cmsResultBtn0a_Click(object sender, EventArgs e)
        {
            loadResultsWProgress();
        }

        private void cmsResultBtn0b_Click(object sender, EventArgs e)
        {
            if (!(XtraMessageBox.Show("Are you sure you want to decline result?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                return;
            StaticSettings.showLoading();
            var res = Db.execute0a(result, false).Result;
            if (res.result == Results.Success)
            {
                StaticSettings.XtraMessage(res.message, MessageBoxIcon.Asterisk);
                gvResult.DeleteRow(gvResult.FocusedRowHandle);
            }
            else if (res.result != Results.Null)
            {
                StaticSettings.XtraMessage(res.message, MessageBoxIcon.Hand);
            }
            else
            {
                XtraMessageBox.Show("No network connection! Please try again", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            StaticSettings.hideLoading();
        }

        private void cmsResultBtn0c_Click(object sender, EventArgs e)
        {
            if (!(XtraMessageBox.Show("Are you sure you want to confirm result?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                return;
            StaticSettings.showLoading();
            int focusedrow = gvResult.FocusedRowHandle;
            var res = Db.execute0a(result, true).Result;
            if (res.result == Results.Success)
            {
                StaticSettings.XtraMessage(res.message, MessageBoxIcon.Asterisk);
                gvResult.DeleteRow(focusedrow);
            }
            else if (res.result != Results.Null)
            {
                StaticSettings.XtraMessage(res.message, MessageBoxIcon.Hand);
            }
            else
            {
                XtraMessageBox.Show("No network connection! Please try again", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            StaticSettings.hideLoading();
        }
        private void loadResultsWProgress()
        {
            StaticSettings.showLoading();
            this.loadResults();
            StaticSettings.hideLoading();
        }
        private void loadResults()
        {
            API.displayAPI("/api/v1/ResultConfirmation/GameResult", gcResult, gvResult, Login.authentication, new Dictionary<string, object>()
            {
                {"dateFrom", filter.DateFrom },
                {"dateTo", filter.DateTo },
                {"status", filter.Status }
            });
            x0a(gvResult, filter.Status.Str().Equals("3"));
        }

    }

    public class _x0a
    {
        public class Vyw
        {
            public static GridView x0a(GridView gridView, bool isConfirm = false)
            {
                DevXSettings.XgridColsVisible(gridView, false);
                if (gridView.RowCount != 0)
                {
                    DevXSettings.XtraFormatColumn("GM_TYP_CD", "Game ID", 0, gridView);
                    DevXSettings.XtraFormatColumn("DRW_TRN_DT", "Date Draw", 1, gridView);
                    DevXSettings.XtraFormatColumn("DRW_TYP", "Draw", 2, gridView);
                    DevXSettings.XtraFormatColumn("NUM_RES", "Result", 3, gridView);
                    DevXSettings.XtraFormatColumn("TOT_AMT_STRGHT", "Gross Straight", 4, gridView);
                    DevXSettings.XtraFormatColumn("TOT_AMT_RMBL", "Gross Rumble", 5, gridView);
                    DevXSettings.XtraFormatColumn("TOT_AMT", "Total Gross", 6, gridView);
                    if (isConfirm)
                    {
                        DevXSettings.XtraFormatColumn("TOT_AMT_STRGHT_WNRS", "Total Win Straight", 7, gridView);
                        DevXSettings.XtraFormatColumn("TOT_AMT_RMBL_WNRS", "Total Win Rumble", 8, gridView);
                        DevXSettings.XtraFormatColumn("TOT_AMT_WNNG", "Total Winnings", 9, gridView);
                    }
                    DevXSettings.XtraFormatColumn("RGS_FLL_NM", "Posted By", 10, gridView);
                    DevXSettings.XtraFormatColumn("RGS_TRN_TS_NM", "Date Posted", 11, gridView);
                    DevXSettings.XtraFormatColumn("STAT_NM", "Status", 12, gridView);
                    DevXSettings.XgridColCurrency(new string[] { "TOT_AMT_STRGHT", "TOT_AMT_RMBL", "TOT_AMT", }, gridView);
                    DevXSettings.XgridColAlign(new string[] { "GM_TYP_CD", "DRW_TRN_DT", "DRW_TYP", "RGS_TRN_TS_NM", "NUM_RES", "STAT_NM" }, gridView, HorzAlignment.Center);
                    DevXSettings.XgridGeneralSummaryCurrency(new string[] { "TOT_AMT_STRGHT", "TOT_AMT_RMBL", "TOT_AMT" }, gridView);
                    if (isConfirm)
                    {
                        DevXSettings.XgridColCurrency(new string[] { "TOT_AMT_STRGHT_WNRS", "TOT_AMT_RMBL_WNRS", "TOT_AMT_WNNG" }, gridView);
                        DevXSettings.XgridGeneralSummaryCurrency(new string[] { "TOT_AMT_STRGHT_WNRS", "TOT_AMT_RMBL_WNRS", "TOT_AMT_WNNG" }, gridView);
                    }
                    gridView.BestFitColumns();
                }
                return gridView;
            }
        }
        public class Input
        {
            public string GameID;
            public string DrawSchedule;
            public string DrawDate;
            public string lDrawDate;
            public string Result;
            public static bool validity(Input input)
            {
                try
                {
                    try { input.lDrawDate = DateTime.Parse(input.DrawDate).ToString("yyyyMMdd"); }
                    catch { input.lDrawDate = input.DrawDate.ToDBDateString("yyyyMMdd"); }
                }
                catch { return false; }

                return true;
            }
        }
        public class Filter
        {
            public string Status;
            public string DateFrom;
            public string DateTo;
        }
        public class Db
        {
            public static async Task<(Results result, String message)> execute0a(Input input, bool isConfirm)
            {
                Input.validity(input);
                var results = API.DAPIQueryMultiple("/api/v1/ResultConfirmation/ConfirmResult", Login.authentication, new Dictionary<string, object>(){
                    { "gameID", input.GameID },
                    { "drawSchedule", input.DrawSchedule },
                    { "drawDate", input.lDrawDate },
                    { "result", input.Result },
                    { "status", (isConfirm?"1":"2") },
                });
                if (results != null)
                {

                    string ResultCode = results["result"].Str();
                    if (ResultCode == "2")
                    {
                        if (isConfirm)
                        {
                            await local.SaveResult("gencoord_winnings", results["gencoord_winnings"].Str());
                            await local.SaveResult("coord_winnings", results["coord_winnings"].Str());
                            await local.SaveResult("usher_winnings", results["usher_winnings"].Str());
                            return (Results.Success, results["message"].Str());
                        }
                        else if (!isConfirm) return (Results.Success, results["message"].Str());
                        return (Results.Success, results["message"].Str());
                    }
                    return (Results.Failed, results["message"].Str());
                }
                return (Results.Null, null);
            }
        }

        private class notify
        {
            public static async Task<bool> Winners(IEnumerable<dynamic> rows)
            {
                if (rows == null || rows.Count() < 1) return false;
                List<object> list = new List<object>();
                string strwinners = JsonConvert.SerializeObject(rows);
                DataTable dt = new DataTable();
                dt = null;
                if (strwinners != "[{}]")
                {
                    dt = (DataTable)JsonConvert.DeserializeObject(strwinners, typeof(DataTable));
                }
                if (dt != null)
                {
                    foreach (IDictionary<string, object> row in rows)
                    {
                        string type = row["TYP"].Str();
                        list.Clear(); list.Add(row);
                        if (type.Equals("post-result"))
                        {
                            await Pusher.PushAsync($"/{Login.plid}/{Login.pgrpid}/notify"
                                //, new { type = "post-result", content = dto.Notifications(list) });
                                , new { type = "post-result", content = rows });
                            continue;
                        }
                        await Pusher.PushAsync($"/{Login.plid}/{Login.pgrpid}/{row["USR_ID"].Str()}/notify"
                            //, new { type = "game-winning", content = dto.Notifications(list) });
                            , new { type = "game-winning", content = rows });
                    }
                }
                await Pusher.PushAsync($"/{Login.plid}/{Login.pgrpid}/lottery/bet/update", "{}");
                return true;
            }
        }

        private class local
        {
            private static string tryCreateDir(string type)
            {
                //var fullpath = $"./Transactions/{DateTime.Now.ToString("yyyMMdd")}/Winners/empty.txt";
                //var fullpath = $"./Transactions/Winners/{type}/empty.txt";
                var fullpath = $"C://Transactions/Winners/{type}/empty.txt";
                var fileInfo = new System.IO.FileInfo(fullpath);
                var dirInfo = fileInfo.Directory; //
                if (!dirInfo.Exists) dirInfo.Create();
                var fileDirectory = fileInfo.DirectoryName;
                dirInfo = null;
                fileInfo = null;
                return fileDirectory;
            }
            public static async Task<bool> SaveResult(string filename, string strResult)
            {
                string fileDir = local.tryCreateDir(filename);
                File.WriteAllText(fileDir + $"/{filename}.txt", strResult.ToString());
                Process.Start("notepad.exe", fileDir + $"/{filename}.txt");
                return false;
            }
            public static async Task<bool> SaveWinners(string filename
                , IDictionary<string, object> header
                , IEnumerable<dynamic> uplines
                , IEnumerable<dynamic> customers)
            {
                string fileDir = local.tryCreateDir(header["GM_TYP_NM"].Str());

                StringBuilder sb = new StringBuilder();
                sb.Append("Winning Bets Summary\n");
                sb.Append("-------------------------------------\n");
                sb.Append($"  Date: {header["DRW_TRN_DT_NM"].Str()}\n");
                sb.Append($"  Game: {header["GM_TYP_NM"].Str()}\n");
                sb.Append($"  Draw Schedule: {header["DRW_TYP"].Str()}\n");
                sb.Append($"  Result: {header["NUM_RES"].Str()}\n");
                sb.Append("\n");
                sb.Append($"  Total Straight: {header["TOT_AMT_STRGHT_WNRS"].Str().getAccountingFormat("0.00")}\n");
                sb.Append($"  Total Amount: {header["WIN_STRGHT_AMT"].Str().getAccountingFormat("0.00")}\n");
                sb.Append($"  Total Rumble: {header["TOT_AMT_RMBL_WNRS"].Str().getAccountingFormat("0.00")}\n");
                sb.Append($"  Total Amount: {header["WIN_RMB_AMT"].Str().getAccountingFormat("0.00")}\n");
                //sb.Append("-------------------------------------\n\n");

                var kvpUplines = GetUplines(uplines);
                if (kvpUplines != null)
                {
                    foreach (dynamic upln in kvpUplines.Values)
                    {
                        sb.Append("-------------------------------------\n\n");
                        sb.Append($"{upln.UplineName}\n");
                        sb.Append("\n");
                        var custs = (upln.Customers as List<dynamic>);
                        foreach (dynamic cust in custs)
                        {
                            sb.Append($"{cust.CustomerName}  {((double)cust.WinAmount).ToAccountingFormat("0.00")}\n");
                        }
                        sb.Append("\n");
                        sb.Append($"Total:  {((double)upln.TotalWinAmount).ToAccountingFormat("0.00")}\n");
                        sb.Append("\n");
                    }
                }
                var kvpCustomers = GetCustomers(customers);
                if (kvpCustomers != null)
                {
                    foreach (dynamic cust in kvpCustomers.Values)
                    {
                        sb.Append("-------------------------------------\n\n");
                        sb.Append($"{cust.CustomerName}\n");
                        sb.Append("\n");
                        var trns = (cust.Transactions as Dictionary<string, dynamic>);
                        foreach (dynamic trn in trns.Values)
                        {
                            if (!trn.BetType.Equals("S/R"))
                            {
                                sb.Append($"{trn.TransactionID} {trn.BetType}:{((double)trn.BetAmount).ToAccountingFormat("0")} {((double)trn.WinAmount).ToAccountingFormat("0.00")}\n");
                                continue;
                            }
                            sb.Append($"{trn.TransactionID} S:{((double)trn.BetStraightAmount).ToAccountingFormat("0")} {((double)trn.WinStraightAmount).ToAccountingFormat("0.00")}\n");
                            sb.Append($"{trn.TransactionID} R:{((double)trn.BetRumbleAmount).ToAccountingFormat("0")} {((double)trn.WinRumbleAmount).ToAccountingFormat("0.00")}\n");
                        }
                        sb.Append("\n");
                        sb.Append($"Total:  {((double)cust.TotalWinAmount).ToAccountingFormat("0.00")}\n");
                        sb.Append("\n");
                    }
                }
                File.WriteAllText(fileDir + $"/{filename}.txt", sb.ToString());
                Process.Start("notepad.exe", fileDir + $"/{filename}.txt");
                return false;
            }
            private static Dictionary<string, dynamic> GetCustomers(IEnumerable<dynamic> customers)
            {
                if (customers == null || customers.Count() < 1) return null;
                Dictionary<string, dynamic> kvp = new Dictionary<string, dynamic>();
                dynamic cust = null, trn = null;
                string strcustomer = JsonConvert.SerializeObject(customers);
                //strcustomer = strcustomer.Replace("{", "[{").Replace("}", "}]");
                DataTable dt = new DataTable();
                dt = null;
                if (strcustomer != "[{}]")
                {
                    dt = (DataTable)JsonConvert.DeserializeObject(strcustomer, typeof(DataTable));
                }
                if (dt != null)
                {
                    foreach (IDictionary<string, object> row in customers)
                    {
                        string custId = row["SUBSCR_ID"].Str();
                        if (custId.IsEmpty()) continue;
                        if (!kvp.ContainsKey(custId))
                        {
                            cust = (kvp[custId] = Dynamic.Object);
                            cust.CustomerID = row["SUBSCR_ID"].Str();
                            cust.CustomerName = row["PLYR_NM"].Str();
                            cust.TotalWinAmount = 0;
                            cust.Transactions = new Dictionary<string, dynamic>();//new List<dynamic>();
                        }
                        cust = (kvp[custId] as dynamic);
                        var trns = (cust.Transactions as Dictionary<string, dynamic>);
                        string trnId = row["TRN_NO"].Str();
                        if (!trns.ContainsKey(trnId))
                        {
                            trn = (trns[trnId] = Dynamic.Object);
                            trn.TransactionID = row["TRN_NO"].Str();
                            trn.BetType = row["WIN_STAT"].Str();
                            trn.BetStraightAmount = 0;
                            trn.BetRumbleAmount = 0;
                            trn.BetAmount = 0;
                            trn.WinStraightAmount = 0;
                            trn.WinRumbleAmount = 0;
                            trn.WinAmount = 0;
                        }
                        trn = (trns[trnId] as dynamic);
                        if (!trn.BetType.Equals("S/R"))
                            trn.BetType = row["WIN_STAT"].Str();
                        trn.BetStraightAmount += row["STRGHT_AMT"].Str().ToDecimalDouble();
                        trn.BetRumbleAmount += row["RMB_AMT"].Str().ToDecimalDouble();
                        trn.BetAmount += (trn.BetStraightAmount + trn.BetRumbleAmount);
                        trn.WinStraightAmount += row["WIN_STRGHT_AMT"].Str().ToDecimalDouble();
                        trn.WinRumbleAmount += row["WIN_RMB_AMT"].Str().ToDecimalDouble();
                        trn.WinAmount += (trn.WinStraightAmount + trn.WinRumbleAmount);
                        cust.TotalWinAmount += (trn.WinStraightAmount + trn.WinRumbleAmount);
                    }
                }

                return kvp;
            }

            private static Dictionary<string, dynamic> GetUplines(IEnumerable<dynamic> uplines)
            {
                if (uplines == null || uplines.Count() < 1) return null;
                Dictionary<string, dynamic> kvp = new Dictionary<string, dynamic>();
                dynamic upln = null, cust = null;
                string strUpline = JsonConvert.SerializeObject(uplines);
                DataTable dt = new DataTable();
                dt = null;
                if (strUpline != "[{}]")
                {
                    dt = (DataTable)JsonConvert.DeserializeObject(strUpline, typeof(DataTable));
                }
                if (dt != null)
                {
                    foreach (IDictionary<string, object> row in uplines)
                    {
                        string uplnId = row["UPLN_ID"].Str();
                        if (uplnId.IsEmpty()) continue;
                        if (!kvp.ContainsKey(uplnId))
                        {
                            upln = (kvp[uplnId] = Dynamic.Object);
                            upln.UplineID = row["UPLN_ID"].Str();
                            upln.UplineName = row["UPLN_NM"].Str();
                            upln.TotalWinAmount = 0;
                            upln.Customers = new List<dynamic>();
                        }
                        upln = (kvp[uplnId] as dynamic);
                        upln.Customers.Add(cust = Dynamic.Object);
                        cust.CustomerID = row["SUBSCR_ID"].Str();
                        cust.CustomerName = row["PLYR_NM"].Str();
                        cust.WinAmount = row["WIN_TOT_AMT"].Str().ToDecimalDouble();
                        upln.TotalWinAmount += cust.WinAmount;
                    }
                }

                return kvp;
            }
        }
    }
}