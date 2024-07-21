using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialSceneLoader : MonoBehaviour
{
    private void Start()
    {
        // Ensure the PersistentScene is loaded additively
        SceneManager.LoadScene("GOd", LoadSceneMode.Additive);
    }
}
