using BlockSnifferIp;
using System;
using System.Collections.Generic;
using System.Threading;

namespace BlockSnifferIpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = 0;
            while (port == 0)
            {
                try
                {
                    Console.Write("Monitor local port:");
                    port = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            BlockSnifferIp.Monitor monitor = new BlockSnifferIp.Monitor(port);
            while (true)
            {
                List<Record> NetworkRecord = monitor.GetRecord();
                // sort by last alive time, alive seconds and ip ascii sorting
                NetworkRecord.Sort((left, right) =>
                {
                    if (left.last_alive > right.last_alive)
                        return -1;
                    else if (left.last_alive == right.last_alive)
                    {
                        if (left.alive > right.alive)
                            return -1;
                        else
                            return left.ip.CompareTo(right.ip);
                    }
                    return 1;
                });

                Console.Clear();
                Console.WriteLine("{0,-16}|    {1,-20}|    {2,-16}|    {3}", "IP Address", "Last Alive", "Alive Seconds","Attack Count");
                foreach (Record r in NetworkRecord)
                    Console.WriteLine("{0,-16}|    {1,-20}|    {2,-16}|    {3}", r.ip, r.last_alive.ToLocalTime(), r.alive, r.count);
                Console.SetCursorPosition(0, 0);
                Thread.Sleep(1000);
            }
        }

    }
}
