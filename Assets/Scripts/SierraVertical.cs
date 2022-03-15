using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SierraVertical : MonoBehaviour
{
    // Start is called before the first frame update


    public float Ow;
    public bool vuelta; 

    private float posision;
    void Start()
    {
        vuelta=true;
        posision=gameObject.GetComponent<Transform>().position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Ow=gameObject.GetComponent<Transform>().position.y;
      if ( vuelta == true)
        {
            if(gameObject.GetComponent<Transform>().position.y < posision-4f){
                vuelta=false;
                //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(15f * Time.deltaTime,0));
            }
           gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,-8f * Time.deltaTime));
        }else if(vuelta == false){
            if(gameObject.GetComponent<Transform>().position.y > posision+4f ){
                vuelta=true;
               //    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-15f * Time.deltaTime,0));
            }
           gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,8f * Time.deltaTime));

        }
 
    }
}