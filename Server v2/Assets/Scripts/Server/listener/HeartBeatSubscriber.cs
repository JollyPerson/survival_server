using Survival_Game_Server.events;

namespace Survival_Game_Server.listener
{
    public class HeartBeatSubscriber
    {
        public void OnHeartBeat(PacketEventArgs args)
        {
            HeartbeatPacketData packetData =(HeartbeatPacketData) args.Packet.Data;
        }
    }
}