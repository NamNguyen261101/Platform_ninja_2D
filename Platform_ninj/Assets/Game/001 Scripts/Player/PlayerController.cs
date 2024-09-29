using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{
    private Rigidbody2D _rigi;
    
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _moveSpeed = 350, _jumpForce = 250;

    private bool _isOnGrounded = true;
    private bool _isJumping = false;
    private bool _isAttack = false;
    private bool _isDeath = false;

    private float _horizontal;

    private float coin = 0;

    private Vector3 savePoint;
    void Start()
    {
        _rigi = this.GetComponent<Rigidbody2D>();   
        
        SavePoint();
       
    }

    // Update is called once per frame
    void Update()   
    {
        if (_isDeath)
        {
            return;
        }
       _isOnGrounded = CheckGrounded();
        // Debug.Log(_isOnGrounded);
        _horizontal = Input.GetAxisRaw("Horizontal");

        if (_isAttack)
        {
            return;
        }
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
                // Debug.Log("attack");
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

    public override void OnInit ()
    {
        base.OnInit ();
        // reset cac thong so hoac dua ve trang thai dau tien
        _isDeath = false;
        _isAttack = false;

        this.transform.position = savePoint;

        ChangeAnim("idle");
    }

    public override void OnDespawn()
    {
        base.OnDespawn();
    }

    protected override void OnDeath()
    {
        base.OnDeath();
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
        _rigi.velocity = Vector2.zero;
        ChangeAnim("attack");
        _isAttack = true;
        Invoke (nameof(ResetAttack), 0.5f);
    }

    private void ResetAttack()
    {
        ChangeAnim("idle"); // idle 
        _isAttack = false;  
    }

    private void Throw()
    {
        _rigi.velocity = Vector2.zero;
        ChangeAnim("throw");
        _isAttack = true;
        Invoke(nameof(ResetAttack), 0.5f); 
    }

    private void Jump()
    {
        _isJumping = true;
        ChangeAnim("jump");
        _rigi.AddForce(_jumpForce * Vector2.up);
    }

 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            coin++;
            Destroy(collision.gameObject);
        }

        if (collision.tag == "DeathZone")
        {
            _isDeath = true;
            ChangeAnim("die");

            Invoke(nameof(OnInit), 1f); // khoi tao
        }
    }

    internal void SavePoint()
    {
        savePoint = this.transform.position;
    }
}
