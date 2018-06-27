using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VuMarkHandler : MonoBehaviour {

    VuMarkManager vuMarkManager;

    [SerializeField]
    private TextMesh textMesh;

    public VuMarkNumericHandler foundNumericHandler;

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
        Output(code, false);
        Debug.Log("VuMark code: " + code);
    }

    private void VuMarkLost(VuMarkTarget target)
    {
        Output("");
    }

    private string GetVuMarkCode(VuMarkTarget target)
    {
        switch(target.InstanceId.DataType)
        {
            case InstanceIdType.NUMERIC:
                // trigger handler event when VuMark numeric code is found
                if (foundNumericHandler != null)
                {
                    foundNumericHandler.Invoke(target.InstanceId.NumericValue);
                }
                return target.InstanceId.NumericValue.ToString();
            case InstanceIdType.STRING:
                return target.InstanceId.StringValue;
            case InstanceIdType.BYTES:
                return target.InstanceId.HexStringValue;
        }
        return "";
    }

    private void Output(string text, bool shouldUpdate = true)
    {
        if (textMesh == null)
        {
            return;
        }
        if (!string.IsNullOrEmpty(textMesh.text) && !shouldUpdate)
        {
            return;
        }
        textMesh.text = text;
    }
}
