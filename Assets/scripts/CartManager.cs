using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;

public class CartManager : MonoBehaviour
{
    public Transform cartContent; // Reference to the content panel in the cart UI
    public GameObject cartItemPrefab; // Reference to the cart item prefab

    public CartList cartList;

    public TextMeshProUGUI totalPriceText;
    public TextMeshProUGUI totalPriceTextconfirm;

    public GameObject emptyCartUI; // Reference to the empty cart UI GameObject
    public GameObject cartUI;

    // public static CartManager Instance { get; private set; }

    // private void Awake()
    // {
    //     if (Instance != null && Instance != this)
    //     {
    //         Destroy(this.gameObject);
    //     }
    //     else
    //     {
    //         Instance = this;
    //         DontDestroyOnLoad(this.gameObject);
    //     }
    // }

    private void OnEnable()
    {
        // Add listener for scene changes
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Remove listener for scene changes
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Update cart UI whenever a new scene is loaded
        UpdateCartUI();
    }








    public void UpdateCartUI()
    {
        // Clear existing cart items in the UI
        foreach (Transform child in cartContent)
        {
            Destroy(child.gameObject);
        }

        // Populate cart items in the UI
        foreach (CartItemData item in cartList.list)
        {
            GameObject cartItemObject = Instantiate(cartItemPrefab, cartContent);
            CartItem cartItem = cartItemObject.GetComponent<CartItem>();
            cartItem.Setup(item, this);
        }

        // Update total price
        UpdateTotalPrice();

        // Check if cart is empty
        if (cartList.list.Count == 0)
        {
            emptyCartUI.SetActive(true);
            cartUI.SetActive(false);
        }
        else
        {
            emptyCartUI.SetActive(false);
            cartUI.SetActive(true);
        }
    }

    void CalculateTotalPrice()
    {
        float totalPrice = 0f;

        foreach (CartItemData cartItemData in cartList.list)
        {
            totalPrice += cartItemData.productPrice * cartItemData.quantity;
        }

        totalPriceText.text = $"Total Price: Rs{totalPrice:F2}";
        totalPriceTextconfirm.text = $"Rs{totalPrice:F2}";
    }

    public void UpdateTotalPrice() // Add this method
    {
        CalculateTotalPrice();
    }

    public void ClearCart()
    {
        cartList.ClearList();
        UpdateCartUI();
    }

    public void RemoveFromCart(CartItemData item)
    {
        cartList.list.Remove(item);
        UpdateCartUI();
    }







}


