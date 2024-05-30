using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepVariables : MonoBehaviour
{
    public float vidabackup;
    public AndarScript ascript;
    public bool firstLevel;
    // Start is called before the first frame update
    void Start()
    {
        if (firstLevel == true) {
        vidabackup = 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        vidabackup = ascript.vida;
    }
}
