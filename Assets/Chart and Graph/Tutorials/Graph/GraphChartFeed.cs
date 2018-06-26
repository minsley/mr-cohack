using UnityEngine;
using ChartAndGraph;

public class GraphChartFeed : MonoBehaviour
{
    public float UpdatePeriod = 0.2f; // Time between updates

    private GraphChartBase graph;
    private float timeSinceUpdate = 0f;

	void Start ()
    {
        Random.InitState(System.DateTime.Now.Millisecond);

        graph = GetComponent<GraphChartBase>();
        if (graph != null)
        {
            //graph.DataSource.StartBatch();
            graph.DataSource.ClearAndMakeBezierCurve("Player 1");
            graph.DataSource.ClearAndMakeBezierCurve("Player 2");
            for (int i = 0; i <30; i++)
            {
                if (i == 0) {
                    graph.DataSource.SetCurveInitialPoint("Player 1",0f, Random.value * 10f + 10f);
                    graph.DataSource.SetCurveInitialPoint("Player 2",0f, Random.value * 10f + 10f);
                }
                else {
                    graph.DataSource.AddLinearCurveToCategory("Player 1", new DoubleVector2(i * 10f/30f, Random.value * 10f + 10f));
                    graph.DataSource.AddLinearCurveToCategory("Player 2", new DoubleVector2(i * 10f/30f, Random.value * 10f + 10f));
                }
            }

            graph.DataSource.MakeCurveCategorySmooth("Player 1");
            graph.DataSource.MakeCurveCategorySmooth("Player 2");
            //graph.DataSource.EndBatch();
        }
    }

    // void Update()
    // {
    //     if(graph == null)
    //         return;

    //     timeSinceUpdate += Time.deltaTime;

    //     if(timeSinceUpdate >= UpdatePeriod)
    //     {
    //         timeSinceUpdate = 0f;

    //         graph.DataSource.AddPointToCategoryRealtime("Player 2",Random.value*10f,Random.value*10f + 20f, UpdatePeriod);
    //         graph.DataSource.AddPointToCategoryRealtime("Player 1",Random.value*10f,Random.value*10f + 20f, UpdatePeriod);
    //     }
    // }

    // public GraphChartBase Graph;
    // public int TotalPoints = 10;
    // float lastTime = 0f;
    // float lastX = 0f;
    // void Start()
    // {
    //     if(Graph == null)
    //     {
    //         Graph = GetComponent<GraphChartBase>();
    //     }

    //     float x = 0f;

    //     Graph.DataSource.ClearCategory("Player 1");
    //     Graph.DataSource.ClearCategory("Player 2");

    //     for(int i=0; i < TotalPoints; i++)
    //     {
    //         Graph.DataSource.AddPointToCategory("Player 1", x, Random.value * 20f + 10f);
    //         Graph.DataSource.AddPointToCategory("Player 2", x, Random.value * 10f);

    //         x += Random.value *3f;
    //         lastX = x;
    //     }
    // }

    // void Update()
    // {
    //     float time = Time.time;
    //     if(lastTime + 1f < time)
    //     {
    //         lastTime = time;
    //         lastX += Random.value * 3f;
    //         Graph.DataSource.AddPointToCategory("Player 1", lastX, Random.value * 20f + 10f);
    //         Graph.DataSource.AddPointToCategory("Player 2", lastX, Random.value * 20f + 1f);

    //         Graph.DataSource.MakeCurveCategorySmooth("Player 1");
    //         Graph.DataSource.MakeCurveCategorySmooth("Player 2");
    //     }
    // }
}
