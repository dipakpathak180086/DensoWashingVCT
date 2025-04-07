using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Serilog;

public class MyTcpClient : IDisposable
{
    string _IP = "";
    int _Port = 0;
    TcpClient client = default(TcpClient);
    NetworkStream stream = null;
    public MyTcpClient(string IP, int Port)
    {
        _IP = IP;
        _Port = Port;
        Connect();
    }

    private bool Connect()
    {
        bool flag = false;
        try
        {

            client = new TcpClient();
            client.ReceiveTimeout = 10000;
            if (CheckPinging())
            {
                flag = true;
                client.Connect(IPAddress.Parse(_IP), _Port);
                stream = client.GetStream();
            }
            else
            {
                flag = false;
            }
        }
        catch (Exception ex)
        {
           // GlobalVar.Logger.LogMessage(EventNotice.EventTypes.evtError, $"clsPCL-Connect():{_IP}:{_Port}", $"Error:{ex.ToString()}");
        }
        return flag;
    }

    private bool CheckPinging()
    {
        try
        {
            Ping ping = new Ping();
            PingReply reply = ping.Send(_IP, 30);
            return reply.Status == IPStatus.Success;
        }
        catch (Exception ex)
        {
            //GlobalVar.Logger.LogMessage(EventNotice.EventTypes.evtError, $"clsPCL-CheckPinging():{_IP}:{_Port}", $"Error:{ex.ToString()}");
            return false;
        }
    }

    public bool GetServerStatus()
    {
        try
        {
            if (client.Connected)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            //GlobalVar.Logger.LogMessage(EventNotice.EventTypes.evtError, $"clsPCL-GetPLCStatus():{_IP}:{_Port}", $"Error:{ex.ToString()}");
            return false;
        }
    }

    public string GetServerInput()
    {
        string strData = "";
        try
        {
            byte[] data = new byte[1024];
            int size = stream.Read(data, 0, data.Length);
            if (size == 0)
            {
                throw new Exception("Re-Connecting...");
            }
            strData = Encoding.ASCII.GetString(data);
        }
        catch (Exception ex)
        {
            //GlobalVar.Logger.LogMessage(EventNotice.EventTypes.evtError, $"clsPCL-GetPLCInput():{_IP}:{_Port}", $"Error:{ex.ToString()}");
            try
            {
                client.Close();
                Connect();
            }
            catch (NullReferenceException e)
            {
               // GlobalVar.Logger.LogMessage(EventNotice.EventTypes.evtError, $"clsPCL-GetPLCInput()-NullReferenceException:{_IP}:{_Port}", $"Error:{e.ToString()}");
            }
        }

        return strData.Replace("\0", "");
    }
    public void WriteToServer(string clientData)
    {

        if (clientData == "")
            return;
        try
        {
            byte[] data = Encoding.ASCII.GetBytes(clientData);
            stream.Write(data, 0, data.Length);

        }
        catch (Exception ex)
        {
            Log.Error(ex, "Exception Occured");
            try
            {
                client.Close();
                Connect();
            }
            catch (NullReferenceException e)
            {
                //GlobalVar.Logger.LogMessage(EventNotice.EventTypes.evtError, $"clsPCL-GetPLCInput()-NullReferenceException:{_IP}:{_Port}", $"Error:{e.ToString()}");
            }
        }
    }

    public void Dispose()
    {
        if (client.Connected)
        {
            stream.Close();
            client.Close();
        }
        stream = null;
        client = null;
        _IP = "";
        _Port = 0;
    }
}

