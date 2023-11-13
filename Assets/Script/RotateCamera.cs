using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    // Kecepatan rotasi kamera
    public float rotationSpeed = 5.0f;

    // Posisi awal ketika sentuh dimulai
    private Vector3 dragStartPosition;

    // Rotasi awal kamera
    private Quaternion startRotation;

    void Update()
    {
        // Cek input sentuh atau klik mouse
        if (Input.GetMouseButtonDown(0))
        {
            // Simpan posisi awal sentuhan atau klik mouse
            dragStartPosition = Input.mousePosition;
            // Simpan rotasi awal kamera
            startRotation = transform.rotation;
        }

        // Cek apakah sentuhan atau klik mouse sedang berlangsung
        if (Input.GetMouseButton(0))
        {
            // Hitung perubahan posisi mouse
            Vector3 delta = Input.mousePosition - dragStartPosition;

            // Hitung rotasi baru berdasarkan perubahan posisi mouse
            Quaternion rotation = startRotation * Quaternion.Euler(new Vector3(0, -delta.x * rotationSpeed, 0));

            // Terapkan rotasi ke kamera
            transform.rotation = rotation;
        }
    }
}
