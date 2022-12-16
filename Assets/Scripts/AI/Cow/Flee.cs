using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    public void IsFlee()
    {
        Vector3 direction = transform.position - target.position;

        if (direction.sqrMagnitude < 25f)
        {
            transform.Translate(direction.normalized * Time.deltaTime, Space.World);
            transform.forward = direction.normalized;
        }
    }
}
