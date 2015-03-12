using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace BridgeLibrary
{
    public class Bridge
    {
        public delegate Packet BridgeDelegate(Packet command);

        public static void receiveCommand(int port,BridgeDelegate bridgeDelegate)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Any, port);
            tcpListener.Start();
            TcpClient client = tcpListener.AcceptTcpClient();

            NetworkStream clientStream = client.GetStream();

            byte[] data = new byte[1024];

            int receivedDataLength = clientStream.Read(data, 0, data.Length);
            string commandData = Encoding.UTF8.GetString(data, 0, receivedDataLength);
            
            Packet command = JsonConvert.DeserializeObject<Packet>(commandData);
            Packet returnCommand = bridgeDelegate(command);

            string returnCommandData = JsonConvert.SerializeObject(returnCommand);

            
            clientStream.Write(Encoding.UTF8.GetBytes(returnCommandData), 0, returnCommandData.Length);

            clientStream.Flush();

            client.Close();
            tcpListener.Stop();

        }

    }
}
