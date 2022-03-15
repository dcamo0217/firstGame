using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sierra : MonoBehaviour
{
    // Start is called before the first frame update


    public float Ow;
    public bool vuelta; 

    private float posision;
    void Start()
    {
        vuelta=true;
        posision=gameObject.GetComponent<Transform>().position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Ow=gameObject.GetComponent<Transform>().position.x;
      if ( vuelta == true)
        {
            if(gameObject.GetComponent<Transform>().position.x < posision-2f){
                vuelta=false;
                //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(15f * Time.deltaTime,0));
            }
           gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-8f * Time.deltaTime,0));
        }else if(vuelta == false){
            if(gameObject.GetComponent<Transform>().position.x > posision+2f ){
                vuelta=true;
               //    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-15f * Time.deltaTime,0));
            }
           gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(8f * Time.deltaTime,0));

        }
 
    }
}
