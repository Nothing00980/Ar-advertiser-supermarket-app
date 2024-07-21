using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Net;
using TMPro;
using System;

public class verifyotp : MonoBehaviour
{
    String url = "http://192.168.224.197:3000/verify-otp";
    public TMP_InputField inputField;
    string enteredOTP;
    string phoneNumber;

    
    void Start()
{
    // Check if PhoneNumberManager instance is null
    if (PhoneNumberManager.instance == null)
    {
        Debug.LogError("PhoneNumberManager instance is null");
    }
    else
    {
        // Retrieve phone number
         phoneNumber = PhoneNumberManager.instance.phonenumber;
        Debug.Log("Phone number: " + phoneNumber);
    }
}

    public void verifytheotp(){
        Debug.Log(phoneNumber);
        enteredOTP = inputField.text;
        completework();

    }

    public void resendotp(){
        string url = "http://localhost:3000/resendotp";
         string jsonData = "{\"phoneNumber\":\"" + phoneNumber + "\"}";

        // Convert the JSON string to a byte array
        byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(jsonData);

        // Create a new HttpWebRequest
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
                // EditorUtility.DisplayDialog("Warning", responseFromServer, "OK");

            }
        }
        else{
             Debug.LogError("Error: " + response.StatusCode);
        }
        }
        
    

    }
    public void completework(){
              string jsonData = "{\"phoneNumber\":\"" + phoneNumber + "\", \"enteredOTP\":\"" + enteredOTP + "\"}";
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
                SceneManager.LoadScene("dashboard");

                // EditorUtility.DisplayDialog("Warning", responseFromServer, "OK");

            }
        }
        else{
             Debug.LogError("Error: " + response.StatusCode);
        }
        }
        
    }



    }


