using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    

    [SerializeField] private Transform groundCheck;
    [SerializeField] [Range(0.01f, 5f)] private float groundCheckRadius = 0.8f;
    [SerializeField] private LayerMask groundCheckLayerMask;

    // Start is called before the first frame update
    void Start()
    {
        // creating gound check opject - this assumes pivot at bttom center
        if (!groundCheck )
        {
            Debug.Log("Ground Check not working");
            GameObject newGameObject = new GameObject();
            newGameObject.transform.SetParent(transform);
            newGameObject.transform.localPosition = Vector3.zero;
            newGameObject.transform.localPosition = Vector2.down;
            newGameObject.name = "GroundCheck";
            groundCheck = newGameObject.transform;
        }
    }
    public bool IsGrounded()
    { 
        if (!groundCheck) return false;
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundCheckLayerMask);
    }
}
