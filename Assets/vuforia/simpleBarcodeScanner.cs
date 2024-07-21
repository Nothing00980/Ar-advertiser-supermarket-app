using System;
using Unity.VisualScripting;
using UnityEngine;
using Vuforia;

public class simpleBarcodeScanner : MonoBehaviour
{
    private string barcode;
    public TMPro.TextMeshProUGUI barcodeAsText;
    BarcodeBehaviour mBarcodeBehaviour;
    void Start()
    {
        mBarcodeBehaviour = GetComponent<BarcodeBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mBarcodeBehaviour != null && mBarcodeBehaviour.InstanceData != null)
        {
            barcodeAsText.text = mBarcodeBehaviour.InstanceData.Text;
            barcode = mBarcodeBehaviour.InstanceData.Text;
            Debug.Log(barcode);
        }
        else
        {
            barcodeAsText.text = "";
            

        }
    }

    public void clickme(){
        Debug.Log("this is the readed barcode " + barcode);
    }
}