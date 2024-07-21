
using UnityEngine;

public class PhoneNumberManager : MonoBehaviour
{
    public static PhoneNumberManager instance;

    public string phonenumber;
    private void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }
   
}
