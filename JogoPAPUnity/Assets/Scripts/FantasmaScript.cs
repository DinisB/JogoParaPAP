using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FantasmaScript : MonoBehaviour
{
    public string sceneName = "Titulo";
    public float speed = 5f;
    public Rigidbody2D enemyrb;
	void Start () {
        StartCoroutine(FantasmaSpawn());
	}
    IEnumerator FantasmaSpawn(){
                yield return new WaitForSeconds(2f);
                SceneManager.LoadScene(sceneName);
}
    // Update is called once per frame
    void Update()
    {
        enemyrb.velocity = new Vector2(enemyrb.velocity.x, speed);
    }
}
