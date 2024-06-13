using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Color : MonoBehaviour
{
    public Color startColor;
    public Color endColor;

    [Range(0, 1)]
    public static float t;

    MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        t = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(t < 1 && GetComponent<Gate>().eventPanel.GetComponent<EventPanel>().flag)
        {
            t += Time.deltaTime * 0.8f;
        }
        if (t > 0 && !GetComponent<Gate>().eventPanel.GetComponent<EventPanel>().flag)
        {
            t -= Time.deltaTime * 0.8f;
        }

        meshRenderer.material.SetColor("_Color", Color.Lerp(startColor, endColor, t));
    }
    
    private void OnDestroy()
    {
        if (meshRenderer.material != null)
        {
            Destroy(meshRenderer.material);
            meshRenderer.material = null;
        }
    }
    private void OnApplicationQuit()
    {
        if (meshRenderer.material != null)
        {
            Destroy(meshRenderer.material);
            meshRenderer.material = null;
            Debug.Log("Game is quitting. Saving game data...");
        }
    }
}
