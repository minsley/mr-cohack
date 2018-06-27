using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Vuforia;

public class VuMarkDeviceBinder : MonoBehaviour {

    VuMarkManager vuMarkManager;

    [SerializeField]
    private GameObject deviceDetectedPrefab;

    private Dictionary<string, GameObject> detectedDevices = new Dictionary<string, GameObject>();

    // Use this for initialization
    void Start () {
        vuMarkManager = TrackerManager.Instance.GetStateManager().GetVuMarkManager();
        vuMarkManager.RegisterVuMarkDetectedCallback(VuMarkDetected);
        vuMarkManager.RegisterVuMarkLostCallback(VuMarkLost);
    }

    void OnDestroy()
    {
        vuMarkManager.UnregisterVuMarkDetectedCallback(VuMarkDetected);
        vuMarkManager.UnregisterVuMarkLostCallback(VuMarkLost);
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void VuMarkDetected(VuMarkTarget target)
    {
        string code = GetVuMarkCode(target);
        Debug.Log("VuMark code: " + code);

        if (detectedDevices.ContainsKey(code))
            return;

        if(!target.IsExtendedTrackingStarted())
            target.StartExtendedTracking();

        var behavior = vuMarkManager.GetActiveBehaviours(target).SingleOrDefault();
        if (behavior == null)
            return;

        var deviceAnchor = Instantiate(deviceDetectedPrefab);
        deviceAnchor.transform.parent = behavior.transform;
        deviceAnchor.transform.SetPositionAndRotation(Vector3.zero, Quaternion.Euler(0, 0, 0));
        detectedDevices.Add(code, deviceAnchor);
    }

    private void VuMarkLost(VuMarkTarget target)
    {
        string code = GetVuMarkCode(target);

        if (!detectedDevices.ContainsKey(code))
            return;

        var deviceAnchor = detectedDevices[code];
        Destroy(deviceAnchor);
        detectedDevices.Remove(code);
    }

    private string GetVuMarkCode(VuMarkTarget target)
    {
        switch(target.InstanceId.DataType)
        {
            case InstanceIdType.NUMERIC:
                return target.InstanceId.NumericValue.ToString();
            case InstanceIdType.STRING:
                return target.InstanceId.StringValue;
            case InstanceIdType.BYTES:
                return target.InstanceId.HexStringValue;
        }
        return "";
    }
}
