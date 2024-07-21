
using UnityEngine;
using TMPro;

public class pop : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI head;
    public TextMeshProUGUI maintext;
    

    public GameObject popwindow;
    public void OnClickDisableObject()
    {
        // Check if the referenced object is not null
        // if (popwindow != null)
        // {
            // Disable the referenced object
            popwindow.SetActive(false);
        // }
        // else
        // {
        //     Debug.LogWarning("objectToDisable is null. Please assign it in the Inspector.");
        // }
    }
    public void onclickenable(){
        popwindow.SetActive(true);
    }

     public void ChangeTextValuehead(string newText)
    {
        if (head != null)
        {
            head.text = newText;
        }
        else
        {
            Debug.LogWarning("TextMeshPro component is not assigned!");
        }
    }

     public void ChangeTextValuemaintext(string newText)
    {
        if (maintext != null)
        {
            maintext.text = newText;
        }
        else
        {
            Debug.LogWarning("TextMeshPro component is not assigned!");
        }
    }
}
