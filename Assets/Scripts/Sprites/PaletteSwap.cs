using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletteSwap : MonoBehaviour
{
    private Color baseColor; // base color
    private Color featColor; // feat color

    // Start is called before the first frame update
    void Start()
    {
        baseColor = Random.ColorHSV(0f, 1f, 0.5f, 0.75f, 0.7f, 0.9f);
        featColor = Random.ColorHSV(0f, 1f, 0.5f, 0.75f, 0.7f, 0.9f);

        foreach (Transform child in transform)
        {
            child.GetComponent<SpriteRenderer>().material.EnableKeyword("_Color");
            child.GetComponent<SpriteRenderer>().material.EnableKeyword("_FeatColor");
            child.GetComponent<SpriteRenderer>().material.SetColor("_Color", baseColor);
            child.GetComponent<SpriteRenderer>().material.SetColor("_FeatColor", featColor);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
