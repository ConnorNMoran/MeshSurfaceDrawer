using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTexture : MonoBehaviour
{
    public Texture texture;

    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<Renderer>().material.SetTexture("_MainTex", Instantiate(texture));
    }
}
