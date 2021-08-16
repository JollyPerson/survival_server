
using System.Timers;
using System.Collections.Generic;
using System;

public class Program
{
    
    static List<NetworkPlayer> Players = new List<NetworkPlayer>();
    private static DateTime startTime = DateTime.Now;
    private static AsynchronousSocketListener listener = new AsynchronousSocketListener();
    public static void Main(string[] args)
    {
        Console.WriteLine("Logged");
        listener.OnPlayerConnected += (object sender, PlayerEventArgs e) =>
        {
            Console.WriteLine("Player added.");
            Players.Add(e.Player);
        };

        listener.OnPlayerDisconnected += (object sender, PlayerEventArgs e) =>
        {
            Console.WriteLine($"Player {e.Player.Id} disconnected");
            Players.Remove(e.Player);
        };

        Timer timer = new Timer(5000);
        timer.Elapsed += (object sender, ElapsedEventArgs e) =>
        {
            foreach (var player in Players)
            {
                listener.Send(player, new Packet() { Type = PacketType.HEARTBEAT, Data = new HeartbeatPacketData() });
            }
        };

        timer.Start();

        long lastTotalReceived = 0;
        long lastTotalSent = 0;

        Timer stats = new Timer(1000);
        stats.Elapsed += (object sender, ElapsedEventArgs e) =>
        {
            long currentReceived = listener.TotalBytesReceived - lastTotalReceived;
            lastTotalReceived = listener.TotalBytesReceived;

            long currentSent = listener.TotalBytesSent - lastTotalSent;
            lastTotalSent = listener.TotalBytesSent;

            double kbSent = listener.TotalBytesSent / 1000.0;
            double kbReceived = listener.TotalBytesReceived / 1000.0;

            double kbSecSent = currentSent / 1000.0;
            double kbSecReceived = currentReceived / 1000.0;

            string statString = $"Send: {kbSent.ToString("N2")} kb ({kbSecSent.ToString("N2")} kb/s) | Receive: {kbReceived.ToString("N2")} kb ({kbSecReceived.ToString("N2")} kb/s)";
            Console.WriteLine(statString);
            Console.Title = statString;
        };
        stats.Start();

        listener.StartListening();
        Console.WriteLine("Doing things..");
    }
}