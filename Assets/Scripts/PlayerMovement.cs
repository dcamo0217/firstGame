using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{   
    public float vista;
    public float Speed = 15f;
    public float JumpForce = 10f;
    public Animator PlayerAnimator;
    private Rigidbody2D _rigidbody2D;
    private float _horizontal = 0f;
    public bool _isJumping = false;
    private bool _onTheGrass = false;



    public bool DobleSalto=false;
    
    private SpriteRenderer _renderer;

  

    private async void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Grass" )
        {
            _onTheGrass = true;
            Debug.Log("onGrass");
        }
        if(collision.gameObject.tag == "Enemy"){
            //Destroy(gameObject);
            //LevelManager.instance.Respawn();
            gameObject.GetComponent<Transform>().position= new Vector3(-30,1.5f,0);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Grass")
        {
            _onTheGrass = false;
            Debug.Log("offGrass");
            
        }


    }

    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        if (_renderer == null)
        {
            Debug.LogError("Player Sprite is missing a renderer");
        }
        _rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {       
        _horizontal = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump") && _isJumping==false && _onTheGrass==false && DobleSalto==true){
                DobleSalto=false;
                PlayerAnimator.SetBool("Jump", true);
            _rigidbody2D.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);

        }

        
        if (Input.GetButton("Jump")  )
        {
            _isJumping = _onTheGrass;

        }

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            _renderer.flipX = false;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            _renderer.flipX = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("coin")) 
        {
            Destroy(other.gameObject);
        }else
         if (other.gameObject.CompareTag("Finish")) 
        {
            Destroy(other.gameObject);
        }
    }
    

    private void FixedUpdate()
    {
        PlayerAnimator.SetFloat("Speed", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        transform.position += new Vector3(_horizontal, 0, 0) * Time.fixedDeltaTime * Speed;
        vista=_horizontal;
        if (_isJumping)
        {   
            DobleSalto=true;
            _isJumping = false;
            PlayerAnimator.SetBool("Jump", true);
            _rigidbody2D.AddForce(new Vector2(0, JumpForce+1), ForceMode2D.Impulse);

        }
        else
        {
            PlayerAnimator.SetBool("Jump", false);  
        }

    }
}
