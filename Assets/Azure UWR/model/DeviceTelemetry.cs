using System.Collections;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;

[Serializable]
public class DeviceTelemetry : Doc
{
    [JsonProperty("id")]
    public string Id;
    [JsonProperty("doc.schemaversion")]
    public int SchemaVersion;
    [JsonProperty("doc.schema")]
    public string Schema;
    [JsonProperty("device.id")]
    public string DeviceId;
    [JsonProperty("device.msg.schema")]
    public string DeviceSchema;
    [JsonProperty("data.schema")]
    public string DataSchema;
    [JsonProperty("device.msg.created")]
    public int DeviceMessageCreated;
    [JsonProperty("device.msg.received")]
    public int DeviceMessageReceived;
    [JsonProperty("data")]
    public DeviceDataTelemetry DeviceDataTelemetry;
}

[Serializable]
public class DeviceDataTelemetry
{
    [JsonProperty("partitionId")]
    public int PartitionId;

    [JsonProperty("latitude")]
    public double Latitude;
    [JsonProperty("longitude")]
    public double Longitude;

    [JsonProperty("temperature")]
    public double Temperature;
    [JsonProperty("temperature_unit")]
    public string TemperatureUnit;

    [JsonProperty("pressure")]
    public double Pressure;
    [JsonProperty("pressure_unit")]
    public string PressureUnit;

    [JsonProperty("speed")]
    public double Speed;
    [JsonProperty("speed_unit")]
    public string SpeedUnit;

    [JsonProperty("vibration")]
    public double Vibration;
    [JsonProperty("vibration_unit")]
    public string VibrationUnit;

    [JsonProperty("humidity")]
    public double Humidity;
    [JsonProperty("humidity_unit")]
    public string HumidityUnit;

    [JsonProperty("fuelLevel")]
    public double FuelLevel;
    [JsonProperty("fuelLevel_unit")]
    public string FuelLevelUnit;

    [JsonProperty("coolant")]
    public double Coolant;
    [JsonProperty("coolant_unit")]
    public string CoolantUnit;
}