using System;
using System.Collections.Generic;
using System.Text;

namespace BlockSnifferIp
{
    [Serializable]
    public class Record
    {
        // IP for incomming connection
        public string ip { get; set; }
        // Total transfer bytes
        public UInt64 transfer { get; set; }
        // Total aliving time (seconds)
        public uint alive { get; set; }
        // Last alive time
        public DateTime last_alive { get; set; }
        // Total connection count
        public uint count { get; set; }
        public bool enabled { get; set; }

        public Record()
        {
            transfer = 0;
            alive = 0;
            count = 0;
            enabled = true;
        }
    }

    public class NETRECORD
    {
        public string IP;
        public List<int> Port;
        public DateTime StartTime;
    }

    [Serializable]
    public class ExportRecordJson
    {
        public string host { get; set; }
        public  DateTime export_time { get; set; }
        public Record[] data { get; set; }

        public ExportRecordJson()
        {
            host= Environment.GetEnvironmentVariable("computername");
            export_time = DateTime.Now.ToLocalTime();
        }
    }

    public class Types
    { }
}
