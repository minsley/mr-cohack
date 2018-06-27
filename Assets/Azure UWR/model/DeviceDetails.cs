using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class DeviceDetails
{
    public int ConnectionState;
    public string DeviceId;
    public string ETag;
    public string Status;
    public long Version;
    public DateTime StatusUpdatedTime;
    public DeviceProperties Properties;
    public DateTime LastActivityTime;
}
