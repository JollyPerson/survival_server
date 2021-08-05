using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaymakNetwork;

namespace Survival_Game_Server
{
    internal enum ClientPackets
    {
        Ping = 1,
    }

    internal static class NetworkReceive
    {
        internal static void PacketRouter()
        {
            NetworkConfig.socket.PacketId[(int)ClientPackets.Ping] = PacketPing;
        }

        private static void PacketPing(int connectionID, ref byte[] data)
        {
            ByteBuffer buffer = new ByteBuffer(data);
            string msg = buffer.ReadString();
            Console.WriteLine(msg);
            GameManager.CreatePlayer(connectionID);
            buffer.Dispose();
        }
    }
}