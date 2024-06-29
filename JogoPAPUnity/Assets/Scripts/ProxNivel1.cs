using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProxNivel1 : MonoBehaviour
{
    public string sceneName;
    public GameObject backup;
    public GameObject musica;
    public bool continuarmusica = false;
    public bool destruirmusica = false;
    void OnTriggerStay2D(Collider2D col){
        if (col.gameObject.CompareTag("Player"))
            {
                if (backup != null){
                DontDestroyOnLoad(backup);
                }
                if (continuarmusica == true) {
                    DontDestroyOnLoad(musica);
                }
                if (destruirmusica == true) {
                    musica = GameObject.FindWithTag("musica");
                    Destroy(musica);
                }
                SceneManager.LoadScene(sceneName);
            }
    }
}
