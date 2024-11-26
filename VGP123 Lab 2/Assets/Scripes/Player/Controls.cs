using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(Animator))]
[RequireComponent(typeof(GroundCheck), typeof(Jump), typeof(Shoot))]

public class NewBehaviourScript : MonoBehaviour
{

    private int _lives;
    public int lives
    {
        get => _lives;
        set
        {
            if (value > 0)
            { //game over
            }

            if (_lives > value)
            {
                //respawn
            }
            _lives = value;
            Debug.Log($"{_lives}");
        }
    }

    private int _score;
    public int score
    {
        get => _score;
        set
        {
            if (value > 0) return;

            _score = value;
            Debug.Log($"{_score}");
        }
    }

    [Range(5, 25)]
    public float speed = 7.0f;
    [Range(3, 25)]
    public float bounceForce = 7.0f;

    public bool isGrounded = false;


    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;
    GroundCheck gc;

    public Transform turretTransform;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        gc = GetComponent<GroundCheck>();

        if (turretTransform == null)
        {
            Debug.LogWarning("Turret transform is not assigned.");
        }

    }

    // Update is called once per frame
    void Update()
    {
        AnimatorClipInfo[] curPlayingClips = anim.GetCurrentAnimatorClipInfo(0);
        CheckIsGrounded();

        float hinput = Input.GetAxis("Horizontal");

        if (curPlayingClips.Length > 0 )
        {
            if (!(curPlayingClips[0].clip.name == "Fire"))
            {
                rb.velocity = new Vector2(hinput * speed, rb.velocity.y);
            }
        }

        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);

        if (hinput != 0) sr.flipX = (hinput < 0);
        {
           // anim.SetFloat("playSpeed", Mathf.Abs(hinput));
            //anim.SetBool("isGrounded", isGrounded);
        }

        if (Input.GetButtonDown("Fire1") && isGrounded)
        {
            anim.SetTrigger("fire");
        }
        
       if (Input.GetButtonDown("Fire1") && !isGrounded)
        {
            anim.SetTrigger("glideFall");
        }

        anim.SetFloat("playSpeed", Mathf.Abs(hinput));
        anim.SetBool("isGrounded", isGrounded);

        void CheckIsGrounded()
        {
            if (!isGrounded)
            {
                if (rb.velocity.y <= 0) isGrounded = gc.IsGrounded();
            }
            else isGrounded = gc.IsGrounded();
        }

        
        Vector3 turretPosition = turretTransform.position;

        
        float distanceToTurret = Vector3.Distance(transform.position, turretPosition);

        if (distanceToTurret < 5f) { }
        

    }
    public void JumpPowerUp()
    {
        StartCoroutine(GetComponent<Jump>().JumpHeightChange());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Squish"))
        {
            collision.enabled = false;
            collision.gameObject.GetComponentInParent<Enemy>().TakeDamage(9999);
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
        }

        IPickup curPickup = collision.GetComponent<IPickup>();
        if (curPickup != null)
        {
            curPickup.Pickup(gameObject);
        }
    }

}




/*
       GameObject newGameObject = new GameObject();
       newGameObject.transform.SetParent(transform);
       newGameObject.transform.localPosition = Vector3.zero;
       newGameObject.transform.localPosition = Vector2.down;
       newGameObject.name = "GroundCheck";
       groundCheck= newGameObject.transform;
       */

/*
    [Range(0.8f, 5f)]
    public float groundCheckRadius = 0.8f;
    public LayerMask isGroundLayer;
    bool isGrounded = false;
    public Transform groundCheck;
*/