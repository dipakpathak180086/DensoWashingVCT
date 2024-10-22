using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using DENSO_VCT_COMMON;

namespace DENSO_VCT_APP
{
    class clsTCPClient
    {
        string _IP = "";
        int _Port = 0;

        public clsTCPClient(string IP, int Port)
        {
            _IP = IP;
            _Port = Port;


        }

        public bool CheckPLCAndScannerPinging(string ip)
        {
            try
            {
                Ping ping = new Ping();
                PingReply reply = ping.Send(ip, 30);
                return reply.Status == IPStatus.Success;
            }
            catch (Exception ex)
            {
                return false;
            }
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
                return false;
            }
        }

        /// <summary>
        /// Commented by dipak 19_11_22 for case hanged issue
        /// </summary>
        /// <returns></returns>
        //public async Task<string> GetScannerData()
        //{

        //    string strData = "";
        //    //if (!client.Connected)
        //    //{
        //    //    if(!Connect())
        //    //    throw new Exception("Scanner not connected.");
        //    //}

        //    await Task.Run(() =>
        //    {
        //        try
        //        {
        //            while (strData == "")
        //            {
        //                try
        //                {
        //                    using (TcpClient client = new TcpClient())
        //                    {
        //                        client.ReceiveTimeout = 10000;

        //                        client.Connect(IPAddress.Parse(_IP), _Port);
        //                        using (NetworkStream stream = client.GetStream())
        //                        {
        //                            byte[] data = new byte[1024];
        //                            int size = stream.Read(data, 0, data.Length);
        //                            if (size != 0)
        //                            {
        //                                strData = Encoding.ASCII.GetString(data);
        //                                // throw new Exception("Re-Connecting...");
        //                            }

        //                        }

        //                    }
        //                }
        //                catch (System.IO.IOException ex)
        //                {

        //                    strData = "";
        //                }
        //            }


        //        }
        //        catch (System.Net.Sockets.SocketException ex)
        //        {
        //            strData = "Scanner not connected.";
        //        }
        //        catch (Exception ex)
        //        {

        //        }
        //    });

        //    return strData.Replace("\0", "");
        //}
        public async Task<string> GetScannerData()
        {

            string strData = "";
            //if (!client.Connected)
            //{
            //    if(!Connect())
            //    throw new Exception("Scanner not connected.");
            //}

            await Task.Run(() =>
            {
                try
                {
                    //while (strData == "")
                    //{
                    try
                    {
                        if (GlobalVariable.mCaseTcpClient == null)
                        {
                            GlobalVariable.mCaseTcpClient = new TcpClient();
                            GlobalVariable.mCaseTcpClient.ReceiveTimeout = 10000;
                            GlobalVariable.mCaseTcpClient.Connect(IPAddress.Parse(_IP), _Port);
                            //client.Connect("192.168.43.239", Convert.ToInt32("5150"));

                        }

                        //NetworkStream stream = Program.mCaseTcpClient.GetStream();


                        //byte[] data = new byte[1024];
                        //int size = stream.Read(data, 0, data.Length);
                        //if (size != 0)
                        //{
                        //    strData = Encoding.ASCII.GetString(data);
                        //    // throw new Exception("Re-Connecting...");
                        //}
                        while (strData=="")
                        {
                            try
                            {


                                byte[] bRes = new byte[1024];
                                int iLen = GlobalVariable.mCaseTcpClient.Client.Receive(bRes);
                                if (iLen != 0)
                                {
                                    strData = Encoding.ASCII.GetString(bRes, 0, iLen);
                                }
                            }
                            catch (Exception ex)
                            {

                                strData = "";
                            }
                        }




                    }
                    catch (System.IO.IOException ex)
                    {
                        GlobalVariable.mCaseTcpClient = null;
                        //  strData = "NRD";
                        strData = "";
                    }
                    //}


                }
                catch (System.Net.Sockets.SocketException ex)
                {
                    GlobalVariable.mCaseTcpClient = null;
                    //strData = "NRD";
                    strData = "";
                }
                catch (Exception ex)
                {
                    // strData = "NRD";
                    strData = "Scanner not connected.";
                    GlobalVariable.mCaseTcpClient = null;
                }
            });

            return strData.Replace("\0", "");
        }
     
        /// <summary>
        /// Commneted by dipak 18_11_22 for Case Hanged issue
        /// </summary>
        /// <param name="ErrorCode"></param>
        public void WriteToPLCFinal(string ErrorCode)
        {

            if (ErrorCode == "")
                return;
            try
            {
                using (TcpClient client = new TcpClient())
                {
                    client.ReceiveTimeout = 10000;

                    client.Connect(IPAddress.Parse(_IP), _Port);
                    using (NetworkStream stream = client.GetStream())
                    {
                        byte[] data = Encoding.ASCII.GetBytes(ErrorCode);
                        stream.Write(data, 0, data.Length);

                    }

                }


            }
            catch (Exception ex)
            {
                throw new Exception("PLC Not Connected.");
            }
        }

        //public void WriteToPLCFinal(string ErrorCode)
        //{

        //    if (ErrorCode == "")
        //        return;
        //    try
        //    {
        //        if (Program.mPLCTcpClient == null)
        //        {
        //            Program.mPLCTcpClient = new TcpClient();
        //            Program.mPLCTcpClient.ReceiveTimeout = 10000;
        //            Program.mPLCTcpClient.Connect(IPAddress.Parse(_IP), _Port);
        //            client.Connect("192.168.43.239", Convert.ToInt32("5150"));

        //        }

        //        using (NetworkStream stream = Program.mPLCTcpClient.GetStream())
        //        {
        //            byte[] data = Encoding.ASCII.GetBytes(ErrorCode);
        //            stream.Write(data, 0, data.Length);

        //        }




        //    }
        //    catch (Exception ex)
        //    {
        //        Program.mPLCTcpClient = null;
        //        throw new Exception("PLC Not Connected.");
        //    }
        //}
        public void WriteToPLC(byte MsgCode) //1 from OK and 2 For NG
        {

            // if (ErrorCode == "")
            //   return;
            try
            {
                using (TcpClient client = new TcpClient())
                {
                    client.ReceiveTimeout = 10000;

                    client.Connect(IPAddress.Parse(_IP), _Port);
                    using (NetworkStream stream = client.GetStream())
                    {
                        byte[] data = new byte[] { 80, 0, 0, 255, 255, 3, 0, 14, 0, 0, 0, 1, 20, 0, 0, 200, 0, 0, 168, 1, 0, 2, 0 }; //Encoding.ASCII.GetBytes(ErrorCode);
                        data[21] = MsgCode;
                        stream.Write(data, 0, data.Length);

                    }

                }
            }

            catch (Exception ex)
            {
                throw new Exception("PLC Not Connected.");
            }
        }

        public void WriteToPLCSetCamera(byte MsgCode)
        {

            // if (ErrorCode == "")
            //   return;
            try
            {
                using (TcpClient client = new TcpClient())
                {
                    client.ReceiveTimeout = 10000;

                    client.Connect(IPAddress.Parse(_IP), _Port);
                    using (NetworkStream stream = client.GetStream())
                    {
                        // byte[] data = new byte[] { 80, 0, 0, 255, 255, 3, 0, 34, 0, 0, 0, 1, 20, 0, 0, 200, 0, 0, 168, 11, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; 
                        // data[41] = MsgCode;
                        byte[] data = new byte[] { 80, 0, 0, 255, 255, 3, 0, 14, 0, 0, 0, 1, 20, 0, 0, 210, 0, 0, 168, 1, 0, 2, 0 }; //Encoding.ASCII.GetBytes(ErrorCode);
                        data[21] = MsgCode;
                        stream.Write(data, 0, data.Length);

                    }

                }
            }

            catch (Exception ex)
            {
                throw new Exception("PLC Not Connected.");
            }
        }
    }
}
