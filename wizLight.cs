using OpenWiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WizControl
{
    internal class wizLight
    {
        public string friendlyName { get; private set; }
        public string macAddress { get; private set; }
        public IPAddress address { get; private set; }

        public int dimming { get; private set; }
        public int temp { get; private set; }
        public int rssi { get; private set; }
        public bool power { get; private set; }
        public int R { get; private set; }
        public int G { get; private set; }
        public int B { get; private set; }

        private WizSocket socket { get; set; }
        private WizHandle handle { get; set; }

        /// <summary>
        /// Wiz Light
        /// </summary>
        /// <param name="friendlyName">Friendly name of light</param>
        /// <param name="macAddress">Mac address of light</param>
        /// <param name="address">Ip Address of light</param>
        public wizLight(string friendlyName, string macAddress, IPAddress address)
        {
            this.friendlyName = friendlyName;
            this.macAddress = macAddress;
            this.address = address;

            this.socket = new WizSocket();
            this.socket.GetSocket().ReceiveTimeout = 1000;

            this.handle = new WizHandle(macAddress.ToLower(), address);
        }

        public void retrieveValues()
        {
            WizState state = new WizState
            {
                Method = WizMethod.getPilot
            };

            socket.SendTo(state, handle);

            WizResult result;
            
            try
            {
                state = socket.ReceiveFrom(handle);
            }
            catch
            {
                return;
            }

            result = state.Result;

            dimming = Convert.ToInt32(result.Dimming);
            temp = Convert.ToInt32(result.Temp);
            rssi = Convert.ToInt32(result.RSSI);
            power = Convert.ToBoolean(result.State);
            
            R = Convert.ToInt32(result.R);
            G = Convert.ToInt32(result.G);
            B = Convert.ToInt32(result.B);
        }

        public void setValuesTemp(int _dimming, int _temp)
        {
            WizState state = new WizState
            {
                Method = WizMethod.setPilot,
                Params = new WizParams
                {
                    State = power,
                    Dimming = _dimming,
                    Speed = 20,
                    Temp = _temp
                }
            };

            socket.SendTo(state, handle);
            WizResult result;
            try
            {
                state = socket.ReceiveFrom(handle);
                result = state.Result;
            }
            catch
            {

            }
        }

        public void setValuesRGB(int _R, int _G, int _B)
        {
            WizState state = new WizState
            {
                Method = WizMethod.setPilot,
                Params = new WizParams
                {
                    State = power,
                    Speed = 20,
                    R = _R,
                    G = _G,
                    B = _B
                }
            };

            socket.SendTo(state, handle);
            WizResult result;
            try
            {
                state = socket.ReceiveFrom(handle);
                result = state.Result;
            }
            catch
            {

            }
        }

        public void changePower (bool action)
        {
            power = action;
            if (R == 0 && G == 0 && B == 0) setValuesTemp(dimming, temp);
            else setValuesRGB(R, G, B);
        }
       
    }
}
