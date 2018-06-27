
using UnityEngine;
using ChartAndGraph;
using System.Collections.Generic;
using System.Linq;

namespace Assets._scripts
{
    public class Mock3DChartData : MonoBehaviour
    {

        public float UpdatePeriod = 0.5f; // Time between updates

        private GraphChartBase graph;
        private float timeSinceUpdate = 0f;
        private List<float> data = new List<float>();

        public void Start()
        {
            Random.InitState(System.DateTime.Now.Millisecond);

            data = Enumerable.Range(0, 20).Select(x => Random.Range(0f, 5f)).ToList();

            graph = GetComponent<GraphChartBase>();
            if (graph != null)
            {
                UpdateGraph();
            }
        }

        public void Update()
        {
            timeSinceUpdate += Time.deltaTime;

            if (timeSinceUpdate < UpdatePeriod)
                return;

            timeSinceUpdate = 0;

            data.RemoveAt(0);
            data.Add(Random.Range(0f, 5f));

            UpdateGraph();
        }

        private void UpdateGraph()
        {
            if (graph == null)
                return;

            graph.DataSource.StartBatch();
            graph.DataSource.ClearAndMakeLinear("Player 1");

            for (int i = 0; i < data.Count(); i++)
            {
                graph.DataSource.AddPointToCategory("Player 1", i, data[i]);
            }

            graph.DataSource.EndBatch();
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
}
