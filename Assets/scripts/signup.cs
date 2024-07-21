
using UnityEngine;
using TMPro;
using System.IO;
using System.Net;
using UnityEngine.SceneManagement;

public class signup : MonoBehaviour
{
    string url = "http://192.168.224.197:3000/auth/user/signup";
    public TMP_InputField username;
    public TMP_InputField email;
    public TMP_InputField password;

    string enteredusername;
    string enteredemail;
    string enteredpassword;




public void submit(){
    enteredusername = username.text;
    enteredemail = email.text;
    enteredpassword = password.text;
getworkdone();

}

public void getworkdone(){
    string jsonData = "{ \"username\":\"" + enteredusername + "\",\"email\":\"" + enteredemail + "\",\"password\":\"" + enteredpassword + "\"}";
     Debug.Log("Sending OTP: " + jsonData);

                  byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(jsonData);

        Debug.Log(url);
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
            if (response.StatusCode == HttpStatusCode.OK)
                {
            // Read the response
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream);
                string responseFromServer = reader.ReadToEnd();
                Debug.Log(responseFromServer);
                SceneManager.LoadScene("login");
                // EditorUtility.DisplayDialog("Warning", responseFromServer, "OK");

            }
        }
        else{
             Debug.LogError("Error: " + response.StatusCode);
        }
        }
        
    
}
   
}
