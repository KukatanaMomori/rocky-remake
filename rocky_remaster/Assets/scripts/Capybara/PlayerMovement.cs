using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    //other scripts
    public CharacterController2D controller;
    public Checkpoint checkpoint;
    public Uncanny uncanny;

    //vars
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    public bool boost;
    private Material material;
    private Animator animator;

    void Start() {
        animator = GetComponent<Animator>();  
    }

    //CAPYBARA DEAD
    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Spikes")){
            uncanny.AddUncanny();
            controller.UpdateBoost();
            checkpoint.GoToCheckpoint();
        }
    }

    //CAPYBARA MOVEMENT
    void Update() {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (horizontalMove != 0f) {
            animator.SetBool("isWalking", true);
        }
        else { animator.SetBool("isWalking", false);

        }

        if (Input.GetButtonDown("Jump")) {
            //animator.SetBool("isJumping", true);
            jump = true;
        }

        else {/* animator.SetBool("isJumping", false);*/ }
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
