using UnityEngine;
using System.IO;
using System.Net;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;

[System.Serializable]
public class myapiresponse{
    public string response;
    
}


public class SendOTP : MonoBehaviour
{
     string backendURL = "http://192.168.224.197:3000/auth/user/send-phone"; // Update this with your actual backend URL

    private string storedPhoneNumber; // Variable to store the phone number locally
    public TMP_InputField inputField;
    public float requestTimeout = 120f;

    public pop popscript;


    private void Awake ()
    {
        // Assign the pop script reference
        popscript = GameObject.Find("controller").GetComponent<pop>();
        popscript.OnClickDisableObject();
        
        // Change the text values using the pop script methods
       
    }

    public  void SendOTPRequest()
    {

        storedPhoneNumber = "+91"+inputField.text;
        PhoneNumberManager.instance.phonenumber = storedPhoneNumber;
        Debug.Log(storedPhoneNumber); 
        getworkdone(storedPhoneNumber);

     



    }
    public  void getworkdone(string phoneNumber){
        try
        {
            
       
   
        string jsonData = "{\"phoneNumber\":\"" + phoneNumber + "\"}";

        byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(jsonData);

        Debug.Log(backendURL);
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(backendURL);
        request.Method = "POST";
        request.ContentType = "application/json";
        request.ContentLength = byteArray.Length;

        using (Stream dataStream = request.GetRequestStream())
        {
            dataStream.Write(byteArray, 0, byteArray.Length);
        }

        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        {
            if (response.StatusCode == HttpStatusCode.OK)
                {

            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream);
                string responseFromServer = reader.ReadToEnd();
                Debug.Log(responseFromServer);
                popscript.onclickenable();
                popscript.ChangeTextValuehead("success");
                popscript.ChangeTextValuemaintext(responseFromServer);
                Invoke("loading",2f);
                // SceneManager.LoadScene("verify-otp");

            }
        }
        else{
            popscript.onclickenable();
                popscript.ChangeTextValuehead("Warning!");
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
    SceneManager.LoadScene("verify-otp");
 }

  

   
}