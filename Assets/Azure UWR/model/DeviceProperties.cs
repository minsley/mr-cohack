using System.Collections;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

[Serializable]
public class DeviceProperties {
    public Desired desired;
    public Reported reported;
}

[Serializable]
public class Desired
{
    [JsonProperty("$metadata")]
    public MetaData metadata;
    [JsonProperty("$version")]
    public int version;
}

[Serializable]
public class MetaData
{
    [JsonProperty("$lastUpdated")]
    public DateTime lastUpdated;
    [JsonProperty("$lastUpdatedVersion")]
    public int lastUpdatedVersion;
}

[Serializable]
public class Reported
{
    public double Longitude;
    public double Latitude;
    public string Location;
    public string SupportedMethods;
    public string Type;
    public string Firmware;
    public string Model;
    [JsonProperty("$version")]
    public int version;
    public JObject Telemetry;
}