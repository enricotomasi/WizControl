using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Reflection;

namespace WizControl
{
    public partial class wizControl : Form
    {
        private string regKey = @"SOFTWARE\WizControl";
        private string regLamp = @"SOFTWARE\WizControl\lamps";
        private string regConfig = @"SOFTWARE\WizControl\config";
        private string projectWebSite = "https://github.com/enricotomasi/WizControl";
        private static bool RGBMode = false;
        private static bool controlsActive = false;
        ToolTip toolTipWiFi = new ToolTip();
        private bool power = false;
        private wizLight lamp;
        private Dictionary<string, IPAddress> lights = new Dictionary<string, IPAddress>();
        private ContextMenu notifyIconContextMenu = new ContextMenu();

        public wizControl()
        {
            InitializeComponent();
        }

        private void wizControl_Load(object sender, EventArgs e)
        {
            refreshLights();
            initializeRegKeys();
            inizializeNotifyIcon();
        }

        private void initializeRegKeys()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(regKey);
            RegistryKey keyLamp = Registry.CurrentUser.CreateSubKey(regLamp);

            key.SetValue("LastRun", DateTime.Now.ToString("yyyy MM dd HH:mm:ss.fffffff"));
            keyLamp.SetValue("000000000000", "testLight");
            key.Close();
            keyLamp.Close();
        }

        private void inizializeNotifyIcon()
        {
            string v = System.Windows.Forms.Application.ProductVersion;
            notifyIconContextMenu.MenuItems.Add("Show &window", this.notifyShowWindows_Click);
            notifyIconContextMenu.MenuItems.Add("&About", this.notifyAbout_Click);
            notifyIconContextMenu.MenuItems.Add("E&xit", this.notifyClose_Click);

            notifyIcon1.ContextMenu = notifyIconContextMenu;
            notifyIcon1.Text = "WizControl " + v;
            notifyIcon1.BalloonTipTitle = "WizControl " + v;
            notifyIcon1.BalloonTipText = "Click to open application";
            notifyIcon1.Visible = true;
        }

        private void notifyShowWindows_Click(object sender, EventArgs e)
        {
            notifyIconShowWindow();
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            notifyIconShowWindow();
        }

        private void notifyClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            notifyIconShowWindow();
        }

        private void notifyAbout_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(projectWebSite);
        }

        private void notifyIconShowWindow()
        {
            this.Show();
            notifyIcon1.Visible = true;
        }

        private void showNotifyIconHideWindow()
        {
            //notifyIcon1.Visible = true;
            this.Hide();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            refreshLights();
        }

        private void wizControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                showNotifyIconHideWindow();
                e.Cancel = true;
            }
        }

        private async void refreshLights()
        {
            string loadingString = "Finding lights...";

            if (findLights.isRunning)
            {
                errorMessage("Antoher scanning process is already running...");
                return;
            }

            int selIndex = lightSelector.SelectedIndex;
            var config = new configuration(regConfig);
            lights = config.load();
            
            lightSelector.DataSource = null;
            lightSelector.Items.Clear();

            if (lights.Count > 0)
            {
                populateComboLights();
            }
            else
            {
                lightSelector.Items.Add(loadingString);
            }    
            
            if (selIndex != -1 && lightSelector.Items.Count > selIndex) lightSelector.SelectedIndex = selIndex;
            else if (lightSelector.Items.Count > 0 ) lightSelector.SelectedIndex = 0;
            else lightSelector.SelectedIndex = -1;

            lights.Clear();
            
            await Task.Factory.StartNew(() =>
            {
                findLights.isRunning = true;
                this.Invoke((MethodInvoker)(() => refresh.Enabled = false));
                lights = findLights.findAllSubnet();
            })
            .ContinueWith(result =>
            {
                findLights.isRunning = false;
                this.Invoke((MethodInvoker)(() => refresh.Enabled = true));
                this.Invoke((MethodInvoker)(() => populateComboLights()));
                config.save(lights);
            });
        }

        private void populateComboLights()
        {
            int selIndex = lightSelector.SelectedIndex;
            lightSelector.DataSource = null;
            lightSelector.Items.Clear();

            int count = 0;
            var lightObjects = new List<wizLight>();

            RegistryKey key = Registry.CurrentUser.OpenSubKey(regLamp);
            foreach (var light in lights)
            {
                string macAddress = light.Key;
                IPAddress address = light.Value;

                string friendlyName = $"Light N. {count} - {macAddress}";

                if (key != null && key.GetValue(macAddress) != null)
                {
                    friendlyName = key.GetValue(macAddress).ToString();
                }

                var tempLight = new wizLight(friendlyName, macAddress, address);
                lightObjects.Add(tempLight);
                count++;
            }

            lightSelector.ValueMember = null;
            lightSelector.DisplayMember = "friendlyName";
            lightSelector.DataSource = lightObjects;

            if (lightSelector.Items.Count > 0)
            {
                if (selIndex != -1 && lightSelector.Items.Count > selIndex) lightSelector.SelectedIndex = selIndex;
                else lightSelector.SelectedIndex = 0;
            }
            else
            {
                lightSelector.DataSource = null;
                lightSelector.Items.Add("No lights founds :-(");
                lightSelector.SelectedIndex = 0;
            }

            if (key != null) key.Close();
        }

        private async void lightSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            lamp = (wizLight)lightSelector.SelectedValue;
            updateLampInterface(lamp);
        }

        private async void updateLampInterface(wizLight lamp)
        {
            if (lamp != null)
            {
                lamp.retrieveValues();
                if (lamp.dimming >= 10 && lamp.dimming <= 100)
                {
                    dimming.Value = lamp.dimming;
                    dimmingText.Text = lamp.dimming.ToString();
                }

                if (lamp.temp >= 2700 && lamp.temp <= 6500)
                {
                    temperature.Value = lamp.temp;
                    temperatureText.Text = lamp.temp.ToString();
                }

                if (lamp.R >= 1 && lamp.R <= 255)
                {
                    R.Value = lamp.R;
                    RText.Text = lamp.R.ToString();
                }

                if (lamp.G >= 1 && lamp.G <= 255)
                {
                    G.Value = lamp.G;
                    GText.Text = lamp.G.ToString();
                }

                if (lamp.B >= 1 && lamp.B <= 255)
                {
                    B.Value = lamp.B;
                    BText.Text = lamp.B.ToString();
                }

                int rssi = lamp.rssi;
                int signal = 0;

                if (rssi <= -100)
                    signal = 1;
                else if (rssi >= -50)
                    signal = 100;
                else
                    signal = 2 * (rssi + 100);

                if (signal > 0 && signal <= 100) wifiSignal.Value = signal;

                toolTipWiFi.SetToolTip(wifiSignal, rssi.ToString() + " db");

                RGBMode = !(lamp.R == 0 && lamp.G == 0 && lamp.B == 0);
                power = lamp.power;

                enableControls(true);
                this.Refresh();
            }
            else
            {
                enableControls(false);
            }
        }

        private void enableControls(bool action)
        {
            controlsActive = action;
            ren.Enabled = action;
            powerButton.Enabled = action;
            changePowerButtonColor();

            if (action)
            {
                enaRGB(RGBMode);
            }
            else
            {
                dimming.Enabled = false;
                dimmingText.Enabled = false;
                dimmingLabel.Enabled = false;
                dimming10.Enabled = false;
                dimming50.Enabled = false;
                dimming100.Enabled = false;
                temperature.Enabled = false;
                temperatureText.Enabled = false;
                temperatureLabel.Enabled = false;
                tempCold.Enabled = false;
                tempSun.Enabled = false;
                tempWarm.Enabled = false;
                R.Enabled = false;
                RText.Enabled = false;
                G.Enabled = false;
                GText.Enabled = false;
                B.Enabled = false;
                BText.Enabled = false;
                enableRGB.Enabled = false;
                enableRGB.Checked = false;
                wifiSignal.Value = 0;
                wifiSignalLabel.Enabled = false;
                toolTipWiFi.SetToolTip(wifiSignal, "");
            }
        }

        private void changePowerButtonColor()
        {
            if (!controlsActive) powerButton.BackColor = DefaultBackColor;
            else if (power) powerButton.BackColor = Color.Green;
            else powerButton.BackColor = Color.Red;
        }

        private void dimming_Scroll(object sender, EventArgs e)
        {
            dimmingText.Text = dimming.Value.ToString();
            writeValuesToLamp();
        }

        private void dimmingText_Leave(object sender, EventArgs e)
        {
            updateDimmingControls();
        }

        private void dimmingText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                updateDimmingControls();
                e.Handled = true;
            }
        }

        private void dimming10_Click(object sender, EventArgs e)
        {
            dimming.Value = 10;
            dimmingText.Text = "10";
            writeValuesToLamp();
            this.Refresh();
        }

        private void dimming50_Click(object sender, EventArgs e)
        {
            dimming.Value = 50;
            dimmingText.Text = "50";
            writeValuesToLamp();
            this.Refresh();
        }

        private void dimming100_Click(object sender, EventArgs e)
        {
            dimming.Value = 100;
            dimmingText.Text = "100";
            writeValuesToLamp();
            this.Refresh();
        }

        private void updateDimmingControls()
        {
            int dimUserInput = 0;

            if (int.TryParse(dimmingText.Text, out dimUserInput) &&
                dimUserInput >= 10 &&
                dimUserInput <= 100)
            {
                dimming.Value = dimUserInput;
                writeValuesToLamp();
            }
            else dimmingText.Text = dimming.Value.ToString();

            this.Refresh();
        }

        private void temperature_Scroll(object sender, EventArgs e)
        {
            temperatureText.Text = temperature.Value.ToString();
            writeValuesToLamp();
        }

        private void updateTemperatureControl()
        {
            int dimUserInput = 0;

            if (int.TryParse(temperatureText.Text, out dimUserInput) &&
                dimUserInput >= 2700 &&
                dimUserInput <= 6500)
            {
                temperature.Value = dimUserInput;
                writeValuesToLamp();
            }
            else temperatureText.Text = temperature.Value.ToString();
            this.Refresh();

        }

        private void temperatureText_Leave(object sender, EventArgs e)
        {
            updateTemperatureControl();
        }

        private void temperatureText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                updateTemperatureControl();
                e.Handled = true;
            }
        }

        private void tempWarm_Click(object sender, EventArgs e)
        {
            temperature.Value = 2700;
            temperatureText.Text = "2700";
            writeValuesToLamp();
            this.Refresh();
        }

        private void tempSun_Click(object sender, EventArgs e)
        {
            temperature.Value = 4250;
            temperatureText.Text = "4250";
            writeValuesToLamp();
            this.Refresh();
        }

        private void tempCold_Click(object sender, EventArgs e)
        {
            temperature.Value = 6500;
            temperatureText.Text = "6500";
            writeValuesToLamp();
            this.Refresh();
        }

        private void enableRGB_CheckedChanged(object sender, EventArgs e)
        {
            if (enableRGB.Checked) enaRGB(true);
            else enaRGB(false);
        }

        private void enaRGB(bool action)
        {
            dimming.Enabled = !action;
            dimmingText.Enabled = !action;
            dimmingLabel.Enabled = !action;
            dimming10.Enabled = !action;
            dimming50.Enabled = !action;
            dimming100.Enabled = !action;
            temperature.Enabled = !action;
            temperatureText.Enabled = !action;
            temperatureLabel.Enabled = !action;
            tempCold.Enabled = !action;
            tempSun.Enabled = !action;
            tempWarm.Enabled = !action;
            wifiSignalLabel.Enabled = !action;
            R.Enabled = action;
            RText.Enabled = action;
            G.Enabled = action;
            GText.Enabled = action;
            B.Enabled = action;
            BText.Enabled = action;
            enableRGB.Enabled = true;
            enableRGB.Checked = action;
            writeValuesToLamp();

            if (!action)
            {
                R.Value = 1;
                G.Value = 1;
                B.Value = 1;
                RText.Text = "";
                GText.Text = "";
                BText.Text = "";
            }
        }

        private void R_Scroll(object sender, EventArgs e)
        {
            RText.Text = R.Value.ToString();
            writeValuesToLamp();
        }

        private void G_Scroll(object sender, EventArgs e)
        {
            GText.Text = G.Value.ToString();
            writeValuesToLamp();
        }

        private void B_Scroll(object sender, EventArgs e)
        {
            BText.Text = B.Value.ToString();
            writeValuesToLamp();
        }

        private void RText_Leave(object sender, EventArgs e)
        {
            updateRControl();
        }

        private void GText_Leave(object sender, EventArgs e)
        {
            updateGControl();
        }

        private void BText_Leave(object sender, EventArgs e)
        {
            updateBControl(); 
        }

        private void RText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                updateRControl();
                e.Handled = true;
            }
        }

        private void GText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                updateGControl();
                e.Handled = true;
            }
        }

        private void BText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                updateBControl();
                e.Handled = true;
            }
        }

        private void updateRControl()
        {
            int dimUserInput = 0;

            if (int.TryParse(RText.Text, out dimUserInput) &&
                dimUserInput >= 1 &&
                dimUserInput <= 255)
            {
                R.Value = dimUserInput;
                writeValuesToLamp();
            }
            else RText.Text = R.Value.ToString();

            this.Refresh();
        }

        private void updateGControl()
        {
            int dimUserInput = 0;

            if (int.TryParse(GText.Text, out dimUserInput) &&
                dimUserInput >= 1 &&
                dimUserInput <= 255)
            {
                G.Value = dimUserInput;
                writeValuesToLamp();
            }
            else GText.Text = G.Value.ToString();

            this.Refresh();
        }

        private void updateBControl()
        {
            int dimUserInput = 0;

            if (int.TryParse(BText.Text, out dimUserInput) &&
                dimUserInput >= 1 &&
                dimUserInput <= 255)
            {
                B.Value = dimUserInput;
                writeValuesToLamp();
            }
            else BText.Text = B.Value.ToString();

            this.Refresh();
        }

        private void writeValuesToLamp()
        {
            if (lamp != null)
            {
                if (enableRGB.Checked)  lamp.setValuesRGB(R.Value, G.Value, B.Value);
                else                    lamp.setValuesTemp(dimming.Value, temperature.Value);
            }
        }

        private void ren_Click(object sender, EventArgs e)
        {
            try
            {
                renameLamp();
            }
            catch (Exception ex)
            {
                errorMessage(ex.Message);
                return;
            }

            populateComboLights();
            this.Refresh();
        }

        private void renameLamp()
        {
            string newName = lightSelector.Text;
            string oldName = lamp.friendlyName;
            string macAddr = lamp.macAddress;
            IPAddress ipAddr = lamp.address;

            if (newName == oldName)
            {
                throw new ArgumentException("The new name is the same as the old!");
            }

            RegistryKey key = Registry.CurrentUser.CreateSubKey(regLamp);
                        
            key.SetValue(macAddr, newName);
            key.Close();
        }

        private void updateLightsValues()
        {
            if (lamp != null)
            {
                lamp.retrieveValues();
                updateLampInterface(lamp);
                this.Refresh();
            }
        }

        private void powerButton_Click(object sender, EventArgs e)
        {
            power = !power;
            lamp.changePower(power);
            changePowerButtonColor();
        }

        private void errorMessage(string msg)
        {
            MessageBox.Show(msg, "WizControl", MessageBoxButtons.OK);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            updateLightsValues();
        }

    }
}
