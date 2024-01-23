using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoScript : MonoBehaviour
{
    public GameObject enemy;
	void Start () {
	}


    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("attack"))
        {
            enemy.SetActive(false);
        }
    }
}
