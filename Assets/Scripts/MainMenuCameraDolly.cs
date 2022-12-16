using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCameraDolly : MonoBehaviour
{
    private Transform mainCamera;
    private Vector3 targetPosition;
    private Vector3 velocity = Vector3.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = this.transform;
        var position = mainCamera.position;
        targetPosition = new Vector3(position.x, position.y, position.z + 70f);
    }
    
    private void LateUpdate()
    {
        // update position
        mainCamera.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, 30f);
    }
}
