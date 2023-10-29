using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    private bool boost;
    private Material material;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();  
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (horizontalMove != 0f) {
            animator.SetBool("isWalking", true);
        }
        else { animator.SetBool("isWalking", false);

        }

        if (Input.GetButtonDown("Jump")) {
            animator.SetBool("isJumping", true);
            jump = true;
        }

        else { animator.SetBool("isJumping", false); }
        if (Input.GetKeyDown(KeyCode.Space)) {
            boost = true;
            //animator.SetBool("isJumping", true);
        }
    }
    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump, boost);
        jump = false;
        boost = false;
        
    }
}
