internal class PlayerEventArgs
{
    public NetworkPlayer Player;

    public PlayerEventArgs(NetworkPlayer player)
    {
        this.Player = player;
    }
}