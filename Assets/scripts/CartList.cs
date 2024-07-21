using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "CartList", menuName = "ScriptableObjects/CartList", order = 1)]
public class CartList : ScriptableObject
{
    public List<CartItemData> list = new List<CartItemData>();

    public void AddItem(Products product)
    {
        if (ItemExists(product))
        {
            Debug.Log("Item already in cart");
            return;
        }


        CartItemData newItem = new CartItemData
        {
            productName = product.name,
            productPrice = product.price,
            quantity = 1,
            weight = product.weight,
            imagename = product.imagename
        };

        list.Add(newItem);
    }


    public bool ItemExists(Products product)
    {
        foreach (CartItemData item in list)
        {
            if (item.productName == product.name) // Compare based on name, or use a unique identifier like product ID
            {
                return true;
            }
        }
        return false;
    }

    public void ClearList()
    {
        list.Clear();
    }
}

[System.Serializable]
public class CartItemData
{
    public string productName;
    public int quantity;
    public float productPrice;

    public string weight;

    public string imagename;
}
