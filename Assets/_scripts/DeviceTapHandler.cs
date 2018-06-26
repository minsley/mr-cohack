using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.Receivers;
using HoloToolkit.Unity.InputModule;
public class DeviceTapHandler : InteractionReceiver
{

    // // Use this for initialization
    // void Start () {

    // }

    // // Update is called once per frame
    // void Update () {

    // }

    public GameObject ChartPrefab;

    void Start()
    {

    }

    protected override void FocusEnter(GameObject obj, PointerSpecificEventData eventData)
    {
        Debug.Log(obj.name + " : FocusEnter");
    }

    protected override void FocusExit(GameObject obj, PointerSpecificEventData eventData)
    {
        Debug.Log(obj.name + " : FocusExit");
    }

    protected override void InputDown(GameObject obj, InputEventData eventData)
    {
        Debug.Log(obj.name + " : InputDown");

        var chart = Instantiate(ChartPrefab);
        chart.transform.SetPositionAndRotation(obj.transform.position, obj.transform.rotation);
    }
}
