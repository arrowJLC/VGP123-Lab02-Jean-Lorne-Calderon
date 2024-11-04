using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(Animator))]
[RequireComponent(typeof(GroundCheck), typeof(Jump), typeof(Shoot))]

public class NewBehaviourScript : MonoBehaviour
{

    [Range(5, 25)]
    public float speed = 7.0f;
    [Range(3, 25)]
    public float jumpForce = 7.0f;

    public bool isGrounded = false;


    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;
    GroundCheck gc;
    
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        gc = GetComponent<GroundCheck>();
        
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
            anim.SetFloat("playSpeed", Mathf.Abs(hinput));
            anim.SetBool("isGrounded", isGrounded);
        }

        if (Input.GetButtonDown("Fire1") && isGrounded)
        {
            anim.SetTrigger("fire");
        }
        
       if (Input.GetButtonDown("Fire1") && !isGrounded)
        {
            anim.SetTrigger("glideFall");
        }

            void CheckIsGrounded()
        {
            if (!isGrounded)
            {
                if (rb.velocity.y <= 0) isGrounded = gc.IsGrounded();
            }
            else isGrounded = gc.IsGrounded();
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