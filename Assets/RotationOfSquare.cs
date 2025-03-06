using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationOfSquare : MonoBehaviour
{

    public GameObject ball;
    private SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0f, 0f, -60f), Space.World);
        }
            
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0f, 0f, 60f), Space.World);
        }
        
    }

   /* void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            if (ball.GetComponent<SpriteRenderer>().color == GetComponent<SpriteRenderer>().color)
            {
                Debug.Log("Eşşiiiitt");
            }else Debug.Log("değil");
        }
    }*/

  /*  void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            if (ball.GetComponent<SpriteRenderer>().color == GetComponent<SpriteRenderer>().color)
            {
                Debug.Log("Eşşiiiitt");
            }else Debug.Log("değil");
        }
    }*/
    
    
}
