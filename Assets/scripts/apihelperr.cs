using System.Net;
using System.IO;
using UnityEngine;

public static class apihelperr
{
 
 public static myapi GetJoke(){
    HttpWebRequest request = (HttpWebRequest) WebRequest.Create("http://localhost:3000/server-info");
    HttpWebResponse response = (HttpWebResponse) request.GetResponse();
    StreamReader reader = new StreamReader(response.GetResponseStream());
    string json  = reader.ReadToEnd();
    return JsonUtility.FromJson<myapi>(json);
 }

 public static void getworkdone(string phoneNumber){
         string url = "http://localhost:3000/auth/user/send-phone";

        // Construct a JSON object with the phone number
        string jsonData = "{\"phoneNumber\":\"" + phoneNumber + "\"}";

        // Convert the JSON string to a byte array
        byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(jsonData);

        // Create a new HttpWebRequest
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "POST";
        request.ContentType = "application/json";
        request.ContentLength = byteArray.Length;

        // Get the request stream and write the JSON data to it
        using (Stream dataStream = request.GetRequestStream())
        {
            dataStream.Write(byteArray, 0, byteArray.Length);
        }

        // Send the request asynchronously
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        {
            // Read the response
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream);
                string responseFromServer = reader.ReadToEnd();
                Debug.Log(responseFromServer);
            }
        }
        
    }
 }

