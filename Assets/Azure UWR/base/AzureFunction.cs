using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public abstract class AzureFunction : MonoBehaviour, IAzureFunction
{

    public string Endpoint;

    public bool AutoSend = true;

    public SendCompleteHandler OnSendCompleteHandler;

    // Use this for initialization
    void Start()
    {
        if (AutoSend)
        {
            Send();
        }
    }

    public virtual void Send()
    {
        Debug.Log("Send\n" + Endpoint);
        StartCoroutine(GetRequest(OnSendCompleteHandler));
    }

    private IEnumerator GetRequest(UnityEvent<string> handler = null)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(Endpoint))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                // Show results as text
                Debug.Log(www.downloadHandler.text);

                // Or retrieve results as binary data
                //byte[] results = www.downloadHandler.data;
                if (handler != null)
                {
                    handler.Invoke(www.downloadHandler.text);
                }
            }
        }
    }


}
