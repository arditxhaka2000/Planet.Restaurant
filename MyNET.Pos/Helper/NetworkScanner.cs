using System;
using System.Net;
using System.Net.Sockets;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using MyNET;
using System.Windows;

public class NetworkScanner
{
    private int _port;
    private string _scanEndpoint;
    private CancellationTokenSource _cancellationTokenSource;

    public NetworkScanner(int port, string scanEndpoint = "/")
    {
        _port = port;
        _scanEndpoint = scanEndpoint;
        _cancellationTokenSource = new CancellationTokenSource();
    }

    public async Task<string> ScanNetworkForServer()
    {
        string localIP = GetLocalIP();
        if (localIP == null)
        {
            Console.WriteLine("Error: No IP address found.");
            return null;
        }
        Console.WriteLine("Local IP Address: " + localIP);

        // Determine the subnet based on the local IP
        string[] ipParts = localIP.Split('.');
        string subnet = $"{ipParts[0]}.{ipParts[1]}.{ipParts[2]}";

        // Scan IP range in the subnet
        string startIP = subnet + ".1";   // Start from .1
        string endIP = subnet + ".254";   // End at .254

        uint start = IpToInt(IPAddress.Parse(startIP));
        uint end = IpToInt(IPAddress.Parse(endIP));

        string foundIP = null;
        var cancellationToken = _cancellationTokenSource.Token;

        // Launch tasks to scan the network
        var tasks = new Task[end - start + 1];
        for (uint ip = start; ip <= end; ip++)
        {
            if (_cancellationTokenSource.IsCancellationRequested)
            {
                break;
            }

            uint currentIP = ip;
            tasks[ip - start] = Task.Run(async () =>
            {
                string address = $"{IntToIp(currentIP)}:{_port}{_scanEndpoint}";
                Console.WriteLine($"Scanning {address}");

                if (!cancellationToken.IsCancellationRequested && await IsPortOpen(IntToIp(currentIP), _port, 1000))
                {
                    Console.WriteLine($"Port open at {address}");

                    using (HttpClient client = new HttpClient { Timeout = TimeSpan.FromMilliseconds(3000) })
                    {
                        try
                        {
                            var response = await client.GetStringAsync($"http://{IntToIp(currentIP)}:{_port}{_scanEndpoint}");
                            var result = JsonConvert.DeserializeObject<ServerResponse>(response);


                            if (result.Success == true)
                            {
                                Services.Connection.SetLocalServerIp($"{IntToIp(currentIP)}:{_port}");
                                var s = Services.Settings.Get();

                                if (result.Data[0].PIN == s.PIN)
                                {
                                    foundIP = $"{IntToIp(currentIP)}:{_port}";

                                    _cancellationTokenSource.Cancel();
                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Failed to connect to {address}: {ex.Message}");
                        }
                    }
                }
            }, cancellationToken);
        }

        try
        {
            await Task.WhenAll(tasks);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Task cancellation triggered, stopping scan.");
        }

        if (foundIP != null)
        {
            Console.WriteLine("Server found at " + foundIP);
            return foundIP;
        }
        else
        {
            Console.WriteLine("Server not found in the IP range");
            return null;
        }
    }

    private string GetLocalIP()
    {
        foreach (var ip in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }
        return null;
    }

    private uint IpToInt(IPAddress ip)
    {
        byte[] bytes = ip.GetAddressBytes();
        return (uint)(bytes[0] << 24 | bytes[1] << 16 | bytes[2] << 8 | bytes[3]);
    }

    private IPAddress IntToIp(uint ip)
    {
        return new IPAddress(new byte[] {
            (byte)(ip >> 24),
            (byte)(ip >> 16),
            (byte)(ip >> 8),
            (byte)(ip)
        });
    }

    private async Task<bool> IsPortOpen(IPAddress ip, int port, int timeout)
    {
        try
        {
            using (var client = new TcpClient())
            {
                var result = client.BeginConnect(ip, port, null, null);
                var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromMilliseconds(timeout));
                if (!success) return false;

                client.EndConnect(result);
                return true;
            }
        }
        catch
        {
            return false;
        }
    }
}

// Class to represent the JSON response from the server
public class ServerResponse
{
    public bool Success { get; set; }
    public List<ServerData> Data { get; set; }
}

public class ServerData
{
    public string PIN { get; set; }
}

