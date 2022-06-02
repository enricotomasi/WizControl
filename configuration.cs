using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WizControl
{
    internal class configuration
    {
        private string regkey = "";
        
        public configuration(string reg)
        {
            regkey = reg;
            RegistryKey key = Registry.CurrentUser.CreateSubKey(reg);
        }

        public Dictionary<string, IPAddress> load()
        {
            var ans = new Dictionary<string, IPAddress>();
            RegistryKey key = Registry.CurrentUser.OpenSubKey(regkey, true);

            foreach (string s in key.GetValueNames())
            {
                ans.Add(s, IPAddress.Parse(key.GetValue(s).ToString()));
            }

            return ans;
        }

        public void save(Dictionary<string, IPAddress> lights)
        {
            clear();
            foreach (var light in lights)
            {
                string mac = light.Key;
                string ip = light.Value.ToString();

                RegistryKey key = Registry.CurrentUser.OpenSubKey(regkey, true);
                key.SetValue(mac, ip);
            }
        }

        private void clear()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(regkey, true);
            var keys = key.GetValueNames();
            foreach (string value in keys)
            {
                key.DeleteValue(value);
            }
        }

    }
}
