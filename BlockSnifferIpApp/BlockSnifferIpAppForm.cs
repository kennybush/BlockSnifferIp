using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System;
using BlockSnifferIp;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;

namespace BlockSnifferIpApp
{
    public partial class frmBlockSnifferIpApp : Form
    {
        Monitor monitor;
        Timer tRefreshTimer;
        int nTargetPort;
        ListViewItemSorter listViewSorter;
        Color cHighlight;

        /// <summary>
        /// 读取配置文件int值
        /// </summary>
        /// <param name="key">需要读取的key</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        int ConfigReadInt(string key, int defaultValue = 0)
        {
            int ntmp = defaultValue;
            Configuration conf = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            if (conf.AppSettings.Settings.Count > 0)
            {
                int.TryParse(conf.AppSettings.Settings[key] != null ? conf.AppSettings.Settings[key].Value : "", out ntmp);
            }
            return ntmp;
        }

        /// <summary>
        /// 读取配置文件string值
        /// </summary>
        /// <param name="key">需要读取的key</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        string ConfigReadString(string key, string defaultValue = "")
        {
            string stmp = defaultValue;
            Configuration conf = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            if (conf.AppSettings.Settings.Count > 0)
            {
                stmp=conf.AppSettings.Settings[key] != null ? conf.AppSettings.Settings[key].Value : defaultValue;
            }
            return stmp;
        }

        /// <summary>
        /// 写入配置文件
        /// </summary>
        /// <param name="key">需要写入的key</param>
        /// <param name="value">需要写入的值</param>
        void ConfigWriteString(string key, string value)
        {
            Configuration conf = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            if (conf.AppSettings.Settings[key] != null)
                conf.AppSettings.Settings[key].Value = value;
            else
                conf.AppSettings.Settings.Add(key, value);
            conf.Save(ConfigurationSaveMode.Modified);
        }

        Record[] RecordRead(string sFilePath)
        {
            string json = File.ReadAllText(sFilePath);
            ExportRecordJson jsonObj = JsonConvert.DeserializeObject<ExportRecordJson>(json);
            return jsonObj.data;
        }

        void RecordWrite(string sFilePath)
        {
            ExportRecordJson jsonObj = new ExportRecordJson();
            List<Record> lRecord = new List<Record>();
            ListViewItem[] ltmp = new ListViewItem[lstMonitor.Items.Count];
            lstMonitor.Items.CopyTo(ltmp, 0);

            uint n;
            foreach (ListViewItem lvi in ltmp)
            {
                n = 0;
                DateTime dt = DateTime.MinValue;
                Record r = new Record() { enabled = lvi.Checked, ip = lvi.SubItems[0].Text };
                uint.TryParse(lvi.SubItems[1].Text, out n);
                r.transfer = n;
                n = 0;
                uint.TryParse(lvi.SubItems[2].Text, out n);
                r.alive = n;
                n = 0;
                DateTime.TryParse(lvi.SubItems[3].Text, out dt);
                r.last_alive = dt;
                uint.TryParse(lvi.SubItems[4].Text, out n);
                r.count = n;
                lRecord.Add(r);
            }
            jsonObj.data = lRecord.ToArray();

            string json = JsonConvert.SerializeObject(jsonObj);
            File.WriteAllText(sFilePath, json);
        }

        public frmBlockSnifferIpApp()
        {
            InitializeComponent();

            // Load settings
            txtTargetPort.Text = ConfigReadString("TargetPort");
            int.TryParse(txtTargetPort.Text, out nTargetPort);
            int nSortColumn = ConfigReadInt("SortColumn");
            string sSorting = ConfigReadString("Sorting", "None");
            int nHighlightColor = ConfigReadInt("HighlightColor");

            if (nSortColumn < 0 || nSortColumn > 4)
                nSortColumn = 0;

            // Load records
            Record[] lRecord = { };
            try
            {
                lRecord = RecordRead(AppDomain.CurrentDomain.BaseDirectory + "\\record.dat");
            }
            catch (Exception ex) { }

            cHighlight = Color.FromArgb(nHighlightColor);
            txtColor.Text = cHighlight.ToArgb().ToString("X");
            txtColor.ForeColor = cHighlight;
            listViewSorter = new ListViewItemSorter(nSortColumn, (SortOrder)Enum.Parse(typeof(SortOrder), sSorting));
            lstMonitor.ListViewItemSorter = listViewSorter;
            monitor = new Monitor(nTargetPort);
            monitor.LoadRecord(new List<Record>(lRecord));
            tRefreshTimer = new Timer() { Interval = 1000 };
            tRefreshTimer.Tick += RefreshList;
            tRefreshTimer.Start();
        }

        /// <summary>
        /// 获取并刷新监控列表, 由Timer调起
        /// </summary>
        void RefreshList(object sender, EventArgs e)
        {
            List<Record> NetworkRecord = monitor.GetRecord();
            foreach (Record r in NetworkRecord)
            {
                ListViewItem lvi = lstMonitor.FindItemWithText(r.ip);
                if (lvi == null)
                {
                    lvi = new ListViewItem(r.ip);
                    lvi.SubItems.AddRange(new string[] { "", "", "", "" });
                    lstMonitor.Items.Add(lvi);
                }
                lvi.SubItems[2].Text = r.alive.ToString();
                lvi.SubItems[3].Text = r.last_alive.ToString();
                lvi.SubItems[4].Text = r.count.ToString();
            }
            lstMonitor.Sort();
            lstMonitor.Update();
        }

        private void lstMonitor_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == listViewSorter.ColumnToSort)
            {
                if (listViewSorter.OrderOfSort == SortOrder.Ascending)
                    listViewSorter.OrderOfSort = SortOrder.Descending;
                else
                    listViewSorter.OrderOfSort = SortOrder.Ascending;
            }
            else
            {
                listViewSorter.ColumnToSort = e.Column;
                listViewSorter.OrderOfSort = SortOrder.Descending;
            }
            lstMonitor.Sort();
            lstMonitor.Update();

            ConfigWriteString("SortColumn", e.Column.ToString());
            ConfigWriteString("Sorting", listViewSorter.OrderOfSort.ToString());
        }

        private void txtTargetPort_Leave(object sender, EventArgs e)
        {
            int newVal = 0;
            if (int.TryParse(txtTargetPort.Text, out newVal))
            {
                if (newVal > 0 && newVal < 65536)
                {
                    nTargetPort = newVal;
                    tRefreshTimer.Stop();
                    monitor.Dispose();
                    monitor = new Monitor(nTargetPort);
                    tRefreshTimer.Start();

                    ConfigWriteString("TargetPort", nTargetPort.ToString());
                }
            }
            txtTargetPort.Text = nTargetPort.ToString();
        }

        private void frmBlockSnifferIpApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            tRefreshTimer.Stop();
            monitor.Dispose();
            RecordWrite(AppDomain.CurrentDomain.BaseDirectory + "\\record.dat");
        }

        private void txtColor_Enter(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color =cHighlight;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                cHighlight = cd.Color;
                txtColor.Text= cHighlight.ToArgb().ToString("X");
                txtColor.ForeColor = cHighlight;

                ConfigWriteString("HighlightColor", txtColor.Text);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string filepath = "";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.RestoreDirectory = true;
            sfd.CheckPathExists = true;
            sfd.DefaultExt = "json";
            if (sfd.ShowDialog() != DialogResult.OK)
                return;
            filepath = sfd.FileName;

            tRefreshTimer.Stop();
            try
            {
                RecordWrite(filepath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            tRefreshTimer.Start();
        }
    }

    /// <summary>
    /// ListView排序所用
    /// </summary>
    class ListViewItemSorter : IComparer
    {
        public int ColumnToSort;
        public SortOrder OrderOfSort;

        public ListViewItemSorter()
        {
            ColumnToSort = 0;
            OrderOfSort = SortOrder.Ascending;
        }

        public ListViewItemSorter(int column, SortOrder order)
        {
            ColumnToSort = column;
            OrderOfSort = order;
        }

        public int Compare(object left, object right)
        {
            int comaretInt = 0;
            DateTime comaretDatetime = DateTime.MinValue;
            int returnVal = -1;

            ListViewItem x = (ListViewItem)left;
            ListViewItem y = (ListViewItem)right;

            if (int.TryParse(x.SubItems[ColumnToSort].Text, out comaretInt) && int.TryParse(y.SubItems[ColumnToSort].Text, out comaretInt))
            {
                returnVal = int.Parse(x.SubItems[ColumnToSort].Text).CompareTo(int.Parse(y.SubItems[ColumnToSort].Text));
            }
            else if (DateTime.TryParse(x.SubItems[ColumnToSort].Text, out comaretDatetime) && DateTime.TryParse(y.SubItems[ColumnToSort].Text, out comaretDatetime))
            {
                returnVal = DateTime.Parse(x.SubItems[ColumnToSort].Text).CompareTo(DateTime.Parse(y.SubItems[ColumnToSort].Text));
            }
            else
                returnVal = string.Compare(x.SubItems[ColumnToSort].Text, y.SubItems[ColumnToSort].Text);
            if (OrderOfSort == SortOrder.Descending)
                returnVal *= -1;
            return returnVal;
        }
    }
}
