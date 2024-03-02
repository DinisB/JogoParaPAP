using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoVoadorScript : MonoBehaviour
{
    public GameObject projectilePrefab;
    private GameObject clonedPrefab;
    public GameObject enemy;
    public GameObject Dust;
    public Rigidbody2D enemyrb;
	void Start () {
        StartCoroutine(BolaSpawn());
	}


    // Update is called once per frame
    void Update()
    {

    }

IEnumerator BolaSpawn(){
                clonedPrefab = Instantiate(projectilePrefab, transform.position, Quaternion.identity) as GameObject;
                yield return new WaitForSeconds(.75f);
                Destroy(clonedPrefab);
                Dust.SetActive(true);
                yield return new WaitForSeconds(1.5f);
                Dust.SetActive(false);
                StartCoroutine(BolaSpawn());
}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("attack"))
        {
            Destroy(clonedPrefab);
            enemy.SetActive(false);
        }
    }
}
