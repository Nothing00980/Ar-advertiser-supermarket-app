using System.IO;
using System.Net;
using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class respose
{
    public bool success;
    public productdetails item;
}

[System.Serializable]
public class productdetails
{
    public string _id;
    public string barcode;
    public string productName;
    public string productdes;
    public string imageName;
    public string quantity;
    public int price;
    public string calories;
    public string protein;
    public string sodium;
    public string sugar;
    public int __v;
}

public class sendbarcode : MonoBehaviour
{
    public GameObject productpage;

    private string imgurl;
    public static int count = 0;
    public string backendURL = "http://localhost:3000/barcode-fetch";

    private respose pd;
    public Products pb;

    public Barcodedata barcode;

    public GameObject loadinggif;

    public TextMeshProUGUI pname;
    public TextMeshProUGUI pquantity;
    public TextMeshProUGUI pprice;

    public TextMeshProUGUI pdescription;

    public TextMeshProUGUI pcal;
    public TextMeshProUGUI pprotein;
    public TextMeshProUGUI psodium;

    public TextMeshProUGUI psugar;

    public TextMeshProUGUI weight;

    public Image imageComponent;
    public Button addToCartButton;

    public GameObject notify;

    public float activeduration = 1f;

    public CartList cartList;



    private void Awake()
    {
        loadinggif.SetActive(true);
        productpage.SetActive(false);
        notify.SetActive(false);
    }

    void Start()
    {
        StartCoroutine(sendingbarcode());
        addToCartButton.onClick.AddListener(OnAddToCartButtonClick);
    }

    private IEnumerator sendingbarcode()
    {


        yield return StartCoroutine(Worker());
        yield return StartCoroutine(DownloadImagefromurl(imgurl));
        UpdateUI();
        productpage.SetActive(true);
        loadinggif.SetActive(false);
    }

    private IEnumerator Worker()
    {
        try
        {
            string jsonData = "{\"barcode\":\"" + barcode.barcode + "\"}";
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(jsonData);

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
                        pd = JsonUtility.FromJson<respose>(responseFromServer);

                        pb.populateProducts(pd.item.barcode, pd.item.productName, pd.item.productdes, pd.item.imageName, pd.item.price, pd.item.quantity, pd.item.calories, pd.item.protein, pd.item.sodium, pd.item.sugar);

                        imgurl = "http://localhost:3000/uploads/images/" + pd.item.imageName;
                    }
                }
                else
                {
                    Debug.LogError("Error: " + response.StatusCode);
                    SceneManager.LoadScene("barcoderead");
                }
            }
        }
        catch (WebException ex)
        {
            Debug.LogError("WebException: " + ex.Message);
            SceneManager.LoadScene("barcoderead");
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Exception: " + ex.Message);
            SceneManager.LoadScene("barcoderead");
        }
        yield return null;
    }

    private IEnumerator DownloadImagefromurl(string url)
    {
        UnityWebRequest requester = UnityWebRequestTexture.GetTexture(url);

        yield return requester.SendWebRequest();

        if (requester.result == UnityWebRequest.Result.ConnectionError || requester.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(requester.error);
        }
        else
        {
            Texture2D texture = ((DownloadHandlerTexture)requester.downloadHandler).texture;
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            imageComponent.sprite = sprite;
        }
    }

    private void UpdateUI()
    {
        pname.text = pd.item.productName;
        pquantity.text = pd.item.quantity;
        pprice.text = "Rs." + pd.item.price.ToString();
        pdescription.text = pd.item.productdes;
        pcal.text = pd.item.calories;
        pprotein.text = pd.item.protein;
        psodium.text = pd.item.sodium;
        psugar.text = pd.item.sugar;
        weight.text = pd.item.quantity;
    }


    private void OnAddToCartButtonClick()
    {
        Debug.Log("add to cart button click");

        if (cartList.ItemExists(pb))
        {
            Debug.Log("item already exist");
            return;
        }
        else
        {
            cartList.AddItem(pb);
            notify.SetActive(true);
            StartCoroutine(endanim());

        }



    }

    public void completeanim()
    {
        notify.SetActive(false);
    }

    public IEnumerator endanim()
    {

        yield return new WaitForSeconds(activeduration);
        completeanim();
    }


}
