using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProxNivel : MonoBehaviour
{
    public string sceneName;
    void OnTriggerStay2D(Collider2D col){
        if (col.gameObject.CompareTag("Player") && Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene(sceneName);
            }
    }
}
