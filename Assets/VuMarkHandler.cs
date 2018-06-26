using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VuMarkHandler : MonoBehaviour {

    VuMarkManager vuMarkManager;

    [SerializeField]
    private TextMesh textMesh;

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
        Output(code);
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
                return target.InstanceId.NumericValue.ToString();
            case InstanceIdType.STRING:
                return target.InstanceId.StringValue;
            case InstanceIdType.BYTES:
                return target.InstanceId.HexStringValue;
        }
        return "";
    }

    private void Output(string text)
    {
        if (textMesh == null)
        {
            return;
        }
        textMesh.text = text;
    }
}
