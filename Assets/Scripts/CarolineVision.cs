using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarolineVision : MonoBehaviour
{
    public Material material;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (material == null)
            Graphics.Blit(source, destination);

        Graphics.Blit(source, destination, material);
    }
}
