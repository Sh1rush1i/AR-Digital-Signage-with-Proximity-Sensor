using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Events;

public class ImageCamera : MonoBehaviour
{
    [Header("WebCamera List")]
    public int WebCamIndex = 0;
    public List<string> availableDevices = new List<string>();
    public WebCamDevice[] devices;
    private WebCamTexture webCameraTexture;

    [Header("Event Settings")]
    public UnityEvent StartEvents;
    public UnityEvent UpdateEvents;

    private RawImage rawImage;

    void Start()
    {
        StartEvents?.Invoke();
    }

    public void Stop()
    {
        webCameraTexture.Stop();
    }

    public void Play()
    {
        devices = WebCamTexture.devices;
        foreach (var device in devices)
        {
            availableDevices.Add(device.name);
        }

        rawImage = GetComponent<RawImage>();

        webCameraTexture = new WebCamTexture(devices[WebCamIndex].name);
        webCameraTexture.requestedWidth = 640; // Atur sesuai kebutuhan
        webCameraTexture.requestedHeight = 480; // Atur sesuai kebutuhan
        webCameraTexture.Play();
    }

    public void InvokeImageCamera()
    {
        devices = WebCamTexture.devices;
        foreach (var device in devices)
        {
            availableDevices.Add(device.name);
        }

        rawImage = GetComponent<RawImage>();
        webCameraTexture = new WebCamTexture(devices[WebCamIndex].name);
        webCameraTexture.requestedWidth = 640; // Atur sesuai kebutuhan
        webCameraTexture.requestedHeight = 480; // Atur sesuai kebutuhan
        webCameraTexture.Play();
    }

    void Update()
    {
        if (webCameraTexture.isPlaying)
        {
            rawImage.texture = webCameraTexture;
        }

        UpdateEvents?.Invoke();
    }
}
