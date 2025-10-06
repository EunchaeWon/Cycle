using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureObject : MonoBehaviour
{
 
    public int videoNo;
    void Awake()
    {
        var videoPlayer = gameObject.AddComponent<UnityEngine.Video.VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
