using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class AutoSceneSwitch : MonoBehaviour
{
    public float idleTime = 30f; // Time in seconds before switching to idle scene
    private float timer;

    public UnityEvent onIdleSceneSwitch; // Event to be triggered when switching to idle scene

    void Update()
    {
        // Check for any user input
        if (Input.anyKey || Input.GetMouseButtonDown(0))
        {
            // Reset the timer if there's any input
            timer = 0f;
        }
        else
        {
            // Increment the timer if there's no input
            timer += Time.deltaTime;

            // Check if the idle time has been reached
            if (timer >= idleTime)
            {
                // Trigger the event before switching to the idle scene
                onIdleSceneSwitch.Invoke();

                // Switch to the idle scene
                SceneManager.LoadScene("1. OnBoarding");
            }
        }
    }
}
