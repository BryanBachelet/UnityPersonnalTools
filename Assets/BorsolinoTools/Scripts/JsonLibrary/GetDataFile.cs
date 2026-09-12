using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


namespace BorsalinoTools
{

    public class GetDataFile : MonoBehaviour
    {
        [SerializeField] private string m_idGoogleSheet;

        public void Start()
        {
            LaunchRequest();
        }

        public void LaunchRequest()
        {
            StartCoroutine(ObtainSheetData());


        }

        IEnumerator ObtainSheetData()
        {
            string url = "https://docs.google.com/spreadsheets/d/" + m_idGoogleSheet + "/gviz/tq";


            UnityWebRequest request = UnityWebRequest.Get(url);

            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError || request.result == UnityWebRequest.Result.DataProcessingError)
            {
                Debug.LogError(request.result.ToString());
                yield return null;
            }

            string json = request.downloadHandler.text;

            int index = json.IndexOf('{');
            string sub = json.Substring(index);
            index = sub.LastIndexOf('}') + 1;
            string finalString = sub.Remove(index, sub.Length - index);

            Debug.Log("URL : " + url);
            Debug.Log(finalString);

            JsonLoader.Parse(finalString);
    




    }
    }
}
