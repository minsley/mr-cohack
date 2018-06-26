using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateDummyChartData : MonoBehaviour 
{
	public float UpdatePeriod = 0.2f; // Update chart ever X seconds
	public float RangeMin = 0f;
	public float RangeMax = 10f;

	private DD_DataDiagram diagram;
	private List<GameObject> lines;
	private float timeSinceUpdate = 0f;

	// Use this for initialization
	void Start () 
	{
		diagram = GetComponent<DD_DataDiagram>();

		lines = new List<GameObject>();
		lines.Add(diagram.AddLine("Device 001", Color.blue));
		lines.Add(diagram.AddLine("Device 002", Color.magenta));
	}
	
	// Update is called once per frame
	void Update () 
	{
		timeSinceUpdate += Time.deltaTime;

		if(timeSinceUpdate >= UpdatePeriod)
		{
			timeSinceUpdate = 0f;
			UpdateChart();
		}
	}

	void UpdateChart()
	{
		foreach(var line in lines)
		{
			diagram.InputPoint(line, new Vector2(1, Random.Range(RangeMin, RangeMax)));
		}
	}
}
