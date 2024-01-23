using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntColorScript : MonoBehaviour
{
    [SerializeField] MeshRenderer[] antMeshRenderer;
    public Color antColor;
    // Start is called before the first frame update
    void Start()
    {
        ChangeColor(antColor);
    }

    public void ChangeColor(Color changeColor)
    {
        foreach (MeshRenderer antMesh in antMeshRenderer)
        {
            antMesh.material.color = changeColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
