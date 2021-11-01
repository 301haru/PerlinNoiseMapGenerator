using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraAnchor : MonoBehaviour
{
    public Slider slider;
    private Camera thisCamera;

    void Update()
    {
        GameManager.Instance.Movement(transform);
    }

    public void onSliderZoomChanged()
    {
        thisCamera = GetComponent<Camera>();

        thisCamera.orthographicSize = slider.value;
    }
}
