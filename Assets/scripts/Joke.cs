using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class jiker{

    public string[] categories;
    public string createdat;
    public string iconurl;
    public string id;
    public string url;
    public string value;
    }

    [System.Serializable]
    public class myapi{
        public string message;
        public string serverAddress;
    }
public class Joke : MonoBehaviour
{

    public TextMeshProUGUI textMeshPro;
    public void joking(){
        // jiker j = apihelperr.GetJoke();
        // textMeshPro.text = j.value;
        myapi ap = apihelperr.GetJoke();
        textMeshPro.text = ap.message;

    }
}
