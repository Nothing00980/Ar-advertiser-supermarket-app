
using UnityEngine;
using TMPro;
using System.IO;
using System.Net;
using UnityEngine.SceneManagement;

[System.Serializable]
public class LoginResponseData
{
    public bool success;
    public string message;
    public string userId;
    public string token;
    public UserDetails userDetails;
}

[System.Serializable]
public class UserDetails
{
    public string username;
    public string email;
    public string phone;
    // Add more user details as needed
}

public class login : MonoBehaviour
{
      string url = "http://192.168.224.197:3000/auth/user/login";
    public TMP_InputField email;
    public TMP_InputField password;
    private LoginResponseData loginResponseData;

    string enteredemail;
    string enteredpassword;

     public pop popscript;

     public userdata userdata;


    private void Awake ()
    {
        // Assign the pop script reference
        popscript = GameObject.Find("controller").GetComponent<pop>();
        popscript.OnClickDisableObject();
        
        // Change the text values using the pop script methods
       
    }




public void submit(){
     enteredemail = email.text;
    enteredpassword = password.text;
    getworkdone();

}

public void getworkdone(){
    try{

    
    string jsonData = "{\"email\":\"" + enteredemail + "\",\"password\":\"" + enteredpassword + "\"}";
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
                loginResponseData = JsonUtility.FromJson<LoginResponseData>(responseFromServer);
                userdata.PopulateUserData(loginResponseData.userDetails.username,loginResponseData.userDetails.email,loginResponseData.userDetails.phone,loginResponseData.userId,loginResponseData.token);


                 popscript.onclickenable();
            popscript.ChangeTextValuehead("Success");
            popscript.ChangeTextValuemaintext("got all the data!");
            Invoke("loading",2f);
                // EditorUtility.DisplayDialog("Warning", responseFromServer, "OK");

            }
        }
        else{
             popscript.onclickenable();
            popscript.ChangeTextValuehead("Error");
            popscript.ChangeTextValuemaintext(response.StatusCode.ToString());
             Debug.LogError("Error: " + response.StatusCode);

        }
        }
        
    
} catch (WebException ex)
        {
            // Handle exceptions
            Debug.LogError("WebException: " + ex.Message);
            popscript.onclickenable();
            popscript.ChangeTextValuehead("Error");
            popscript.ChangeTextValuemaintext(ex.Message);
        }
        catch (System.Exception ex)
        {
            // Handle other exceptions
            Debug.LogError("Exception: " + ex.Message);
            popscript.onclickenable();
            popscript.ChangeTextValuehead("Error");
            popscript.ChangeTextValuemaintext(ex.Message);
        }


}

 private void loading(){
    SceneManager.LoadScene("dashboard");
 }

}
