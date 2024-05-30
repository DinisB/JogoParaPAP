using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyvars : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject backup;
    void Start()
    {
        backup = GameObject.Find("/Keep vars");
        Destroy(backup);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
