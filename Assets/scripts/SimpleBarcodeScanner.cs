using UnityEngine;
using Vuforia;
using TMPro;
using UnityEngine.SceneManagement;

public class SimpleBarcodeScanner : MonoBehaviour
{
    BarcodeBehaviour mBarcodeBehaviour;

    public static string barcodeData;
    public Barcodedata barcodedata;


    


    void Start()
    {
        barcodedata.populatebarcode("");
        mBarcodeBehaviour = GetComponent<BarcodeBehaviour>();
    }

    
    void Update()
    {
        
        if (mBarcodeBehaviour != null && mBarcodeBehaviour.InstanceData != null)
        {
            barcodeData = mBarcodeBehaviour.InstanceData.Text;
            if(barcodeData != ""){
                barcodedata.populatebarcode(barcodeData);
                SceneManager.LoadScene("Productpage");
            }

           
            

            

        }
       
    }

    
}