// SerialPortManager.cs - central SerialPort handler
using DENSO_VCT_COMMON;
using System;
using System.IO.Ports;

public static class SerialPortManager
{
    public static SerialPort Port = new SerialPort();
    public static event SerialDataReceivedEventHandler DataReceived;

    private static int _users = 0;
    private static readonly object _lock = new object();

    static SerialPortManager()
    {
        try
        {
            Port.PortName = GlobalVariable.mKitScannerPort;
            Port.BaudRate = 9600;
            Port.Parity = Parity.None;
            Port.DataBits = 8;
            Port.StopBits = StopBits.One;
            Port.ReadTimeout = 1000;
            Port.WriteTimeout = 1000;
            Port.DataReceived += (s, e) => DataReceived?.Invoke(s, e);
        }
        catch (Exception ex)
        {
            // Optional: log or rethrow
        }
    }

    public static void AttachHandler(SerialDataReceivedEventHandler handler)
    {
        lock (_lock)
        {
            DataReceived += handler;
        }
    }

    public static void DetachHandler(SerialDataReceivedEventHandler handler)
    {
        lock (_lock)
        {
            DataReceived -= handler;
        }
    }

    public static void Open()
    {
        lock (_lock)
        {
            if (!Port.IsOpen)
            {
                Port.Open();
            }
            _users++;
        }
    }

    public static void Close()
    {
        lock (_lock)
        {
            _users--;
            if (_users <= 0 && Port.IsOpen)
            {
                Port.Close();
                Port.Dispose();
                _users = 0;
            }
        }
    }
}
