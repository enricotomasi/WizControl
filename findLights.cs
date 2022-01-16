using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WizControl
{
    internal class findLights
    {
        private static Dictionary<string, IPAddress> result = new Dictionary<string, IPAddress>();
        private static IPAddress pcAddress;
        private static IPAddress startIP;
        private static IPAddress endIP;
        private static List<IPAddress> addresses;
        private static string subnet;
        private static string gateway;
        private static int subnetBits;

        public static Dictionary<string, IPAddress> findAllSubnet()
        {
            result.Clear();
            pcAddress = new IPAddress(new byte[] { 0, 0, 0, 0 });
            startIP = new IPAddress(new byte[] { 0, 0, 0, 0 });
            endIP = new IPAddress(new byte[] { 0, 0, 0, 0 });
            addresses = new List<IPAddress>();
            subnet = "";
            gateway = "";
            subnetBits = 0;

            findConnectionAddress();
            findSubnetAndGateway();
            convertSubnetDecimalToBits();
            findFirstAndLastAddress();
            findAllAddresses();
            parallelScanNetwork();

            return result;
        }

        private static void findConnectionAddress()
        {
            try
            {
                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
                {
                    socket.Connect("8.8.8.8", 1500); 
                    IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                    pcAddress = endPoint.Address;
                }
            }
            catch (Exception)
            {
                
            }
        }

        private static void findSubnetAndGateway()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection nics = mc.GetInstances();
            foreach (ManagementObject nic in nics)
            {
                if (Convert.ToBoolean(nic["ipEnabled"]) == true)
                {
                    string indirizzoTemp = (nic["IPAddress"] as String[])[0];
                    if (indirizzoTemp == pcAddress.ToString())
                    {
                        subnet = (nic["IPSubnet"] as String[])[0];
                        gateway = (nic["DefaultIPGateway"] as String[])[0];
                    }
                }
            }
        }

        private static void convertSubnetDecimalToBits()
        {
            foreach (string octet in subnet.Split('.'))
            {
                try
                {
                    byte octetByte = byte.Parse(octet);
                    while (octetByte != 0)
                    {
                        subnetBits += octetByte & 1;
                        octetByte >>= 1;
                    }
                }
                catch { }
            }
        }

        private static void findFirstAndLastAddress()
        {
            uint mask = ~(uint.MaxValue >> subnetBits);
            byte[] ipBytes = pcAddress.GetAddressBytes();
            byte[] maskBytes = BitConverter.GetBytes(mask).Reverse().ToArray();
            byte[] startIPBytes = new byte[ipBytes.Length];
            byte[] endIPBytes = new byte[ipBytes.Length];
            for (int i = 0; i < ipBytes.Length; i++)
            {
                startIPBytes[i] = (byte)(ipBytes[i] & maskBytes[i]);
                endIPBytes[i] = (byte)(ipBytes[i] | ~maskBytes[i]);
            }
            startIP = new IPAddress(startIPBytes);
            endIP = new IPAddress(endIPBytes);
        }

        private static void findAllAddresses()
        {
            byte[] startTemp = startIP.GetAddressBytes();
            byte[] endTemp = endIP.GetAddressBytes();
            byte[] startRevTemp = startTemp.Reverse().ToArray();
            byte[] endRevTemp = endTemp.Reverse().ToArray();
            int start = BitConverter.ToInt32(startRevTemp, 0);
            int end = BitConverter.ToInt32(endRevTemp, 0);
            for (int i = start; i <= end; i++)
            {
                byte[] bytes = BitConverter.GetBytes(i);
                addresses.Add(new IPAddress(new[] { bytes[3], bytes[2], bytes[1], bytes[0] }));
            }
        }

        private static async void parallelScanNetwork()
        {
            var tasks = new List<Task>();
            foreach (IPAddress address in addresses)
            {
                tasks.Add(Task.Run(() => scanNetwork(address)));
            }
            Task.WaitAll(tasks.ToArray());
        }

        private static void scanNetwork(IPAddress address)
        {
            Ping p = new Ping();
            PingReply r;
            PingOptions options = new PingOptions (64, true);
            r = p.Send(address,250);

            if (r.Status != IPStatus.Success) return;
            
            string macAddress = string.Empty;
            System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
            pProcess.StartInfo.FileName = "arp";
            pProcess.StartInfo.Arguments = "-a " + address;
            pProcess.StartInfo.UseShellExecute = false;
            pProcess.StartInfo.RedirectStandardOutput = true;
            pProcess.StartInfo.CreateNoWindow = true;
            pProcess.Start();
            string strOutput = pProcess.StandardOutput.ReadToEnd();
            string[] substrings = strOutput.Split('-');
            if (substrings.Length >= 8)
            {
                macAddress = substrings[3].Substring(Math.Max(0, substrings[3].Length - 2))
                            + substrings[4] + substrings[5] + substrings[6] + substrings[7]
                            + substrings[8].Substring(0, 2);

                if (macAddress.Substring(0, 6).ToLower() == "a8bb50")
                {
                    result.Add(macAddress, address);
                }
            }
        }

    }
}
