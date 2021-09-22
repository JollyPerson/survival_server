using System;
using Survival_Game_Server.events;

namespace Survival_Game_Server.listener
{
    public class MessageSubscriber
    {
        

        public void OnMessageReceiveEvent(PacketEventArgs args)
        {
            MessagePacketData data = (MessagePacketData)args.Packet.Data; 
            Console.WriteLine(data.Message);
    }
    }
}