using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using System.Collections;

public class CartItem : MonoBehaviour
{
    public UnityFigmaBridge.Runtime.UI.FigmaImage figmaImage;
    public TextMeshProUGUI productName;
    public TextMeshProUGUI productWeight;
    public TextMeshProUGUI productPrice;  // Reference to the TextMeshProUGUI component for product price
    public TextMeshProUGUI quantityText;  // Reference to the TextMeshProUGUI component for quantity
    public Button incrementButton;  // Reference to the increment button
    public Button decrementButton;  // Reference to the decrement button
    public Button removeButton;

    private CartItemData cartItemData;  // The cart item data associated with this cart item
    private CartManager cartManager;

    private int quantity;

    public void Setup(CartItemData cartItemData, CartManager cartManager)
    {
        this.cartItemData = cartItemData;
        this.cartManager = cartManager;

        productName.text = cartItemData.productName;
        productWeight.text = cartItemData.weight;
        quantity = cartItemData.quantity;
        UpdatePrice();
        UpdateQuantityText();

        gameObject.SetActive(true);
        // Assuming LoadImage method handles the image loading based on product name or other identifier
        StartCoroutine(LoadImage(cartItemData.imagename));

        incrementButton.onClick.AddListener(IncrementQuantity);
        decrementButton.onClick.AddListener(DecrementQuantity);
        removeButton.onClick.AddListener(RemoveItem);
    }

    private void UpdatePrice()
    {
        float totalPrice = cartItemData.productPrice * quantity;
        productPrice.text = $"Rs.{totalPrice:F2}";
        cartManager.UpdateTotalPrice();
    }

    // Method to update the displayed quantity
    private void UpdateQuantityText()
    {
        quantityText.text = quantity.ToString();
    }

    // Method to increment the quantity
    private void IncrementQuantity()
    {

        Debug.Log("incrementing");
        quantity++;
        cartItemData.quantity = quantity;
        UpdateQuantityText();
        UpdatePrice();
    }

    // Method to decrement the quantity
    private void DecrementQuantity()
    {

        Debug.Log("decrementing");

        if (quantity > 1)
        {
            quantity--;
            cartItemData.quantity = quantity;
            UpdateQuantityText();
            UpdatePrice();
        }
    }

    private void RemoveItem()
    {
        cartManager.RemoveFromCart(cartItemData);
        Destroy(gameObject);
    }

    IEnumerator LoadImage(string productName)
    {

        Debug.Log("inside image uploader");
        // Assuming the product image URL is based on the product name
        string url = "http://localhost:3000/uploads/images/" + productName;
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(request.error);
        }
        else
        {
            Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            figmaImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        }
    }

    public float GetTotalPrice()
    {
        return cartItemData.productPrice * cartItemData.quantity;
    }

    // Method to get the quantity for this item
    public int GetQuantity()
    {
        return cartItemData.quantity;
    }

    // Method to get the product name for this item
    public string GetProductName()
    {
        return cartItemData.productName;
    }

    // Method to get the product price for this item
    public float GetProductPrice()
    {
        return cartItemData.productPrice;
    }
}
