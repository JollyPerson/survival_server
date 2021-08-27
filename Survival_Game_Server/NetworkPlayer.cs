public class NetworkPlayer
{
    public int Id { get; set; }
    public static int _idSequence = 0;
    public int PacketNumber = 0;
    public string name;
    
    public Connection Connection { get; set; }

    public NetworkPlayer()
    {
        Connection = new Connection();
        Id = _idSequence++;
    }
}