namespace WizControl
{
    partial class wizControl
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wizControl));
            this.lightSelector = new System.Windows.Forms.ComboBox();
            this.refresh = new System.Windows.Forms.Button();
            this.ren = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.temperatureLabel = new System.Windows.Forms.Label();
            this.tempSun = new System.Windows.Forms.Button();
            this.tempCold = new System.Windows.Forms.Button();
            this.tempWarm = new System.Windows.Forms.Button();
            this.temperatureText = new System.Windows.Forms.TextBox();
            this.temperature = new System.Windows.Forms.TrackBar();
            this.dimmingLabel = new System.Windows.Forms.Label();
            this.dimming50 = new System.Windows.Forms.Button();
            this.dimming100 = new System.Windows.Forms.Button();
            this.dimming10 = new System.Windows.Forms.Button();
            this.dimmingText = new System.Windows.Forms.TextBox();
            this.dimming = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.enableRGB = new System.Windows.Forms.CheckBox();
            this.B = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.BText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.GText = new System.Windows.Forms.TextBox();
            this.G = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.RText = new System.Windows.Forms.TextBox();
            this.R = new System.Windows.Forms.TrackBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.powerButton = new System.Windows.Forms.Button();
            this.wifiSignalLabel = new System.Windows.Forms.Label();
            this.wifiSignal = new System.Windows.Forms.ProgressBar();
            this.updateLights = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.temperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dimming)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.B)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.G)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.R)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lightSelector
            // 
            this.lightSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lightSelector.FormattingEnabled = true;
            this.lightSelector.Location = new System.Drawing.Point(12, 12);
            this.lightSelector.Name = "lightSelector";
            this.lightSelector.Size = new System.Drawing.Size(206, 26);
            this.lightSelector.TabIndex = 0;
            this.lightSelector.SelectedIndexChanged += new System.EventHandler(this.lightSelector_SelectedIndexChanged);
            // 
            // refresh
            // 
            this.refresh.Image = global::WizControl.Properties.Resources.Refresh_grey_16x;
            this.refresh.Location = new System.Drawing.Point(293, 12);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(27, 26);
            this.refresh.TabIndex = 2;
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // ren
            // 
            this.ren.Enabled = false;
            this.ren.Location = new System.Drawing.Point(224, 12);
            this.ren.Name = "ren";
            this.ren.Size = new System.Drawing.Size(63, 26);
            this.ren.TabIndex = 1;
            this.ren.Text = "RENAME";
            this.ren.UseVisualStyleBackColor = true;
            this.ren.Click += new System.EventHandler(this.ren_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.temperatureLabel);
            this.groupBox1.Controls.Add(this.tempSun);
            this.groupBox1.Controls.Add(this.tempCold);
            this.groupBox1.Controls.Add(this.tempWarm);
            this.groupBox1.Controls.Add(this.temperatureText);
            this.groupBox1.Controls.Add(this.temperature);
            this.groupBox1.Controls.Add(this.dimmingLabel);
            this.groupBox1.Controls.Add(this.dimming50);
            this.groupBox1.Controls.Add(this.dimming100);
            this.groupBox1.Controls.Add(this.dimming10);
            this.groupBox1.Controls.Add(this.dimmingText);
            this.groupBox1.Controls.Add(this.dimming);
            this.groupBox1.Location = new System.Drawing.Point(12, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 203);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // temperatureLabel
            // 
            this.temperatureLabel.AutoSize = true;
            this.temperatureLabel.Location = new System.Drawing.Point(77, 108);
            this.temperatureLabel.Name = "temperatureLabel";
            this.temperatureLabel.Size = new System.Drawing.Size(67, 13);
            this.temperatureLabel.TabIndex = 11;
            this.temperatureLabel.Text = "Temperature";
            // 
            // tempSun
            // 
            this.tempSun.Enabled = false;
            this.tempSun.Location = new System.Drawing.Point(78, 162);
            this.tempSun.Name = "tempSun";
            this.tempSun.Size = new System.Drawing.Size(44, 23);
            this.tempSun.TabIndex = 5;
            this.tempSun.Text = "SUN";
            this.tempSun.UseVisualStyleBackColor = true;
            this.tempSun.Click += new System.EventHandler(this.tempSun_Click);
            // 
            // tempCold
            // 
            this.tempCold.Enabled = false;
            this.tempCold.Location = new System.Drawing.Point(169, 162);
            this.tempCold.Name = "tempCold";
            this.tempCold.Size = new System.Drawing.Size(46, 23);
            this.tempCold.TabIndex = 4;
            this.tempCold.Text = "COLD";
            this.tempCold.UseVisualStyleBackColor = true;
            this.tempCold.Click += new System.EventHandler(this.tempCold_Click);
            // 
            // tempWarm
            // 
            this.tempWarm.Enabled = false;
            this.tempWarm.Location = new System.Drawing.Point(4, 162);
            this.tempWarm.Name = "tempWarm";
            this.tempWarm.Size = new System.Drawing.Size(56, 23);
            this.tempWarm.TabIndex = 7;
            this.tempWarm.Text = "WARM";
            this.tempWarm.UseVisualStyleBackColor = true;
            this.tempWarm.Click += new System.EventHandler(this.tempWarm_Click);
            // 
            // temperatureText
            // 
            this.temperatureText.Enabled = false;
            this.temperatureText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.temperatureText.Location = new System.Drawing.Point(231, 124);
            this.temperatureText.MaxLength = 4;
            this.temperatureText.Name = "temperatureText";
            this.temperatureText.Size = new System.Drawing.Size(65, 24);
            this.temperatureText.TabIndex = 3;
            this.temperatureText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.temperatureText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.temperatureText_KeyUp);
            this.temperatureText.Leave += new System.EventHandler(this.temperatureText_Leave);
            // 
            // temperature
            // 
            this.temperature.Enabled = false;
            this.temperature.Location = new System.Drawing.Point(4, 124);
            this.temperature.Maximum = 6500;
            this.temperature.Minimum = 2700;
            this.temperature.Name = "temperature";
            this.temperature.Size = new System.Drawing.Size(221, 45);
            this.temperature.SmallChange = 50;
            this.temperature.TabIndex = 2;
            this.temperature.Value = 2700;
            this.temperature.Scroll += new System.EventHandler(this.temperature_Scroll);
            // 
            // dimmingLabel
            // 
            this.dimmingLabel.AutoSize = true;
            this.dimmingLabel.Location = new System.Drawing.Point(87, 16);
            this.dimmingLabel.Name = "dimmingLabel";
            this.dimmingLabel.Size = new System.Drawing.Size(47, 13);
            this.dimmingLabel.TabIndex = 5;
            this.dimmingLabel.Text = "Dimming";
            // 
            // dimming50
            // 
            this.dimming50.Enabled = false;
            this.dimming50.Location = new System.Drawing.Point(90, 70);
            this.dimming50.Name = "dimming50";
            this.dimming50.Size = new System.Drawing.Size(32, 23);
            this.dimming50.TabIndex = 11;
            this.dimming50.Text = "50";
            this.dimming50.UseVisualStyleBackColor = true;
            this.dimming50.Click += new System.EventHandler(this.dimming50_Click);
            // 
            // dimming100
            // 
            this.dimming100.Enabled = false;
            this.dimming100.Location = new System.Drawing.Point(178, 70);
            this.dimming100.Name = "dimming100";
            this.dimming100.Size = new System.Drawing.Size(37, 23);
            this.dimming100.TabIndex = 9;
            this.dimming100.Text = "100";
            this.dimming100.UseVisualStyleBackColor = true;
            this.dimming100.Click += new System.EventHandler(this.dimming100_Click);
            // 
            // dimming10
            // 
            this.dimming10.Enabled = false;
            this.dimming10.Location = new System.Drawing.Point(4, 70);
            this.dimming10.Name = "dimming10";
            this.dimming10.Size = new System.Drawing.Size(32, 23);
            this.dimming10.TabIndex = 1;
            this.dimming10.Text = "10";
            this.dimming10.UseVisualStyleBackColor = true;
            this.dimming10.Click += new System.EventHandler(this.dimming10_Click);
            // 
            // dimmingText
            // 
            this.dimmingText.Enabled = false;
            this.dimmingText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dimmingText.Location = new System.Drawing.Point(231, 32);
            this.dimmingText.MaxLength = 3;
            this.dimmingText.Name = "dimmingText";
            this.dimmingText.Size = new System.Drawing.Size(65, 24);
            this.dimmingText.TabIndex = 1;
            this.dimmingText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dimmingText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dimmingText_KeyUp);
            this.dimmingText.Leave += new System.EventHandler(this.dimmingText_Leave);
            // 
            // dimming
            // 
            this.dimming.Enabled = false;
            this.dimming.Location = new System.Drawing.Point(4, 32);
            this.dimming.Maximum = 100;
            this.dimming.Minimum = 10;
            this.dimming.Name = "dimming";
            this.dimming.Size = new System.Drawing.Size(221, 45);
            this.dimming.SmallChange = 5;
            this.dimming.TabIndex = 0;
            this.dimming.Value = 10;
            this.dimming.Scroll += new System.EventHandler(this.dimming_Scroll);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.enableRGB);
            this.groupBox2.Controls.Add(this.B);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.BText);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.GText);
            this.groupBox2.Controls.Add(this.G);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.RText);
            this.groupBox2.Controls.Add(this.R);
            this.groupBox2.Location = new System.Drawing.Point(12, 264);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(192, 165);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // enableRGB
            // 
            this.enableRGB.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.enableRGB.AutoSize = true;
            this.enableRGB.Enabled = false;
            this.enableRGB.Location = new System.Drawing.Point(40, 17);
            this.enableRGB.Name = "enableRGB";
            this.enableRGB.Size = new System.Drawing.Size(85, 17);
            this.enableRGB.TabIndex = 20;
            this.enableRGB.Text = "Enable RGB";
            this.enableRGB.UseVisualStyleBackColor = true;
            this.enableRGB.CheckedChanged += new System.EventHandler(this.enableRGB_CheckedChanged);
            // 
            // B
            // 
            this.B.Enabled = false;
            this.B.Location = new System.Drawing.Point(30, 115);
            this.B.Maximum = 255;
            this.B.Minimum = 1;
            this.B.Name = "B";
            this.B.Size = new System.Drawing.Size(104, 45);
            this.B.SmallChange = 15;
            this.B.TabIndex = 4;
            this.B.Value = 1;
            this.B.Scroll += new System.EventHandler(this.B_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "B";
            // 
            // BText
            // 
            this.BText.Enabled = false;
            this.BText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BText.Location = new System.Drawing.Point(137, 115);
            this.BText.MaxLength = 3;
            this.BText.Name = "BText";
            this.BText.Size = new System.Drawing.Size(44, 24);
            this.BText.TabIndex = 5;
            this.BText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BText_KeyUp);
            this.BText.Leave += new System.EventHandler(this.BText_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "G";
            // 
            // GText
            // 
            this.GText.Enabled = false;
            this.GText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GText.Location = new System.Drawing.Point(137, 78);
            this.GText.MaxLength = 3;
            this.GText.Name = "GText";
            this.GText.Size = new System.Drawing.Size(44, 24);
            this.GText.TabIndex = 3;
            this.GText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.GText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GText_KeyUp);
            this.GText.Leave += new System.EventHandler(this.GText_Leave);
            // 
            // G
            // 
            this.G.Enabled = false;
            this.G.Location = new System.Drawing.Point(30, 78);
            this.G.Maximum = 255;
            this.G.Minimum = 1;
            this.G.Name = "G";
            this.G.Size = new System.Drawing.Size(104, 45);
            this.G.SmallChange = 15;
            this.G.TabIndex = 2;
            this.G.Value = 1;
            this.G.Scroll += new System.EventHandler(this.G_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "R";
            // 
            // RText
            // 
            this.RText.Enabled = false;
            this.RText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RText.Location = new System.Drawing.Point(137, 42);
            this.RText.MaxLength = 3;
            this.RText.Name = "RText";
            this.RText.Size = new System.Drawing.Size(44, 24);
            this.RText.TabIndex = 1;
            this.RText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RText_KeyUp);
            this.RText.Leave += new System.EventHandler(this.RText_Leave);
            // 
            // R
            // 
            this.R.Enabled = false;
            this.R.Location = new System.Drawing.Point(30, 42);
            this.R.Maximum = 255;
            this.R.Minimum = 1;
            this.R.Name = "R";
            this.R.Size = new System.Drawing.Size(104, 45);
            this.R.SmallChange = 15;
            this.R.TabIndex = 0;
            this.R.Value = 1;
            this.R.Scroll += new System.EventHandler(this.R_Scroll);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.powerButton);
            this.groupBox3.Controls.Add(this.wifiSignalLabel);
            this.groupBox3.Controls.Add(this.wifiSignal);
            this.groupBox3.Location = new System.Drawing.Point(211, 264);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(109, 165);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            // 
            // powerButton
            // 
            this.powerButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("powerButton.BackgroundImage")));
            this.powerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.powerButton.Enabled = false;
            this.powerButton.Location = new System.Drawing.Point(16, 75);
            this.powerButton.Name = "powerButton";
            this.powerButton.Size = new System.Drawing.Size(76, 70);
            this.powerButton.TabIndex = 2;
            this.powerButton.UseVisualStyleBackColor = true;
            this.powerButton.Click += new System.EventHandler(this.powerButton_Click);
            // 
            // wifiSignalLabel
            // 
            this.wifiSignalLabel.AutoSize = true;
            this.wifiSignalLabel.Location = new System.Drawing.Point(8, 17);
            this.wifiSignalLabel.Name = "wifiSignalLabel";
            this.wifiSignalLabel.Size = new System.Drawing.Size(95, 13);
            this.wifiSignalLabel.TabIndex = 1;
            this.wifiSignalLabel.Text = "Light WiFi strenght";
            // 
            // wifiSignal
            // 
            this.wifiSignal.Location = new System.Drawing.Point(6, 39);
            this.wifiSignal.Name = "wifiSignal";
            this.wifiSignal.Size = new System.Drawing.Size(97, 23);
            this.wifiSignal.TabIndex = 0;
            // 
            // updateLights
            // 
            this.updateLights.Enabled = true;
            this.updateLights.Interval = 10000;
            this.updateLights.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // wizControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 439);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ren);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.lightSelector);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "wizControl";
            this.Text = "Wiz Control";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wizControl_FormClosing);
            this.Load += new System.EventHandler(this.wizControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.temperature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dimming)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.B)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.G)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.R)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox lightSelector;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.Button ren;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button dimming50;
        private System.Windows.Forms.Button dimming100;
        private System.Windows.Forms.Button dimming10;
        private System.Windows.Forms.TextBox dimmingText;
        private System.Windows.Forms.TrackBar dimming;
        private System.Windows.Forms.Label temperatureLabel;
        private System.Windows.Forms.Button tempSun;
        private System.Windows.Forms.Button tempCold;
        private System.Windows.Forms.Button tempWarm;
        private System.Windows.Forms.TextBox temperatureText;
        private System.Windows.Forms.TrackBar temperature;
        private System.Windows.Forms.Label dimmingLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TrackBar B;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox BText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox GText;
        private System.Windows.Forms.TrackBar G;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox RText;
        private System.Windows.Forms.TrackBar R;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox enableRGB;
        private System.Windows.Forms.Label wifiSignalLabel;
        private System.Windows.Forms.ProgressBar wifiSignal;
        private System.Windows.Forms.Timer updateLights;
        private System.Windows.Forms.Button powerButton;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

