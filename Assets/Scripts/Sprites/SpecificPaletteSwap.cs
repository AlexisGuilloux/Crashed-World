using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecificPaletteSwap : MonoBehaviour
{
    private Color baseColor; // base color
    private Color featColor; // feat color

    public bool isMesh = false;

    // Start is called before the first frame update
    void Start()
    {
        baseColor = Random.ColorHSV(0f, 1f, 0.5f, 0.85f, 0.7f, 0.9f);
        featColor = Random.ColorHSV(0f, 1f, 0.5f, 0.85f, 0.7f, 0.9f);
        if (isMesh)
        {
                GetComponent<MeshRenderer>().material.EnableKeyword("_Color");
                GetComponent<MeshRenderer>().material.EnableKeyword("_FeatColor");
                GetComponent<MeshRenderer>().material.SetColor("_Color", baseColor);
                GetComponent<MeshRenderer>().material.SetColor("_FeatColor", featColor);
                Debug.Log("oui");
                return;
        }
            GetComponent<SpriteRenderer>().material.EnableKeyword("_Color");
            GetComponent<SpriteRenderer>().material.EnableKeyword("_FeatColor");
            GetComponent<SpriteRenderer>().material.SetColor("_Color", baseColor);
            GetComponent<SpriteRenderer>().material.SetColor("_FeatColor", featColor);
    }
}
