using System;

    public class MessagePacketData : PacketData
    {
        public String Message { get; set; }
        public MessagePacketData(String message)
        {
        this.Message = message;
        }
    }

