using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolinhasScript : MonoBehaviour
{
    public float speed = -5f;
    public Rigidbody2D enemyrb;
	void Start () {
	}


    // Update is called once per frame
    void Update()
    {
        enemyrb.velocity = new Vector2(enemyrb.velocity.x, speed);
    }


}
