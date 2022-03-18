using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SierraDeAtaque : MonoBehaviour
{
    // Start is called before the first frame update
    private float posisionx;
    private float posisiony;

    public float velocidad;

        private Rigidbody2D _rigidbody2D;
    void Start()
    {
        posisionx = gameObject.GetComponent<Transform>().position.x;
        posisiony = gameObject.GetComponent<Transform>().position.y;
    }

    private async void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Wall"){

            gameObject.GetComponent<Transform>().position= new Vector3(posisionx,posisiony,0);
        }

    }

    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(velocidad * Time.deltaTime,0));
    }
}

