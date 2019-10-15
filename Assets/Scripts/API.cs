using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

class API : MonoBehaviour {

    public Text responseText;

    void Start()
{
    StartCoroutine(GetText());
}

IEnumerator GetText()
{
    UnityWebRequest www = UnityWebRequest.Get("http://google.com");
    yield return www.SendWebRequest();


    if (www.isNetworkError)
    {
        Debug.Log("Error: " + www.error);
    }
    else
    {
        // Show results as text
        Debug.Log("Received: " + www.downloadHandler.text);
        responseText.text = "Response: " + www.downloadHandler.text;

        // Or retrieve results as binary data
        //byte[] results = www.downloadHandler.data;

        }
}
}