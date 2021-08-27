namespace Survival_Game_Server.Packet.data
{
    public class ClientInitPacketData : PacketData
    {
        public int id;
        public string name;
        public int skin;
        public bool isOwner;

        public ClientInitPacketData(int id, string name, int skin, bool isOwner)
        {
            this.id = id;
            this.name = name;
            this.skin = skin;
            this.isOwner = isOwner;
        }

        
    }
}