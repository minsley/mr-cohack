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

/*
{
    "id": "chiller-01.0;1530220828669",
    "doc.schemaversion": 1,
    "doc.schema": "d2cmessage",
    "device.id": "chiller-01.0",
    "device.msg.schema": "device-sensors;v1",
    "data.schema": "StreamingJobs",
    "device.msg.created": 1530220828669,
    "device.msg.received": 1530220828669,
    "data": {
        "temperature": 74.4707,
        "temperature_unit": "F",
        "pressure": 138.276047,
        "pressure_unit": "psig",
        "speed": 0,
        "speed_unit": null,
        "vibration": 0,
        "vibration_unit": null,
        "humidity": 69.18799,
        "humidity_unit": "%",
        "fuelLevel": 0,
        "fuelLevel_unit": null,
        "coolant": 0,
        "coolant_unit": null,
        "latitude": 0,
        "longitude": 0,
        "partitionId": 0
    },
    "_rid": "-pgyAMk9wgDXDwQAAAAAAA==",
    "_self": "dbs/-pgyAA==/colls/-pgyAMk9wgA=/docs/-pgyAMk9wgDXDwQAAAAAAA==/",
    "_etag": "\"0100aa28-0000-0000-0000-5b3551290000\"",
    "_attachments": "attachments/",
    "_ts": 1530220841
}
//*/