using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AzureFunctionDevices : AzureFunction {

    public TextMesh textMesh;

    private DeviceDetails[] devices;

    //*
    public override void Send()
    {
        UpdateText("Loading");
        base.Send();
    }
    //*/

    public void SendCompleted(string body)
    {
        Debug.Log("Complete\n" + body);
        int results = 0;
        // try parsing
        try
        {
            devices = JsonConvert.DeserializeObject<DeviceDetails[]>(body);
            results = devices.Length;
            Debug.Log("Parsed device details: " + results);
        }
        catch (Exception ex)
        {
            Debug.LogError("Parse JSON exception: " + ex);
        }
        // update text
        UpdateText("Found " + results + " devices");
        // test
        //GetDevice("chiller-01.0");
    }

    public DeviceDetails GetDevice(string deviceId)
    {
        if (devices == null || devices.Length < 1)
        {
            return null;
        }
        foreach (var device in devices)
        {
            if (string.Equals(deviceId, device.DeviceId)) {
                Debug.Log("Found Device Id: " + device.DeviceId + "\n" + device.Status);
                return device;
            }
        }
        return null;
    }

    public DeviceDetails GetDevice(uint index)
    {
        if (devices == null || devices.Length < index)
        {
            return null;
        }
        DeviceDetails device = devices[index];
        Debug.Log("Device Id: " + device.DeviceId + "\n" + device.Status);
        return device;
    }

    public void FindDevice(ulong code)
    {
        uint index = 0;
        try
        {
            index = Convert.ToUInt32(code);
        }
        catch (OverflowException)
        {
            Debug.LogErrorFormat("The {0} value {1} is outside the range of the Int32 type.",
                              code.GetType().Name, code);
        }
        if (index == 0)
        {
            Debug.LogError("VuMark sample starts at 1");
            return;
        }
        DeviceDetails device = GetDevice(index - 1);
        if (device != null)
        {
            UpdateText("Found " + device.DeviceId);
        }
        else
        {
            UpdateText("Unknown device");
        }
    }

    private void UpdateText(string text="")
    {
        if (textMesh != null)
        {
            textMesh.text = text;
        }
    }

}
