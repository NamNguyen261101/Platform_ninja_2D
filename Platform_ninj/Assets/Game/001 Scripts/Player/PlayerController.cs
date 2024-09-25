using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigi;
    [SerializeField] private Animator _anim;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _moveSpeed = 350, _jumpForce = 250;

    private bool _isOnGrounded = true;
    private bool _isJumping = false;
    private bool _isAttack;

    private float _horizontal;

    private string _currentAnim;
    void Start()
    {
        _rigi = this.GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
       _isOnGrounded = CheckGrounded();

        _horizontal = Input.GetAxisRaw("Horizontal");
        if (_isOnGrounded)
        {
            // check jump cancle attack - throw
            if (_isJumping)
            {
                return;
            }

            // jump
            if (Input.GetKeyDown(KeyCode.Space) && _isOnGrounded)
            {
                Jump();
            }

             // Change anim run
            if (Mathf.Abs(_horizontal) > 0.1f)
            {
                ChangeAnim("run");
            }

            // Attack
            if (Input.GetKeyDown(KeyCode.E) && _isOnGrounded)
            {
                Attack();
            }

            // Throw
            if (Input.GetKeyDown(KeyCode.Q) && _isOnGrounded)
            {
                Throw();
            }
        }

        // Check falling
        if (!_isOnGrounded && _rigi.velocity.y < 0)
        {
            ChangeAnim("fall");
            _isJumping = false;
        }
         
        // Moving
        if (Mathf.Abs(_horizontal) > 0.1f)
       {
            _rigi.velocity = new Vector2(_horizontal * _moveSpeed * Time.deltaTime, _rigi.velocity.y);
            // - left -right
            // horizontal - 0 => tra ve 0, neu horizontal <= 0 -> tra ve la 180
            this.transform.rotation = Quaternion.Euler(new Vector3(0,_horizontal > 0 ? 0 : 180,0));
       } else if (_isOnGrounded) 
       {
            ChangeAnim("idle");
            _rigi.velocity = Vector2.zero;
       }
    }

    private bool CheckGrounded()
    {
        Debug.DrawLine(this.transform.position, this.transform.position +  Vector3.down * 1.2f, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.down, 1.2f, _groundLayer);

        if (hit.collider != null)
        {
            return true;
        } else
        {
            return false;
        }

    }

    private void Attack()
    {
        ChangeAnim("attack");
    }

    private void ResetAttack()
    {

    }
    private void Throw()
    {
        ChangeAnim("throw"); 
    }

    private void Jump()
    {
        _isJumping = true;
        ChangeAnim("jump");
        _rigi.AddForce(_jumpForce * Vector2.up);
    }

    private void ChangeAnim(string animName)
    {
        if (_currentAnim != animName)
        {
            _anim.ResetTrigger(animName);

            _currentAnim = animName;

            _anim.SetTrigger(_currentAnim);
        }
    }
}
