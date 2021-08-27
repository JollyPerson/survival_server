using Survival_Game_Server.Packet.data;

namespace Survival_Game_Server.events
{
    public class ClientInputEventArgs
    {
        public ClientInputPacketData data { get; set; }

        public ClientInputEventArgs(ClientInputPacketData data)
        {
            this.data = data;
        }
    }
}