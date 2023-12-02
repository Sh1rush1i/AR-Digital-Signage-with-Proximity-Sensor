using UnityEngine;

public class TouchLook : MonoBehaviour
{
    [Header("Touch Settings")]
    public bool TouchLookEnabled;

    [Header("Movement Settings")]
    [SerializeField] private float sensitivity = 0.1f;
    [SerializeField] private float smoothness = 0.5f;

    private Vector2 lastTouchPosition;
    private Vector2 currentTouchPosition;
    private Vector2 smoothDeltaPosition;

    void Update()
    {
        if (TouchLookEnabled)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                ProcessTouch(touch);
            }
            else if (Input.GetMouseButtonDown(0)) // Tambahkan pengolahan sentuhan mouse
            {
                ProcessMouseTouch(Input.mousePosition);
            }
        }
    }

    void ProcessTouch(Touch touch)
    {
        if (touch.phase == TouchPhase.Moved)
        {
            currentTouchPosition = touch.position;
            Vector2 deltaPosition = currentTouchPosition - lastTouchPosition;
            smoothDeltaPosition = Vector2.Lerp(smoothDeltaPosition, deltaPosition, smoothness);
            UpdateRotation();
            lastTouchPosition = currentTouchPosition;
        }
        else if (touch.phase == TouchPhase.Began)
        {
            lastTouchPosition = touch.position;
            smoothDeltaPosition = Vector2.zero;
        }
        else if (touch.phase == TouchPhase.Ended)
        {
            smoothDeltaPosition = Vector2.zero;
        }
    }

    void ProcessMouseTouch(Vector2 mousePosition)
    {
        currentTouchPosition = mousePosition;
        Vector2 deltaPosition = currentTouchPosition - lastTouchPosition;
        smoothDeltaPosition = Vector2.Lerp(smoothDeltaPosition, deltaPosition, smoothness);
        UpdateRotation();
        lastTouchPosition = currentTouchPosition;
    }

    void UpdateRotation()
    {
        transform.Rotate(-smoothDeltaPosition.y * sensitivity, 0, 0);
        transform.Rotate(0, smoothDeltaPosition.x * sensitivity, 0, Space.World);
    }
}
