using UnityEngine;
using UnityEngine.Events;

public class IdleSceneManager : MonoBehaviour
{
    public UnityEvent onIdleSceneStart; // Event to be triggered when the idle scene starts

    void Start()
    {
        // Trigger the event when the idle scene starts
        onIdleSceneStart.Invoke();
    }
}
