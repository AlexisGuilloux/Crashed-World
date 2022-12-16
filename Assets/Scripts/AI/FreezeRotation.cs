using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeRotation : MonoBehaviour
{
    Quaternion iniRot;

    void Start()
    {
        iniRot = transform.rotation;
    }

    void Update()
    {
        transform.rotation = iniRot;
    }
}
