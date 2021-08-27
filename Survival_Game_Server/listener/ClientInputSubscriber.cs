using System;
using Survival_Game_Server.Packet.data;

namespace Survival_Game_Server.listener


{
    using Survival_Game_Server.events;
    public class ClientInputSubscriber
    {

        public void OnClientInput(PacketEventArgs args)
        {
            ClientInputPacketData data = (ClientInputPacketData) args.Packet.Data;
            Console.WriteLine(data.movement.ToString());
        }
    }
}