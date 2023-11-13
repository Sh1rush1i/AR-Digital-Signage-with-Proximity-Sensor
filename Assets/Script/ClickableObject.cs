using UnityEngine;
using UnityEngine.Events;

public class ClickableObject : MonoBehaviour
{
    // Unity Event yang akan dipicu saat objek diklik
    public UnityEvent onClick;

    void Update()
    {
        // Cek input klik mouse atau sentuhan
        if (Input.GetMouseButtonDown(0))
        {
            // Raycast dari titik klik mouse ke dunia 3D
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Cek apakah ada objek yang terkena ray
            if (Physics.Raycast(ray, out hit))
            {
                // Cek apakah objek yang terkena memiliki komponen ClickableObject
                ClickableObject clickableObject = hit.collider.GetComponent<ClickableObject>();
                if (clickableObject != null)
                {
                    // Panggil Unity Event saat objek diklik
                    clickableObject.onClick.Invoke();
                }
            }
        }
    }
}
