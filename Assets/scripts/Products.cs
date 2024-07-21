
using System;
using UnityEngine;
[CreateAssetMenu]
public class Products : ScriptableObject
{

    public string code;
    public string name;
    public string productdes;
    public string imagename;
    public int price;
    public string weight;
    public string cal;
    public string protein;
    public string sodium;
    public string sugar;

    public void populateProducts(string code, string name,string productdes,string imagename, int price, string weight, string cal, string protein, string sodium, string sugar) {
        this.code = code;
        this.name = name;
        this.productdes = productdes;
        this.imagename = imagename;
        this.price = price;
        this.weight = weight;
        this.cal = cal;
        this.protein= protein;
        this.sodium = sodium;
        this.sugar = sugar;
    
    }
  
}
