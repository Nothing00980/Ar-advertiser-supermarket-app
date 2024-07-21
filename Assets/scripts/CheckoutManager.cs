using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Text;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using System.IO;

public class CheckoutManager : MonoBehaviour
{
    public CartManager cartManager;  // Reference to CartManager
    public string checkoutURL = "http://localhost:3000/checkout";  // URL to send the checkout request

    public userdata userdata;
    public string paymentConfirmation = "payment_confirmed";  // Example payment confirmation (replace with actual data)

    public Button downloadButton;  // Reference to the download button

    private string downloadUrl;    // URL of the generated PDF

    public GameObject paymentcheckout;

    public GameObject success;

    public GameObject error;


    void Start()
    {

        downloadButton.onClick.AddListener(OnDownloadButtonClick);
        downloadButton.interactable = false;
    }

    public void Checkout()
    {
        // Convert cart items to a suitable format
        List<CartItemData> cartItems = new List<CartItemData>();

        foreach (CartItemData item in cartManager.cartList.list)
        {
            cartItems.Add(new CartItemData
            {
                productName = item.productName,
                quantity = item.quantity,
                productPrice = item.productPrice,
                weight = item.weight,
                imagename = item.imagename
            });
        }

        // Create checkout data
        CheckoutData checkoutData = new CheckoutData
        {
            userId = userdata.userId,
            paymentConfirmation = paymentConfirmation,
            cartDetails = cartItems
        };

        // Serialize checkout data to JSON
        string json = JsonUtility.ToJson(checkoutData);

        // Send the data to the server
        StartCoroutine(SendCheckoutData(json));
    }

    private IEnumerator SendCheckoutData(string json)
    {
        using (UnityWebRequest request = new UnityWebRequest(checkoutURL, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + request.error);
            }
            else
            {
                Debug.Log("Response: " + request.downloadHandler.text);
                // Parse the response to get the URL
                DownloadResponse response = JsonUtility.FromJson<DownloadResponse>(request.downloadHandler.text);
                success.SetActive(true);
                error.SetActive(false);


                downloadUrl = response.path;
                downloadButton.interactable = true;

                StartCoroutine(DownloadPDF(downloadUrl));

                // Enable the download button
            }
        }
    }



    public void showpaymentmethod()
    {
        paymentcheckout.SetActive(true);

    }

    public void tryagain()
    {
        error.SetActive(false);

    }

    private IEnumerator DownloadPDF(string url)
    {

        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error downloading PDF: " + request.error);
            }
            else
            {
                // Get the downloaded data
                byte[] pdfData = request.downloadHandler.data;

                // Save the PDF to the device
                string path = Path.Combine(Application.persistentDataPath, "invoice.pdf");
                File.WriteAllBytes(path, pdfData);

                Debug.Log("PDF downloaded and saved to: " + path);

                // Optionally, you can open the PDF or notify the user
                // OpenPDF(path);
            }


        }
    }

    private void OnDownloadButtonClick()
    {
        // Start the download coroutine when the button is clicked
        if (!string.IsNullOrEmpty(downloadUrl))
        {
            StartCoroutine(DownloadPDF(downloadUrl));
        }
    }


    public void ShowEBill()
    {

        Application.OpenURL(downloadUrl);
        // Initialize UniWebView

    }




}

[System.Serializable]
public class CheckoutData
{
    public string userId;
    public string paymentConfirmation;
    public List<CartItemData> cartDetails;
}



[System.Serializable]
public class DownloadResponse
{
    public string path;
}
