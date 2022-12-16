using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDistanceCulling : MonoBehaviour
{
    private static uint CAMERA_LAYOUT_COUNT = 32;

    public float[] cullDistances = new float[CAMERA_LAYOUT_COUNT];
    public float zoomScaleFactor = 2;

    private float[] adjustedCullDistances = new float[CAMERA_LAYOUT_COUNT];
    private Camera m_cam;
    private float m_normalizedZoom = 0;


    // Start is called before the first frame update
    void Start()
    {
        m_cam = GetComponent<Camera>();
        if (m_cam)
        {
            adjustedCullDistances = (float[])cullDistances.Clone();
            m_cam.layerCullDistances = adjustedCullDistances;
            m_cam.layerCullSpherical = true;
        }
    }

    public void OnEnable()
    {
        if (m_cam)
        {
            m_cam.layerCullDistances = adjustedCullDistances;
            UpdateZoom(m_normalizedZoom);
        }
    }

    public void OnDisable()
    {
        if (m_cam)
        {
            float[] noCullDistances = new float[32];
            m_cam.layerCullDistances = noCullDistances;
        }
    }

    public void UpdateZoom(float normalizedZoom)
    {
        m_normalizedZoom = normalizedZoom;
        for (int i = 0; i < cullDistances.Length; ++i)
        {
            // zoomScaleFactor = 1 means that with full zoom out cullDistances are doubled.
            adjustedCullDistances[i] = cullDistances[i] + (zoomScaleFactor * m_normalizedZoom * cullDistances[i]);
            m_cam.layerCullDistances = adjustedCullDistances;
        }
    }
}