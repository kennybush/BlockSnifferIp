using System;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace BlockSnifferIp
{
    public class Monitor:IDisposable
    {
        List<Record> lNetworkRecord;
        bool bStartCopy = false;
        bool bIsExit = false;
        Thread tRefreshStatus;
        public Monitor(int targetPort)
        {
            tRefreshStatus = new Thread(new ParameterizedThreadStart(RefreshStatus));
            tRefreshStatus.Start(targetPort);
        }

        ~Monitor()
        {
            Dispose();
        }

        public void Dispose()
        {
            bIsExit = true;
            while (tRefreshStatus.ThreadState != ThreadState.Stopped) ;
        }

        public List<Record> GetRecord()
        {
            bStartCopy = true;
            while (bStartCopy)
                Thread.Sleep(10);
            return lNetworkRecord;
        }

        void RefreshStatus(object TargetPort)
        {
            List<Record> lRecord = new List<Record>();
            List<NETRECORD> lOldNetRecord = new List<NETRECORD>();
            while (!bIsExit)
            {
                List<NETRECORD> lNewNetRecord = GetNetRecord((int)TargetPort);

                // compare with old record structure to find alive and count attack time
                foreach (NETRECORD netRecord2 in lNewNetRecord)
                {
                    Record record = lRecord.Find((Record rec) => rec.ip == netRecord2.IP);
                    if (record == null)
                    {
                        lRecord.Add(new Record() { ip = netRecord2.IP, last_alive = DateTime.Now.ToLocalTime() });
                        record = lRecord[lRecord.Count - 1];
                    }
                    else
                        record.last_alive = DateTime.Now.ToLocalTime();

                    NETRECORD foundIP = lOldNetRecord.Find((NETRECORD rec) => rec.IP == netRecord2.IP);
                    if (foundIP != null)
                    {
                        // IP has been recorded
                        foreach (int portRecord in netRecord2.Port)
                        {
                            // new port in this IP will mark as attacks
                            if (foundIP.Port.IndexOf(portRecord) < 0)
                                record.count++;
                        }
                        // update alive time
                        record.alive = (uint)(record.last_alive - foundIP.StartTime).TotalSeconds;
                    }
                    else
                    {
                        // not match any records
                        foreach (int portRecord in netRecord2.Port)
                            record.count++;
                    }
                }

                // change new record start time to old record's
                foreach (NETRECORD netRecord3 in lOldNetRecord)
                {
                    NETRECORD foundIP = lNewNetRecord.Find((NETRECORD rec) => rec.IP == netRecord3.IP);
                    if (foundIP != null)
                    {
                        foundIP.StartTime = netRecord3.StartTime;
                    }
                }

                // new record -> old record
                lOldNetRecord = lNewNetRecord;

                if (bStartCopy)
                {
                    using (Stream objStream = new MemoryStream())
                    {
                        IFormatter formatter = new BinaryFormatter();
                        formatter.Serialize(objStream, lRecord);
                        objStream.Seek(0, SeekOrigin.Begin);
                        lNetworkRecord = (List<Record>)formatter.Deserialize(objStream);
                    }
                    bStartCopy = false;
                }

                Thread.Sleep(50);
            }
        }

        List<NETRECORD> GetNetRecord(int targetPort)
        {
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            List<NETRECORD> lNetRecord = new List<NETRECORD>();
            TcpConnectionInformation[] informations = properties.GetActiveTcpConnections();

            // find remote connection info and put into a new record structure
            foreach (TcpConnectionInformation inf in informations)
            {
                if (inf.LocalEndPoint.Port == targetPort)
                {
                    string remoteIp = inf.RemoteEndPoint.Address.ToString();

                    NETRECORD netRecord1 = lNetRecord.Find((NETRECORD rec) => rec.IP == remoteIp);
                    if (netRecord1 == null)
                    {
                        NETRECORD record = new NETRECORD()
                        {
                            IP = remoteIp,
                            Port = new List<int>(),
                            StartTime = DateTime.Now.ToLocalTime(),
                        };
                        record.Port.Add(inf.RemoteEndPoint.Port);
                        lNetRecord.Add(record);
                    }
                    else
                    {
                        netRecord1.Port.Add(inf.RemoteEndPoint.Port);
                    }
                }
            }
            return lNetRecord;
        }
    }
}
