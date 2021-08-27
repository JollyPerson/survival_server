namespace Survival_Game_Server.Packet.data
{
    public class UpdateNamePacketData : PacketData
    {
        public string newName;

        public UpdateNamePacketData(string newName)
        {
            this.newName = newName;
        }
    }
}