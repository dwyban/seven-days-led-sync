using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SevenDaysLightSync
{
    public partial class SevenDaysLightSyncApp : Form
    {
        private LightSync _sync = null;
        private bool _isRunning = false;

        public SevenDaysLightSyncApp()
        {
            InitializeComponent(); 
        }

        private void _sync_LightColorChanged(object sender, SevenDaysLightSyncEventArgs e)
        {
            pnlCurrentColor.BackColor = e.LightColor;
        }

        private void cmdConnectDisconnect_Click(object sender, EventArgs e)
        {
            
        }

        private void gcpLightingColors_ColorMoved(object sender, EventArgs e)
        {
            var temp = gcpNormalLighting.SelectedColor.Position;
            lblPos.Text = $"Pos: {temp.ToString()}";
        }

        private void SevenDaysLightSyncApp_Load(object sender, EventArgs e)
        {
            cmbxControllerPort.SelectedIndex = 2;

            _sync = new LightSync();
            _sync.LightColorChanged += _sync_LightColorChanged;
            _sync.TimeUpdated += _sync_TimeUpdated;

            gcpNormalLighting.Colors.Clear();
            gcpNormalLighting.RemoveSelectedColor();

            gcpBloodMoonLighting.Colors.Clear();
            gcpBloodMoonLighting.RemoveSelectedColor();

            // Configure the color gradient to show the lighting table
            LightingTable lt = _sync.LightingTable;

            foreach (KeyValuePair<double,LightingValue> entry in lt.Entries)
            {
                gcpNormalLighting.AddColor(entry.Value.Normal, Convert.ToSingle(entry.Key / SevenDays.MINUTES_PER_DAY));
                gcpBloodMoonLighting.AddColor(entry.Value.BloodMoon, Convert.ToSingle(entry.Key / SevenDays.MINUTES_PER_DAY));
            }

            KeyValuePair<double, LightingValue> lastInTable = lt.Entries.Last();
            KeyValuePair<double, LightingValue> firstInTable = lt.Entries.First();

            Color midnightNormalColor = LightingTable.CalcFadeColor(lastInTable.Value.Normal,
                firstInTable.Value.Normal,
                (SevenDays.MINUTES_PER_DAY - lastInTable.Key) / ((firstInTable.Key + SevenDays.MINUTES_PER_DAY) - lastInTable.Key));
            gcpNormalLighting.AddColor(midnightNormalColor, 0);
            gcpNormalLighting.AddColor(midnightNormalColor, 1);


            Color midnightBloodMoonColor = LightingTable.CalcFadeColor(lastInTable.Value.BloodMoon,
                firstInTable.Value.BloodMoon,
                (SevenDays.MINUTES_PER_DAY - lastInTable.Key) / ((firstInTable.Key + SevenDays.MINUTES_PER_DAY) - lastInTable.Key));
            gcpBloodMoonLighting.AddColor(midnightBloodMoonColor, 0);
            gcpBloodMoonLighting.AddColor(midnightBloodMoonColor, 1);

            cmdBuild_Click(this, new EventArgs());
        }

        private void _sync_TimeUpdated(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler<EventArgs>(_sync_TimeUpdated), sender, e);
            }
            txtDay.Text = _sync.GameDay.ToString();
            txtTime.Text = $"{_sync.GameHour:d2}:{_sync.GameMinute:d2}";
        }

        private void cmdStartStop_Click(object sender, EventArgs e)
        {
            if (_isRunning) // Then stop it
            {
                _sync.StopTime();
                cmdStartStop.Text = "Start";
            }
            else // Start it
            {
                _sync.GameDayNightLength = (int)nudDayNightLength.Value;
                _sync.GameDayLightLength = (int)nudDayLightLength.Value;
                _sync.GameTimeMinutes = 1440 + 7*60;


                _sync.StartTime();
                cmdStartStop.Text = "Stop";
            }
            _isRunning = !_isRunning;
        }

        private void cmdStartTimeReset_Click(object sender, EventArgs e)
        {
            nudStartDay.Value = 1;
            nudStartHour.Value = 0;
            nudStartMinute.Value = 0;
        }

        private void cmdBuild_Click(object sender, EventArgs e)
        {
            dgvLightingTableNormal.Rows.Clear();

            foreach (GradientColorPickerItem item in gcpNormalLighting.Colors)
            {
                // Don't process the ends.  Those are only for display purposes
                if (item.Position == 0 || item.Position == 1)
                    continue;

                SevenDaysGameTime gt = SevenDaysGameTime.FromGameTimeMinutes(item.Position * 1440);

                dgvLightingTableNormal.Rows.Add(gt.ToString(), item.Color.ToString());
            }

            dgvLightingTableBloodMoon.Rows.Clear();

            foreach (GradientColorPickerItem item in gcpBloodMoonLighting.Colors)
            {
                // Don't process the ends.  Those are only for display purposes
                if (item.Position == 0 || item.Position == 1)
                    continue;

                SevenDaysGameTime gt = SevenDaysGameTime.FromGameTimeMinutes(item.Position * 1440);

                dgvLightingTableBloodMoon.Rows.Add(gt.ToString(), item.Color.ToString());
            }
        }
    }
}
