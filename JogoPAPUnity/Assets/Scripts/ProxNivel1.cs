using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProxNivel1 : MonoBehaviour
{
    public string sceneName;
    public GameObject backup;
    void OnTriggerStay2D(Collider2D col){
        if (col.gameObject.CompareTag("Player"))
            {
                if (backup != null){
                DontDestroyOnLoad(backup);
                }
                SceneManager.LoadScene(sceneName);
            }
    }
}
