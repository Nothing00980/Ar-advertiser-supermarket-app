
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class account : MonoBehaviour
{

    public TextMeshProUGUI username;
    public TextMeshProUGUI email;
    public TextMeshProUGUI phonenum;

    public userdata userdata;
    private string phoneNumber;

    public void Start()
    {
        if (PhoneNumberManager.instance == null)
        {
            Debug.LogError("PhoneNumberManager instance is null");
        }
        else
        {
            // Retrieve phone number
            phoneNumber = PhoneNumberManager.instance.phonenumber;
            Debug.Log("Phone number: " + phoneNumber);
            phonenum.text = phoneNumber;
            Debug.Log("text changed to " + phonenum.text);
        }

        Debug.Log(userdata.username);
        Debug.Log(userdata.email);
        Debug.Log(userdata.phone);
        username.text = userdata.username;
        email.text = userdata.email;

        phonenum.text = userdata.phone;

        if (phonenum.text == "")
        {
            phonenum.text = phoneNumber;
        }


    }

    public void Logout()
    {
        // Clear user data by resetting all properties to empty or default values
        userdata.username = "";
        userdata.email = "";
        userdata.phone = "";
        userdata.userId = "";
        userdata.token = "";

        PhoneNumberManager.instance = null;

        // Optionally, you can destroy the ScriptableObject if it's no longer needed
        // Destroy(userDataScriptableObject);

        // Load the sign-in scene
        SceneManager.LoadScene("signin");
    }


}
