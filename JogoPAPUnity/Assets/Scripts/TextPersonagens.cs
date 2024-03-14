using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPersonagens : MonoBehaviour
{
    public GameObject texto;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.CompareTag("Player"))
            {
                texto.SetActive(true);
            }
    }

        void OnTriggerExit2D(Collider2D col){
        if (col.gameObject.CompareTag("Player"))
            {
                texto.SetActive(false);
            }
    }
}
