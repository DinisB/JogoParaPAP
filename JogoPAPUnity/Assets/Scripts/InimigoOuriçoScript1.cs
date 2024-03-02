using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoOuriçoScript1 : MonoBehaviour
{
    public GameObject enemy;
    public float speed = 3f;
    private float direction = 1f;
    public SpriteRenderer srenemy;
    public Rigidbody2D enemyrb;
    private Animator anim;
	void Start () {
        anim = GetComponent<Animator>();
        StartCoroutine(AndarEsquerdaEnemy());
	}


    // Update is called once per frame
    void Update()
    {
        if (direction > 0f)
        {
            enemyrb.velocity = new Vector2(direction * speed, enemyrb.velocity.y);
            srenemy.flipX = true;
        }
        else if (direction < 0f)
        {
            enemyrb.velocity = new Vector2(direction * speed, enemyrb.velocity.y);
            srenemy.flipX = false;
        }
    }

IEnumerator AndarEsquerdaEnemy(){
                direction = -1f;
                speed = 3f;
                anim.Play("Andar");
                yield return new WaitForSeconds(1.5f);
                direction = 0f;
                speed = 0f;
                anim.Play("Parado");
                yield return new WaitForSeconds(1.5f);
                StartCoroutine(AndarDireitaEnemy());
}

IEnumerator AndarDireitaEnemy(){
                direction = 1f;
                speed = 3f;
                anim.Play("Andar");
                yield return new WaitForSeconds(1.5f);
                direction = 0f;
                speed = 0f;
                anim.Play("Parado");
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
