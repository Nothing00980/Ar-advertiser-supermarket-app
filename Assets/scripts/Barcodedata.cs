
using UnityEngine;

[CreateAssetMenu]
public class Barcodedata : ScriptableObject
{
    public string barcode;
    public void populatebarcode(string bar){
        this.barcode = bar;
    }
  
}
