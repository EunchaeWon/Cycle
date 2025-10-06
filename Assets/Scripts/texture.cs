using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class texture : MonoBehaviour
{
    
    public MeshRenderer mesh;
    public Animator anim;
    // Start is called before the first frame update
    private void Awake()
    {
        MeshRenderer mesh = GetComponent<MeshRenderer>();
        Animator anim = GetComponent<Animator>();
        mesh.material = mesh.materials[0];
    }

    // Update is called once per frame

}
