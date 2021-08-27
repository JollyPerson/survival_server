using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

public class Packet
{
    public PacketType Type { get; set; }
    public PacketData Data { get; set; }
    

    public static Packet Deserialize(IEnumerable<byte> data)
    {
        var byteData = data.Skip(sizeof(int))
            .Decrypt()
            .Decompress()
            .ToArray();

        var content = Encoding.ASCII.GetString(byteData);
        Console.WriteLine(content);
        Packet packet = JsonConvert.DeserializeObject<Packet>(content, new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        });
        return packet;
    }

    public byte[] Serialize()
    {   
        string data = JsonConvert.SerializeObject(this, new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        });

        byte[] byteData = Encoding.ASCII.GetBytes(data)
            .Compress()
            .Encrypt()
            .PrependLength()
            .ToArray();
        
        return byteData;
    }
}