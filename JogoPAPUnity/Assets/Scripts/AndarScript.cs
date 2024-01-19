using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndarScript : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 8f;
    private float direction = 0f;
    private Rigidbody2D player;
    private bool isGrounded;
    private bool isAttacking;
    private bool CanWalk = true;
    private Animator playeranim;
    private SpriteRenderer sr;
    public BoxCollider2D ataquedireita;

    // Start is called before the first frame update
    void Start()
    {
        playeranim = GetComponent<Animator>();
        player = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
            playeranim.SetBool("Jump", false);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CanWalk){
            direction = Input.GetAxis("Horizontal");
        }

        if (direction > 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            playeranim.SetBool("Walk", true);
            sr.flipX = false;
        }
        else if (direction < 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            playeranim.SetBool("Walk", true);
            sr.flipX = true;
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
            playeranim.SetBool("Walk", false);
        }


        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                playeranim.SetBool("Jump", true);
                player.velocity = new Vector2(player.velocity.x, jumpSpeed);
            }
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (isAttacking){

            }
            else {
                StartCoroutine(AttackAnime());
            }
        }
        IEnumerator AttackAnime(){
            ataquedireita.isTrigger = false;
            CanWalk = false;
            isAttacking = true;
            direction = 0f;
            playeranim.SetBool("Attack", true);
            yield return new WaitForSeconds(0.5f);
            playeranim.SetBool("Attack", false);
            isAttacking = false;
            CanWalk = true;
            ataquedireita.isTrigger = true;
        }
    }
}
