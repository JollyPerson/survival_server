namespace Survival_Game_Server.Packet.data
{
    public class ClientInputPacketData : PacketData
    {
        public MovementType movement { get; set; }

        public ClientInputPacketData(MovementType key)
        {
            this.movement = key;
        }

    }

    public enum MovementType
    {
        NONE,
        FORWARD,
        BACKWARD,
        LEFT,
        RIGHT,
        JUMP,
        SPRINT
    }

}