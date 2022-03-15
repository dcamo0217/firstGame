using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    bool canJump=true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left"))
        {
           gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1000f * Time.deltaTime,0));
        }
        if(Input.GetKey("right"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1000f * Time.deltaTime,0));
        }
        if(Input.GetKeyDown("up") && canJump){
            canJump=false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,200f));
        }
    }
    private void OnCollinionEnter2D(Collision2D collision){
        if(collision.transform.tag ==  "ground"){
            canJump=true;
        }
    }
}
