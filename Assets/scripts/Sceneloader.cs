using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    private void Start()
    {
          if (!SceneManager.GetSceneByName("persistent").isLoaded)
        {
            SceneManager.LoadScene("persistent", LoadSceneMode.Additive);
        }
        
    }

   
}
