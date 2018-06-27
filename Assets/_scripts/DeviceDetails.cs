using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._scripts.AzureModels
{
    public class DeviceDetails
    {
        public DeviceConnectionState ConnectionState { get; set; }
        public string DeviceId { get; set; }
        public string ETag { get; set; }
        public DeviceStatus Status { get; set; }
        public long Version { get; set; }
        public System.DateTime StatusUpdatedTime { get; set; }
        public TwinProperties Properties { get; set; }
        public System.DateTime LastActivityTime { get; set; }
    }
}

