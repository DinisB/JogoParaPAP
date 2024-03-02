using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoScript : MonoBehaviour
{
    public GameObject enemy;
    public float speed = 5f;
    private float direction = 1f;
    public SpriteRenderer srenemy;
    public Rigidbody2D enemyrb;
	void Start () {
        StartCoroutine(AndarEsquerdaEnemy());
	}


    // Update is called once per frame
    void Update()
    {
        if (direction > 0f)
        {
            enemyrb.velocity = new Vector2(direction * speed, enemyrb.velocity.y);
            srenemy.flipX = false;
        }
        else if (direction < 0f)
        {
            enemyrb.velocity = new Vector2(direction * speed, enemyrb.velocity.y);
            srenemy.flipX = true;
        }
    }

IEnumerator AndarEsquerdaEnemy(){
                direction = -1f;
                yield return new WaitForSeconds(1.5f);
                StartCoroutine(AndarDireitaEnemy());
}

IEnumerator AndarDireitaEnemy(){
                direction = 1f;
                yield return new WaitForSeconds(1.5f);
                StartCoroutine(AndarEsquerdaEnemy());
}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("attack"))
        {
            enemy.SetActive(false);
        }
    }
}
