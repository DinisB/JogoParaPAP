using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndarScript : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject playerobj;
    public float speed = 5f;
    private bool triggeredgirl = false;
    public GameObject textodevida;
    public float vida = 3;
    public float maxvida = 3;
    public int directionattack = 1;
    public float jumpSpeed = 8f;
    private float direction = 0f;
    private Rigidbody2D player;
    private bool isGrounded;
    private bool isAttacking;
    private bool CanWalk = true;
    private Animator playeranim;
    private SpriteRenderer sr;
    public GameObject ataquedireita;
    public GameObject ataqueesquerda;
    public GameObject cora1;
    public GameObject cora2;
    public GameObject cora3;
    public AudioSource saltarsom;
    public AudioSource atacarsom;
    public AudioSource magoadosom;
    public bool PlayerHurt = false;
    public GameObject backup;
    private GameObject musica;

    // Start is called before the first frame update
    void Start()
    {
        backup = GameObject.Find("/Keep vars");
        if (backup == null) {
            vida = 3;
        }
        else {
            vida = backup.GetComponent<KeepVariables>().vidabackup;
        }
        isGrounded = false;
        playeranim = GetComponent<Animator>();
        player = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        playeranim.SetBool("Jump", true);
        playeranim.SetBool("Walk", false);
    }

    void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("ground"))
            {
                isGrounded = true;
                playeranim.SetBool("Jump", false);
            }


        if (collision.gameObject.CompareTag("enemy") && PlayerHurt == false)
        {
            vida -= 1;
            PlayerHurt = true;
            player.velocity = new Vector2(player.velocity.x, 4);
            CanWalk = false;
            direction = 0f;
            playeranim.SetBool("Hurt", true);
            if ((this.transform.position.x - collision.collider.transform.position.x) < 0) {
                StartCoroutine(HurtDireita());
            }
            if ((this.transform.position.x - collision.collider.transform.position.x) > 0) {
                StartCoroutine(HurtEsquerda());
            }
            IEnumerator HurtDireita(){
                magoadosom.Play();
                direction = -1f;
                playeranim.Play("Hurt");
                yield return new WaitForSeconds(0.6f);
                direction = 0f;
                playeranim.SetBool("Hurt", false);
                CanWalk = true;
                PlayerHurt = false;
        }
            IEnumerator HurtEsquerda(){
                magoadosom.Play();
                direction = 1f;
                playeranim.Play("Hurt");
                yield return new WaitForSeconds(0.6f);
                direction = 0f;
                playeranim.SetBool("Hurt", false);
                CanWalk = true;
                PlayerHurt = false;
        }
        }
    }

    void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("ground"))
            {
                isGrounded = true;
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

        if (Input.GetButtonDown("Fire1") && triggeredgirl){
            vida = 3;
            cora1.SetActive(true);
            cora2.SetActive(true);
            cora3.SetActive(true);
        }   

        if (CanWalk){
            direction = Input.GetAxis("Horizontal");
        }

        if (vida ==3){
            cora1.SetActive(true);
            cora2.SetActive(true);
            cora3.SetActive(true);
        }

        if (vida ==2){
            cora1.SetActive(true);
            cora2.SetActive(true);
            cora3.SetActive(false);
        }

        if (vida ==1){
            cora1.SetActive(true);
            cora2.SetActive(false);
            cora3.SetActive(false);
        }

        if (vida ==0){
            cora1.SetActive(false);
            cora2.SetActive(false);
            cora3.SetActive(false);
            musica = GameObject.FindWithTag("musica");
            Destroy(musica);
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            playerobj.SetActive(false);
        }

        if (direction > 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            playeranim.SetBool("Walk", true);
            directionattack = 1;
            sr.flipX = false;
        }
        else if (direction < 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            playeranim.SetBool("Walk", true);
            directionattack = 0;
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
                saltarsom.Play();
            }
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (isAttacking){
            }
            if (directionattack == 1 && isAttacking == false) {
                StartCoroutine(AttackAnimeDireita());
            }

            if (directionattack == 0 && isAttacking == false) {
                StartCoroutine(AttackAnimeEsquerda());
            }
        }
        IEnumerator AttackAnimeDireita(){
            atacarsom.Play();
            ataquedireita.SetActive(true);
            CanWalk = false;
            isAttacking = true;
            direction = 0f;
            playeranim.SetBool("Attack", true);
            yield return new WaitForSeconds(0.65f);
            playeranim.SetBool("Attack", false);
            isAttacking = false;
            CanWalk = true;
            ataquedireita.SetActive(false);
        }

        IEnumerator AttackAnimeEsquerda(){
            atacarsom.Play();
            ataqueesquerda.SetActive(true);
            CanWalk = false;
            isAttacking = true;
            direction = 0f;
            playeranim.SetBool("Attack", true);
            yield return new WaitForSeconds(0.65f);
            playeranim.SetBool("Attack", false);
            isAttacking = false;
            CanWalk = true;
            ataqueesquerda.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.CompareTag("restaura"))
            {
                textodevida.SetActive(true);
                triggeredgirl = true;
            }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("restaura"))
            {
                textodevida.SetActive(false);
                triggeredgirl = false;
            }  
    }

}
