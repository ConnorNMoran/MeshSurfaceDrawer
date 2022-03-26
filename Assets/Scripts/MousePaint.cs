using UnityEngine;
using System;

[RequireComponent(typeof(Camera))]
public class MousePaint : MonoBehaviour
{
    public Camera mainCamera;

    public Color brushColor;
    public int   brushSize;

    void Start()
    {
        mainCamera = GetComponent<Camera>();
        brushColor = Color.white;
        brushSize  = 5;
    }

    void Update()
    {
        try
        {
            //Stop function when mouse is let go
            if (!Input.GetMouseButton(0))
            {
                return;
            }

            //Make sure ray is hitting an object 
            RaycastHit hit;
            if (!Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                return;
            }

            Renderer rend = hit.transform.GetComponent<Renderer>();
            MeshCollider meshCollider = hit.collider as MeshCollider;

            //Stop function if the following components aren't present
            if (rend == null ||
                rend.sharedMaterial == null ||
                rend.sharedMaterial.mainTexture == null ||
                meshCollider == null)
            {
                return;
            }

            //Get texture information
            Texture2D tex = rend.material.mainTexture as Texture2D;
            Vector2 pixelUV = hit.textureCoord;
            pixelUV.x *= tex.width;
            pixelUV.y *= tex.height;

            var colors = new Color[brushSize * brushSize];

            //Set brush to color
            for (var i = 0; i < brushSize * brushSize; i++)
            {
                colors[i] = brushColor;
            }

            //Draw the pixels
            //tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, brushColor);
            tex.SetPixels((int)pixelUV.x, (int)pixelUV.y, brushSize, brushSize, colors);
            tex.Apply();
        }
        catch (Exception ex)
        {
            if (!ex.Message.Contains("Texture2D.SetPixels: the size of data"))
            {
                throw new InvalidOperationException("Error: " + ex.Message);
            }
        }
    }
}