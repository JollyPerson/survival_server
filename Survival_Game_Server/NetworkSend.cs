using System;
using KaymakNetwork;

namespace Survival_Game_Server
{
    internal enum ServerPacket
    {
        WelcomeMsg = 1,
        InstantiatePlayer,
    }

    internal static class NetworkSend
    {
        public static void WelcomeMsg(int connectionID, string message)
        {
            ByteBuffer buffer = new ByteBuffer(4);
            buffer.WriteInt32((int)ServerPacket.WelcomeMsg);
            buffer.WriteString(message);
            NetworkConfig.socket.SendDataTo(connectionID, buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        private static ByteBuffer PlayerData(int connectionID, Player player)
        {
            ByteBuffer buffer = new ByteBuffer(4);
            buffer.WriteInt32((int)ServerPacket.InstantiatePlayer);
            buffer.WriteInt32(connectionID);
            return buffer;
        }

        public static void InstantiateNetworkPlayer(int connectionID, Player player)
        {
            for (int i = 1; i <= GameManager.playerList.Count; i++)
            {
                if (GameManager.playerList[i] != null)
                {
                    if (GameManager.playerList[i].inGame)
                    {
                        if (i != connectionID)
                        {
                            NetworkConfig.socket.SendDataTo(connectionID, PlayerData(i, player).Data, PlayerData(i, player).Head);
                        }
                    }
                }
            }

            NetworkConfig.socket.SendDataToAll(PlayerData(connectionID, player).Data, PlayerData(connectionID, player).Head);
        }
    }
}