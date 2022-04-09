using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Update is called once per frame
    Rigidbody2D playerBody;
    public float movSpeed = 5.0f;
    public int bounceSpeed = 10;
    public int min = 8;
    public int max = 8;


    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //deactivate rigidbody and move it away
            collision.collider.isTrigger = true;
            collision.transform.position = new Vector3(-15, -8, 0);

            //zero out all movement variables
            playerBody.angularVelocity = 0;
            playerBody.rotation = 0;
            playerBody.velocity = new Vector2 (0,0);
            playerBody.inertia = 0;

            //choose random vector direction
            playerBody.rotation = Random.RandomRange(0, 180);
            // move in that direction
            playerBody.velocity = new Vector2(Random.Range(min, max), Random.Range(min, max));
            //playerBody.velocity = new Vector2(min, max);
        }
    }

    void Update()
    {
        //move left 
        if (Input.GetKey(KeyCode.A))
        {
            //rigidbody moves left 
            playerBody.AddForce(new Vector3(-movSpeed, 0, 0));
        }
        //move right
        if (Input.GetKey(KeyCode.D))
        {
            //rigidbody moves right
            playerBody.AddForce(new Vector3(movSpeed, 0, 0));
        }

        //rotate right
        if (Input.GetKey(KeyCode.W))
        {
            //if rotational velocity is NOT same direction as the rotation
            if (playerBody.angularVelocity > 0)
            {
                //zero it out first
                playerBody.angularVelocity = 0;
            }
            playerBody.MoveRotation((playerBody.rotation - 10) - 50.0f * Time.deltaTime); //removing Time.deltatime makes it too fast
        }
        //rotate left
        if (Input.GetKey(KeyCode.S))
        {
            //if rotational velocity is NOT same direction as the rotation
            if (playerBody.angularVelocity < 0)
            {
                //zero it out first
                playerBody.angularVelocity = 0;
            }
            playerBody.MoveRotation((playerBody.rotation + 10) + 50.0f * Time.deltaTime); //removing Time.deltatime makes it too fast
        }


        //dev tool: reset position
        if (Input.GetKey(KeyCode.F))
        {
            playerBody.MovePosition(new Vector3(-3, 5, 0));
        }

        //if hit by enemy, be shot in a random direction: 
        
    }
}
