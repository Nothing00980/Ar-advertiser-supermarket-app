using UnityEngine;
using UnityEngine.Events;

public class EventListener : MonoBehaviour
{
    public static EventListener Instance { get; private set; }

    public UnityEvent onSomeEvent;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void TriggerSomeEvent()
    {
        onSomeEvent?.Invoke();
    }
}
