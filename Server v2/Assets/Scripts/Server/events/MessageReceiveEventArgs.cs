namespace Survival_Game_Server.events
{
    public class MessageReceiveEventArgs
    {
        public MessagePacketData data { get; set; }

        public MessageReceiveEventArgs(MessagePacketData data)
        {
            this.data = data;
            
        }
    }
}