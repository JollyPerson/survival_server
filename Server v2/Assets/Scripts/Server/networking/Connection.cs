using System.Net.Sockets;
using System.Collections.Generic;

public class Connection
{
    public Socket Socket { get; set; }
    public const int BufferSize = 1024;
    public byte[] Buffer = new byte[BufferSize];
    public List<byte> Message = new List<byte>();
}