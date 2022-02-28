using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


class Class_IPConfirm
{
    /// <summary>
    /// Ping网络
    /// </summary>
    /// <param name="IP"></param>
    /// <returns></returns>
    public static bool PingIPTest(string IP)
    {
        try
        {
            IPAddress address = null;
            if (IPAddress.TryParse(IP, out address))
            {
                System.Net.NetworkInformation.Ping pingSender = new System.Net.NetworkInformation.Ping();
                int timeout = 20;
                System.Net.NetworkInformation.PingReply relay = pingSender.Send(address, timeout);
                if (relay.Status == System.Net.NetworkInformation.IPStatus.Success)
                {
                    pingSender.Dispose();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
        catch
        {

            return false;
        }

    }
}

