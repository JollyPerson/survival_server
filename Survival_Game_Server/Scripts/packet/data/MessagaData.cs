using System;
public class MessageData : PacketData
{

    public String Message { get; set; }

    public MessageData(String data)
    {
        this.Message = data;
    }
}
