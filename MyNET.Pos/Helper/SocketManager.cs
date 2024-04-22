using Newtonsoft.Json;
using SocketIOClient;
using System;
using Quobject.SocketIoClientDotNet.Client;
using System.Windows.Markup;

namespace SocketClient
{
    public class SocketManager
    {
        
        private static SocketIO socket;

        public static void Connect(string serverUrl)
        {
            socket = new SocketIO(serverUrl);

            socket.On(Socket.EVENT_CONNECT, (server) =>
            {
                Console.WriteLine("Connected to server");
            });


            socket.On("PosTotal", (server) =>
            {
                Console.WriteLine("Done");
                
            });

            socket.ConnectAsync();

        }

        public static void EmitQueryResponse(string data)
        {
            socket.EmitAsync("query response", data);
        }

        public static void EmitTableInfo(string data)
        {
            socket.EmitAsync("table info", data);
        }
        public static void EmitTotalSum(string data)
        {
            socket.EmitAsync("PosTotal", data);
        }
    }
}
