using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 5f;
    public float JumpForce = 2f;
    public Animator PlayerAnimator;
    private Rigidbody2D _rigidbody2D;
    private float _horizontal = 0f;
    private bool _isJumping = false;
    private bool _onTheGrass = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Grass")
        {
            _onTheGrass = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Grass")
        {
            _onTheGrass = false;
        }
    }

    void Start()
    {
        _rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");

        if (Input.GetButton("Jump") && _onTheGrass == true )
        {
            _isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        PlayerAnimator.SetFloat("Speed", _horizontal > 0 ? _horizontal : 0, 0, 0);
        transform.position += new Vector3(_horizontal > 0 ? _horizontal: 0, 0, 0) * Time.fixedDeltaTime * Speed;

        if (_isJumping)
        {
            _isJumping = false;
            PlayerAnimator.SetBool("Jump", true);
            _rigidbody2D.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
        else
        {
            PlayerAnimator.SetBool("Jump", false);  
        }
    }
}
