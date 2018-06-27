using UnityEngine;
using ChartAndGraph;
using System.Collections.Generic;
using System.Linq;

public class GraphChartFeed : MonoBehaviour
{
    public float UpdatePeriod = 0.2f; // Time between updates

    private GraphChartBase graph;
    private float timeSinceUpdate = 0f;
    private int lastX = 0;

	public void Start ()
    {
        Random.InitState(System.DateTime.Now.Millisecond);

        graph = GetComponent<GraphChartBase>();
        if (graph != null)
        {
            var series = Enumerable.Range(0, 1000).Select(x => Random.Range(0f, 10f)).ToList();

            graph.DataSource.StartBatch();
            graph.DataSource.ClearAndMakeLinear("Player 1");
            graph.DataSource.ClearAndMakeLinear("Player 2");

            var y = GetBinAverage(series, 50);
            for (int i=0; i<y.Count(); i++)
            {
                graph.DataSource.AddPointToCategory("Player 1", i, y[i]);
                lastX = i;
            }

            graph.DataSource.EndBatch();
        }
    }

    public void Update()
    {
        timeSinceUpdate += Time.deltaTime;

        if (graph == null || timeSinceUpdate < UpdatePeriod)
            return;

        timeSinceUpdate = 0;
        graph.DataSource.AddPointToCategory("Player 1", ++lastX, Random.Range(3,7));
    }

    private List<float> GetBinAverage(List<float> source, int binSize)
    {
        var result = new List<float>();

        for (var i = 0; i < source.Count / binSize; i++)
        {
            var index = i * binSize;
            var remainingCount = source.Count - (index + 1);

            var subset = source.GetRange(index, binSize > remainingCount ? remainingCount : binSize);

            result.Add(subset.Average());
        }

        return result;
    }
}
