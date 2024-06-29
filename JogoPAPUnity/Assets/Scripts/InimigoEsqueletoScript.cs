using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoEsqueletoScript : MonoBehaviour
{
    public GameObject enemy;
    public float speed = 2f;
    private float direction = 1f;
    public SpriteRenderer srenemy;
    public Rigidbody2D enemyrb;
    private int vida = 2;
    public GameObject projectilePrefab;
    private GameObject clonedPrefab;
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
        if (vida > 1) {
            vida -= 1;
            enemyrb.velocity = new Vector2(enemyrb.velocity.x, 5);
            if ((this.transform.position.x - col.transform.position.x) < 0) {
                direction = -1f;
            }
            if ((this.transform.position.x - col.transform.position.x) > 0) {
                direction = 1f;
            }
        }
        else if (vida == 1) {
            vida -= 1;
            clonedPrefab = Instantiate(projectilePrefab, transform.position, Quaternion.identity) as GameObject;
            enemy.SetActive(false);
        }
    }
}
}
