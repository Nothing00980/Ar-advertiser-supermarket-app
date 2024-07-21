
using UnityEngine;

public class dashboard : MonoBehaviour
{
   public userdata userdata;

   public void Start(){
        Debug.Log(userdata.email);
   }
}
