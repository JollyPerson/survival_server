namespace Survival_Game_Server.events
{
    public class HeartBeatEventArgs
    {
        public HeartbeatPacketData data { get; set; }
        public int senderID { get; set; }

        public HeartBeatEventArgs(HeartbeatPacketData data, int senderId)
        {
            this.data = data;
            this.senderID = senderId;
        }
    }
}