using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public Collider2D hookBody;
    private HingeJoint2D hinge; 
    private Color held = Color.blue;
    private Color touchPeg = Color.yellow;

    public int score = 0;

    public void Start()
    {
        //instantiate the hook's collider
        hookBody = GetComponent<Collider2D>();
        hinge = GetComponent<HingeJoint2D>();
    }

    void Update()
    {
        //while holding Spacebar
        if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<Renderer>().material.color = held;            
                //while the hook is touching the peg
                if (hookBody.IsTouchingLayers(1 << 3))
                {
                    GetComponent<Renderer>().material.color = touchPeg;
                    //make position = peg position [use PegPositions dictionary]
                    //this.transform.position = pegDict[currentPeg]; <-- keeping this line will reposition the hook without the body, changing the distance between them 

                    //turn on HingeJoint2D
                    hinge.enabled = true;
                }
        }
        else
        {
            GetComponent<Renderer>().material.color = held;
            //if HingeJoint2D is still on 
            if(hinge.enabled == true)
            {
                //turn it off
                hinge.enabled = false;
            }

        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Peg")
        {
            print("YES");
            //wait until hinge.enabled == True
            if (hinge.enabled)
            {
                print("WAS HELD");
                collision.transform.position = new Vector3(-15, -8, 0);
                score += 1;
            }    
        }
    }*/
}