using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInitializer : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene("cartpage", LoadSceneMode.Additive);
    }
}
