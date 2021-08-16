using System;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;

using System.Linq;

public class Packet
{
    public PacketType Type { get; set; }
    public PacketData Data { get; set; }

    public static Packet Deserialize(IEnumerable<byte> data)
    {
        var byteData = data.Skip(sizeof(int)).ToArray();
        byteData.Decrypt()
                .Decompress()
                .ToArray();

        var content = Encoding.ASCII.GetString(byteData);

        Packet packet = JsonConvert.DeserializeObject<Packet>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });

        return packet;
    }

    internal byte[] Serialize()
    {
        string data = JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });

        byte[] byteData = Encoding.ASCII.GetBytes(data)
                    .Compress()
                    .Encrypt()
                    .PrependLength()
                    .ToArray();

        return byteData;
    }

    
}

