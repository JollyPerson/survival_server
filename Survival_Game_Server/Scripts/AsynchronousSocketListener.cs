using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Linq;
using UnityEngine;

public class AsynchronousSocketListener
{
    public ManualResetEvent allDone = new ManualResetEvent(false);

    internal event PlayerConnectedEvent OnPlayerConnected;
    internal event PlayerDisconnectedEvent OnPlayerDisconnected;
    internal event PacketReceivedEvent OnPacketReceived;
    internal event PacketSentEvent OnPacketSent;

    public long TotalBytesSent = 0;
    public long TotalBytesReceived = 0;

    public AsynchronousSocketListener() { }


    public void StartListening()
    {
        IPAddress ip = IPAddress.Parse("127.0.0.1");
        IPEndPoint localEndpoint = new IPEndPoint(ip, 8001);

        Socket listener = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

        try
        {
            listener.Bind(localEndpoint);
            listener.Listen(100);
            Debug.Log("Listen server started.");

            while (true)
            {
                allDone.Reset();
                listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
                allDone.WaitOne();
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
        }
    }
    internal void Send(NetworkPlayer player, Packet obj)
    {
        byte[] data = obj.Serialize();
        Socket socket = player.Connection.Socket;
        socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), new SendCallbackArgs { Player = player, Packet = obj });

    }
    private void AcceptCallback(IAsyncResult ar)
    {
        allDone.Set();
        Socket listener = (Socket)ar.AsyncState;
        Socket handler = listener.EndAccept(ar);

        NetworkPlayer player = new NetworkPlayer();
        player.Connection.Socket = handler;
        handler.BeginReceive(player.Connection.Buffer, 0, Connection.BufferSize, SocketFlags.None, new AsyncCallback(ReadCallback), player);
        OnPlayerConnected?.Invoke(this, new PlayerEventArgs(player));
    }
    private void ReadCallback(IAsyncResult ar)
    {
        NetworkPlayer player = (NetworkPlayer)ar.AsyncState;
        Socket handler = player.Connection.Socket;

        int bytesRead = 0;
        try
        {
            bytesRead = handler.EndReceive(ar);
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
            OnPlayerDisconnected?.Invoke(this, new PlayerEventArgs(player));
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
        }

        TotalBytesReceived += bytesRead;

        if (bytesRead > 0)
        {
            player.Connection.Message.AddRange(player.Connection.Buffer.Take(bytesRead));

            int byteCount = BitConverter.ToInt32(player.Connection.Message.Take(sizeof(Int32)).ToArray(), 0);
            if (player.Connection.Message.Count == byteCount + sizeof(Int32))
            {
                Packet p = Packet.Deserialize(player.Connection.Message);
                OnPacketReceived?.Invoke(this, new PacketEventArgs { Packet = p, Player = player });
                player.Connection.Message.Clear();

            }
            handler.BeginReceive(player.Connection.Buffer, 0, Connection.BufferSize, SocketFlags.None, new AsyncCallback(ReadCallback), player);
        }
        else
        {
            OnPlayerDisconnected?.Invoke(this, new PlayerEventArgs(player));
            handler.Close();
        }
    }
    private void SendCallback(IAsyncResult ar)
    {
        SendCallbackArgs args = (SendCallbackArgs)ar.AsyncState;

        NetworkPlayer player = args.Player;
        Socket socket = player.Connection.Socket;
        int bytesSent = 0;

        try
        {
            bytesSent = socket.EndSend(ar);

        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
            OnPlayerDisconnected.Invoke(this, new PlayerEventArgs(player));
        }

        TotalBytesSent += bytesSent;
        OnPacketSent?.Invoke(this, new PacketEventArgs { Player = player, Packet = args.Packet });
    }



    private class SendCallbackArgs
    {
        public NetworkPlayer Player { get; internal set; }
        public Packet Packet { get; internal set; }
    }

    internal delegate void PlayerConnectedEvent(object sender, PlayerEventArgs player);
    internal delegate void PlayerDisconnectedEvent(object seender, PlayerEventArgs player);
    internal delegate void PacketReceivedEvent(object sender, PacketEventArgs args);
    internal delegate void PacketSentEvent(object sender, PacketEventArgs args);
}

