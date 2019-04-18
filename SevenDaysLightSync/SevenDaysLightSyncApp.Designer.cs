namespace SevenDaysLightSync
{
    partial class SevenDaysLightSyncApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.GradientColorPickerItem gradientColorPickerItem17 = new System.Windows.Forms.GradientColorPickerItem();
            System.Windows.Forms.GradientColorPickerItem gradientColorPickerItem18 = new System.Windows.Forms.GradientColorPickerItem();
            System.Windows.Forms.GradientColorPickerItem gradientColorPickerItem19 = new System.Windows.Forms.GradientColorPickerItem();
            System.Windows.Forms.GradientColorPickerItem gradientColorPickerItem20 = new System.Windows.Forms.GradientColorPickerItem();
            System.Windows.Forms.GradientColorPickerItem gradientColorPickerItem21 = new System.Windows.Forms.GradientColorPickerItem();
            System.Windows.Forms.GradientColorPickerItem gradientColorPickerItem22 = new System.Windows.Forms.GradientColorPickerItem();
            System.Windows.Forms.GradientColorPickerItem gradientColorPickerItem23 = new System.Windows.Forms.GradientColorPickerItem();
            System.Windows.Forms.GradientColorPickerItem gradientColorPickerItem24 = new System.Windows.Forms.GradientColorPickerItem();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.lblController = new System.Windows.Forms.Label();
            this.lblHostname = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.cmdConnectDisconnect = new System.Windows.Forms.Button();
            this.lblDay = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.txtDay = new System.Windows.Forms.TextBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.lblOutput = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.gcpNormalLighting = new System.Windows.Forms.GradientColorPicker();
            this.pnlCurrentColor = new System.Windows.Forms.Panel();
            this.cmbxControllerPort = new System.Windows.Forms.ComboBox();
            this.cmdStartStop = new System.Windows.Forms.Button();
            this.lblPos = new System.Windows.Forms.Label();
            this.ipacServerIP = new IPAddressControlLib.IPAddressControl();
            this.nudDayNightLength = new System.Windows.Forms.NumericUpDown();
            this.nudDayLightLength = new System.Windows.Forms.NumericUpDown();
            this.lblDayNightLength = new System.Windows.Forms.Label();
            this.lblDayLightLength = new System.Windows.Forms.Label();
            this.nudStartDay = new System.Windows.Forms.NumericUpDown();
            this.nudStartMinute = new System.Windows.Forms.NumericUpDown();
            this.lblStartDay = new System.Windows.Forms.Label();
            this.lblStartMinute = new System.Windows.Forms.Label();
            this.cmdStartTimeReset = new System.Windows.Forms.Button();
            this.nudStartHour = new System.Windows.Forms.NumericUpDown();
            this.lblStartHour = new System.Windows.Forms.Label();
            this.grpbxManualSettings = new System.Windows.Forms.GroupBox();
            this.gcpBloodMoonLighting = new System.Windows.Forms.GradientColorPicker();
            this.dgvLightingTableNormal = new System.Windows.Forms.DataGridView();
            this.cmdBuild = new System.Windows.Forms.Button();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColorNormal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLightingTableBloodMoon = new System.Windows.Forms.DataGridView();
            this.colTimeBM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColorBM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabSync = new System.Windows.Forms.TabPage();
            this.tabLightingTable = new System.Windows.Forms.TabPage();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDayNightLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDayLightLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartHour)).BeginInit();
            this.grpbxManualSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLightingTableNormal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLightingTableBloodMoon)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabSync.SuspendLayout();
            this.tabLightingTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(13, 202);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(366, 81);
            this.txtOutput.TabIndex = 0;
            // 
            // lblController
            // 
            this.lblController.AutoSize = true;
            this.lblController.Location = new System.Drawing.Point(77, 64);
            this.lblController.Name = "lblController";
            this.lblController.Size = new System.Drawing.Size(54, 13);
            this.lblController.TabIndex = 2;
            this.lblController.Text = "Controller:";
            // 
            // lblHostname
            // 
            this.lblHostname.AutoSize = true;
            this.lblHostname.Location = new System.Drawing.Point(70, 12);
            this.lblHostname.Name = "lblHostname";
            this.lblHostname.Size = new System.Drawing.Size(61, 13);
            this.lblHostname.TabIndex = 4;
            this.lblHostname.Text = "IP Address:";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(276, 13);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(29, 13);
            this.lblPort.TabIndex = 5;
            this.lblPort.Text = "Port:";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(311, 9);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(46, 20);
            this.txtPort.TabIndex = 6;
            this.txtPort.Text = "8081";
            // 
            // cmdConnectDisconnect
            // 
            this.cmdConnectDisconnect.Location = new System.Drawing.Point(282, 58);
            this.cmdConnectDisconnect.Name = "cmdConnectDisconnect";
            this.cmdConnectDisconnect.Size = new System.Drawing.Size(75, 23);
            this.cmdConnectDisconnect.TabIndex = 7;
            this.cmdConnectDisconnect.Text = "Connect";
            this.cmdConnectDisconnect.UseVisualStyleBackColor = true;
            this.cmdConnectDisconnect.Click += new System.EventHandler(this.cmdConnectDisconnect_Click);
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Location = new System.Drawing.Point(16, 299);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(29, 13);
            this.lblDay.TabIndex = 8;
            this.lblDay.Text = "Day:";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(105, 299);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(33, 13);
            this.lblTime.TabIndex = 9;
            this.lblTime.Text = "Time:";
            // 
            // txtDay
            // 
            this.txtDay.Location = new System.Drawing.Point(51, 296);
            this.txtDay.Name = "txtDay";
            this.txtDay.ReadOnly = true;
            this.txtDay.Size = new System.Drawing.Size(48, 20);
            this.txtDay.TabIndex = 10;
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(144, 296);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(75, 20);
            this.txtTime.TabIndex = 11;
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(10, 187);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(42, 13);
            this.lblOutput.TabIndex = 12;
            this.lblOutput.Text = "Output:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslblStatus,
            this.tsStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 489);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(465, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslblStatus
            // 
            this.tslblStatus.Name = "tslblStatus";
            this.tslblStatus.Size = new System.Drawing.Size(42, 17);
            this.tslblStatus.Text = "Status:";
            // 
            // tsStatus
            // 
            this.tsStatus.Name = "tsStatus";
            this.tsStatus.Size = new System.Drawing.Size(79, 17);
            this.tsStatus.Text = "Disconnected";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(137, 35);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(87, 20);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(75, 38);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password:";
            // 
            // gcpNormalLighting
            // 
            this.gcpNormalLighting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcpNormalLighting.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.gcpNormalLighting.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.gcpNormalLighting.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gcpNormalLighting.ColorItemWidth = 10;
            gradientColorPickerItem17.Color = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(67)))), ((int)(((byte)(117)))));
            gradientColorPickerItem17.Position = 0.7757576F;
            gradientColorPickerItem18.Color = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(246)))), ((int)(((byte)(71)))));
            gradientColorPickerItem18.Position = 1F;
            gradientColorPickerItem19.Color = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(95)))), ((int)(((byte)(99)))));
            gradientColorPickerItem19.Position = 0.8909091F;
            this.gcpNormalLighting.Colors.Add(gradientColorPickerItem17);
            this.gcpNormalLighting.Colors.Add(gradientColorPickerItem18);
            this.gcpNormalLighting.Colors.Add(gradientColorPickerItem19);
            this.gcpNormalLighting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gcpNormalLighting.GradientLayoutSize = 20;
            this.gcpNormalLighting.Location = new System.Drawing.Point(6, 9);
            this.gcpNormalLighting.Margin = new System.Windows.Forms.Padding(6);
            this.gcpNormalLighting.MinimumColorCount = 3;
            this.gcpNormalLighting.Name = "gcpNormalLighting";
            gradientColorPickerItem20.Color = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(93)))), ((int)(((byte)(252)))));
            gradientColorPickerItem20.Position = 0.4939759F;
            this.gcpNormalLighting.SelectedColor = gradientColorPickerItem20;
            this.gcpNormalLighting.Size = new System.Drawing.Size(418, 50);
            this.gcpNormalLighting.TabIndex = 14;
            this.gcpNormalLighting.ColorMoved += new System.EventHandler(this.gcpLightingColors_ColorMoved);
            // 
            // pnlCurrentColor
            // 
            this.pnlCurrentColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlCurrentColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCurrentColor.Location = new System.Drawing.Point(246, 296);
            this.pnlCurrentColor.Name = "pnlCurrentColor";
            this.pnlCurrentColor.Size = new System.Drawing.Size(36, 36);
            this.pnlCurrentColor.TabIndex = 15;
            // 
            // cmbxControllerPort
            // 
            this.cmbxControllerPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxControllerPort.FormattingEnabled = true;
            this.cmbxControllerPort.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12",
            "COM13",
            "COM14",
            "COM15"});
            this.cmbxControllerPort.Location = new System.Drawing.Point(137, 60);
            this.cmbxControllerPort.Name = "cmbxControllerPort";
            this.cmbxControllerPort.Size = new System.Drawing.Size(87, 21);
            this.cmbxControllerPort.TabIndex = 16;
            // 
            // cmdStartStop
            // 
            this.cmdStartStop.Location = new System.Drawing.Point(303, 296);
            this.cmdStartStop.Name = "cmdStartStop";
            this.cmdStartStop.Size = new System.Drawing.Size(75, 23);
            this.cmdStartStop.TabIndex = 17;
            this.cmdStartStop.Text = "Start";
            this.cmdStartStop.UseVisualStyleBackColor = true;
            this.cmdStartStop.Click += new System.EventHandler(this.cmdStartStop_Click);
            // 
            // lblPos
            // 
            this.lblPos.AutoSize = true;
            this.lblPos.Location = new System.Drawing.Point(5, 126);
            this.lblPos.Name = "lblPos";
            this.lblPos.Size = new System.Drawing.Size(28, 13);
            this.lblPos.TabIndex = 18;
            this.lblPos.Text = "Pos:";
            // 
            // ipacServerIP
            // 
            this.ipacServerIP.AllowInternalTab = false;
            this.ipacServerIP.AutoHeight = true;
            this.ipacServerIP.BackColor = System.Drawing.SystemColors.Window;
            this.ipacServerIP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ipacServerIP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ipacServerIP.Location = new System.Drawing.Point(137, 9);
            this.ipacServerIP.Margin = new System.Windows.Forms.Padding(6);
            this.ipacServerIP.MinimumSize = new System.Drawing.Size(87, 20);
            this.ipacServerIP.Name = "ipacServerIP";
            this.ipacServerIP.ReadOnly = false;
            this.ipacServerIP.Size = new System.Drawing.Size(114, 20);
            this.ipacServerIP.TabIndex = 19;
            this.ipacServerIP.Text = "...";
            // 
            // nudDayNightLength
            // 
            this.nudDayNightLength.Location = new System.Drawing.Point(113, 24);
            this.nudDayNightLength.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.nudDayNightLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDayNightLength.Name = "nudDayNightLength";
            this.nudDayNightLength.Size = new System.Drawing.Size(58, 20);
            this.nudDayNightLength.TabIndex = 20;
            this.nudDayNightLength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudDayLightLength
            // 
            this.nudDayLightLength.Location = new System.Drawing.Point(291, 24);
            this.nudDayLightLength.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nudDayLightLength.Minimum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nudDayLightLength.Name = "nudDayLightLength";
            this.nudDayLightLength.Size = new System.Drawing.Size(64, 20);
            this.nudDayLightLength.TabIndex = 21;
            this.nudDayLightLength.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            // 
            // lblDayNightLength
            // 
            this.lblDayNightLength.AutoSize = true;
            this.lblDayNightLength.Location = new System.Drawing.Point(14, 26);
            this.lblDayNightLength.Name = "lblDayNightLength";
            this.lblDayNightLength.Size = new System.Drawing.Size(93, 13);
            this.lblDayNightLength.TabIndex = 22;
            this.lblDayNightLength.Text = "Day Night Length:";
            // 
            // lblDayLightLength
            // 
            this.lblDayLightLength.AutoSize = true;
            this.lblDayLightLength.Location = new System.Drawing.Point(194, 26);
            this.lblDayLightLength.Name = "lblDayLightLength";
            this.lblDayLightLength.Size = new System.Drawing.Size(91, 13);
            this.lblDayLightLength.TabIndex = 23;
            this.lblDayLightLength.Text = "Day Light Length:";
            // 
            // nudStartDay
            // 
            this.nudStartDay.Location = new System.Drawing.Point(49, 55);
            this.nudStartDay.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nudStartDay.Name = "nudStartDay";
            this.nudStartDay.Size = new System.Drawing.Size(48, 20);
            this.nudStartDay.TabIndex = 24;
            this.nudStartDay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudStartMinute
            // 
            this.nudStartMinute.Location = new System.Drawing.Point(244, 55);
            this.nudStartMinute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nudStartMinute.Name = "nudStartMinute";
            this.nudStartMinute.Size = new System.Drawing.Size(48, 20);
            this.nudStartMinute.TabIndex = 25;
            // 
            // lblStartDay
            // 
            this.lblStartDay.AutoSize = true;
            this.lblStartDay.Location = new System.Drawing.Point(14, 57);
            this.lblStartDay.Name = "lblStartDay";
            this.lblStartDay.Size = new System.Drawing.Size(29, 13);
            this.lblStartDay.TabIndex = 26;
            this.lblStartDay.Text = "Day:";
            // 
            // lblStartMinute
            // 
            this.lblStartMinute.AutoSize = true;
            this.lblStartMinute.Location = new System.Drawing.Point(196, 57);
            this.lblStartMinute.Name = "lblStartMinute";
            this.lblStartMinute.Size = new System.Drawing.Size(42, 13);
            this.lblStartMinute.TabIndex = 27;
            this.lblStartMinute.Text = "Minute:";
            // 
            // cmdStartTimeReset
            // 
            this.cmdStartTimeReset.Location = new System.Drawing.Point(305, 52);
            this.cmdStartTimeReset.Name = "cmdStartTimeReset";
            this.cmdStartTimeReset.Size = new System.Drawing.Size(50, 23);
            this.cmdStartTimeReset.TabIndex = 28;
            this.cmdStartTimeReset.Text = "Reset";
            this.cmdStartTimeReset.UseVisualStyleBackColor = true;
            this.cmdStartTimeReset.Click += new System.EventHandler(this.cmdStartTimeReset_Click);
            // 
            // nudStartHour
            // 
            this.nudStartHour.Location = new System.Drawing.Point(142, 55);
            this.nudStartHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.nudStartHour.Name = "nudStartHour";
            this.nudStartHour.Size = new System.Drawing.Size(48, 20);
            this.nudStartHour.TabIndex = 29;
            // 
            // lblStartHour
            // 
            this.lblStartHour.AutoSize = true;
            this.lblStartHour.Location = new System.Drawing.Point(103, 57);
            this.lblStartHour.Name = "lblStartHour";
            this.lblStartHour.Size = new System.Drawing.Size(33, 13);
            this.lblStartHour.TabIndex = 30;
            this.lblStartHour.Text = "Hour:";
            // 
            // grpbxManualSettings
            // 
            this.grpbxManualSettings.Controls.Add(this.lblDayNightLength);
            this.grpbxManualSettings.Controls.Add(this.lblStartHour);
            this.grpbxManualSettings.Controls.Add(this.nudDayNightLength);
            this.grpbxManualSettings.Controls.Add(this.nudStartHour);
            this.grpbxManualSettings.Controls.Add(this.nudDayLightLength);
            this.grpbxManualSettings.Controls.Add(this.cmdStartTimeReset);
            this.grpbxManualSettings.Controls.Add(this.lblDayLightLength);
            this.grpbxManualSettings.Controls.Add(this.lblStartMinute);
            this.grpbxManualSettings.Controls.Add(this.nudStartDay);
            this.grpbxManualSettings.Controls.Add(this.lblStartDay);
            this.grpbxManualSettings.Controls.Add(this.nudStartMinute);
            this.grpbxManualSettings.Location = new System.Drawing.Point(13, 87);
            this.grpbxManualSettings.Name = "grpbxManualSettings";
            this.grpbxManualSettings.Size = new System.Drawing.Size(366, 93);
            this.grpbxManualSettings.TabIndex = 31;
            this.grpbxManualSettings.TabStop = false;
            this.grpbxManualSettings.Text = "Manual Settings";
            // 
            // gcpBloodMoonLighting
            // 
            this.gcpBloodMoonLighting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcpBloodMoonLighting.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.gcpBloodMoonLighting.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.gcpBloodMoonLighting.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gcpBloodMoonLighting.ColorItemWidth = 10;
            gradientColorPickerItem21.Color = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(156)))), ((int)(((byte)(142)))));
            gradientColorPickerItem21.Position = 0.9515151F;
            gradientColorPickerItem22.Color = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(67)))), ((int)(((byte)(93)))));
            gradientColorPickerItem22.Position = 0.4545455F;
            gradientColorPickerItem23.Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(174)))), ((int)(((byte)(251)))));
            gradientColorPickerItem23.Position = 0.2909091F;
            this.gcpBloodMoonLighting.Colors.Add(gradientColorPickerItem21);
            this.gcpBloodMoonLighting.Colors.Add(gradientColorPickerItem22);
            this.gcpBloodMoonLighting.Colors.Add(gradientColorPickerItem23);
            this.gcpBloodMoonLighting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gcpBloodMoonLighting.GradientLayoutSize = 20;
            this.gcpBloodMoonLighting.Location = new System.Drawing.Point(6, 71);
            this.gcpBloodMoonLighting.Margin = new System.Windows.Forms.Padding(6);
            this.gcpBloodMoonLighting.MinimumColorCount = 3;
            this.gcpBloodMoonLighting.Name = "gcpBloodMoonLighting";
            gradientColorPickerItem24.Color = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(93)))), ((int)(((byte)(252)))));
            gradientColorPickerItem24.Position = 0.4939759F;
            this.gcpBloodMoonLighting.SelectedColor = gradientColorPickerItem24;
            this.gcpBloodMoonLighting.Size = new System.Drawing.Size(418, 50);
            this.gcpBloodMoonLighting.TabIndex = 32;
            // 
            // dgvLightingTableNormal
            // 
            this.dgvLightingTableNormal.AllowUserToAddRows = false;
            this.dgvLightingTableNormal.AllowUserToDeleteRows = false;
            this.dgvLightingTableNormal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLightingTableNormal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTime,
            this.colColorNormal});
            this.dgvLightingTableNormal.Location = new System.Drawing.Point(8, 157);
            this.dgvLightingTableNormal.Name = "dgvLightingTableNormal";
            this.dgvLightingTableNormal.ReadOnly = true;
            this.dgvLightingTableNormal.RowHeadersVisible = false;
            this.dgvLightingTableNormal.Size = new System.Drawing.Size(205, 241);
            this.dgvLightingTableNormal.TabIndex = 33;
            // 
            // cmdBuild
            // 
            this.cmdBuild.Location = new System.Drawing.Point(349, 404);
            this.cmdBuild.Name = "cmdBuild";
            this.cmdBuild.Size = new System.Drawing.Size(75, 23);
            this.cmdBuild.TabIndex = 34;
            this.cmdBuild.Text = "Build";
            this.cmdBuild.UseVisualStyleBackColor = true;
            this.cmdBuild.Click += new System.EventHandler(this.cmdBuild_Click);
            // 
            // colTime
            // 
            this.colTime.HeaderText = "Time";
            this.colTime.Name = "colTime";
            this.colTime.ReadOnly = true;
            // 
            // colColorNormal
            // 
            this.colColorNormal.HeaderText = "Normal";
            this.colColorNormal.Name = "colColorNormal";
            this.colColorNormal.ReadOnly = true;
            // 
            // dgvLightingTableBloodMoon
            // 
            this.dgvLightingTableBloodMoon.AllowUserToAddRows = false;
            this.dgvLightingTableBloodMoon.AllowUserToDeleteRows = false;
            this.dgvLightingTableBloodMoon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLightingTableBloodMoon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTimeBM,
            this.colColorBM});
            this.dgvLightingTableBloodMoon.Location = new System.Drawing.Point(219, 157);
            this.dgvLightingTableBloodMoon.Name = "dgvLightingTableBloodMoon";
            this.dgvLightingTableBloodMoon.ReadOnly = true;
            this.dgvLightingTableBloodMoon.RowHeadersVisible = false;
            this.dgvLightingTableBloodMoon.Size = new System.Drawing.Size(205, 241);
            this.dgvLightingTableBloodMoon.TabIndex = 35;
            // 
            // colTimeBM
            // 
            this.colTimeBM.HeaderText = "Time";
            this.colTimeBM.Name = "colTimeBM";
            this.colTimeBM.ReadOnly = true;
            // 
            // colColorBM
            // 
            this.colColorBM.HeaderText = "Blood Moon";
            this.colColorBM.Name = "colColorBM";
            this.colColorBM.ReadOnly = true;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabSync);
            this.tabControl.Controls.Add(this.tabLightingTable);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(441, 465);
            this.tabControl.TabIndex = 36;
            // 
            // tabSync
            // 
            this.tabSync.Controls.Add(this.lblHostname);
            this.tabSync.Controls.Add(this.txtOutput);
            this.tabSync.Controls.Add(this.lblController);
            this.tabSync.Controls.Add(this.txtPassword);
            this.tabSync.Controls.Add(this.lblPassword);
            this.tabSync.Controls.Add(this.grpbxManualSettings);
            this.tabSync.Controls.Add(this.lblPort);
            this.tabSync.Controls.Add(this.ipacServerIP);
            this.tabSync.Controls.Add(this.txtPort);
            this.tabSync.Controls.Add(this.cmdConnectDisconnect);
            this.tabSync.Controls.Add(this.cmdStartStop);
            this.tabSync.Controls.Add(this.lblDay);
            this.tabSync.Controls.Add(this.cmbxControllerPort);
            this.tabSync.Controls.Add(this.lblTime);
            this.tabSync.Controls.Add(this.pnlCurrentColor);
            this.tabSync.Controls.Add(this.txtDay);
            this.tabSync.Controls.Add(this.txtTime);
            this.tabSync.Controls.Add(this.lblOutput);
            this.tabSync.Location = new System.Drawing.Point(4, 22);
            this.tabSync.Name = "tabSync";
            this.tabSync.Padding = new System.Windows.Forms.Padding(3);
            this.tabSync.Size = new System.Drawing.Size(433, 439);
            this.tabSync.TabIndex = 0;
            this.tabSync.Text = "Sync";
            this.tabSync.UseVisualStyleBackColor = true;
            // 
            // tabLightingTable
            // 
            this.tabLightingTable.Controls.Add(this.dgvLightingTableNormal);
            this.tabLightingTable.Controls.Add(this.gcpBloodMoonLighting);
            this.tabLightingTable.Controls.Add(this.dgvLightingTableBloodMoon);
            this.tabLightingTable.Controls.Add(this.lblPos);
            this.tabLightingTable.Controls.Add(this.cmdBuild);
            this.tabLightingTable.Controls.Add(this.gcpNormalLighting);
            this.tabLightingTable.Location = new System.Drawing.Point(4, 22);
            this.tabLightingTable.Name = "tabLightingTable";
            this.tabLightingTable.Padding = new System.Windows.Forms.Padding(3);
            this.tabLightingTable.Size = new System.Drawing.Size(433, 439);
            this.tabLightingTable.TabIndex = 1;
            this.tabLightingTable.Text = "Lighting Table";
            this.tabLightingTable.UseVisualStyleBackColor = true;
            // 
            // SevenDaysLightSyncApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 511);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip1);
            this.MinimumSize = new System.Drawing.Size(481, 550);
            this.Name = "SevenDaysLightSyncApp";
            this.Text = "Light Sync";
            this.Load += new System.EventHandler(this.SevenDaysLightSyncApp_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDayNightLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDayLightLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartHour)).EndInit();
            this.grpbxManualSettings.ResumeLayout(false);
            this.grpbxManualSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLightingTableNormal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLightingTableBloodMoon)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabSync.ResumeLayout(false);
            this.tabSync.PerformLayout();
            this.tabLightingTable.ResumeLayout(false);
            this.tabLightingTable.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label lblController;
        private System.Windows.Forms.Label lblHostname;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button cmdConnectDisconnect;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.TextBox txtDay;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslblStatus;
        private System.Windows.Forms.ToolStripStatusLabel tsStatus;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Panel pnlCurrentColor;
        private System.Windows.Forms.ComboBox cmbxControllerPort;
        private System.Windows.Forms.Button cmdStartStop;
        private System.Windows.Forms.Label lblPos;
        private IPAddressControlLib.IPAddressControl ipacServerIP;
        private System.Windows.Forms.NumericUpDown nudDayNightLength;
        private System.Windows.Forms.NumericUpDown nudDayLightLength;
        private System.Windows.Forms.Label lblDayNightLength;
        private System.Windows.Forms.Label lblDayLightLength;
        private System.Windows.Forms.NumericUpDown nudStartDay;
        private System.Windows.Forms.NumericUpDown nudStartMinute;
        private System.Windows.Forms.Label lblStartDay;
        private System.Windows.Forms.Label lblStartMinute;
        private System.Windows.Forms.Button cmdStartTimeReset;
        private System.Windows.Forms.NumericUpDown nudStartHour;
        private System.Windows.Forms.Label lblStartHour;
        private System.Windows.Forms.GroupBox grpbxManualSettings;
        private System.Windows.Forms.GradientColorPicker gcpNormalLighting;
        private System.Windows.Forms.GradientColorPicker gcpBloodMoonLighting;
        private System.Windows.Forms.DataGridView dgvLightingTableNormal;
        private System.Windows.Forms.Button cmdBuild;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColorNormal;
        private System.Windows.Forms.DataGridView dgvLightingTableBloodMoon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimeBM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColorBM;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabSync;
        private System.Windows.Forms.TabPage tabLightingTable;
    }
}

