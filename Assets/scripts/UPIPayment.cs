using UnityEngine;
using UnityEngine.UI;

public class UPIPayment : MonoBehaviour
{
    public Button payButton;

    void Start()
    {
        payButton.onClick.AddListener(InitiateUPIPayment);
    }

    void InitiateUPIPayment()
    {
        string upiID = "your-upi-id@upi";
        string name = "Your Name";
        string note = "Test Payment";
        string amount = "1.00";

        string uri = $"upi://pay?pa={upiID}&pn={name}&tn={note}&am={amount}&cu=INR";

#if UNITY_ANDROID
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        AndroidJavaObject intent = new AndroidJavaObject("android.content.Intent", "android.intent.action.VIEW");
        intent.Call<AndroidJavaObject>("setData", new AndroidJavaObject("android.net.Uri", uri));

        currentActivity.Call("startActivity", intent);
#endif
    }
}
