using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerMovement : MonoBehaviour {
    //other scripts
    public CharacterController2D controller;
    public Uncanny uncanny;

    //vars
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    public bool boost;
    private Material material;
    private Animator animator;
    bool weedBtn;
    bool isColliding;
    Vector3 checkpoint;

    //audio
    public AudioSource source;
    public AudioClip dead;
    public AudioClip eat;
    public AudioClip walk;
    public AudioClip a_jump;
    public AudioClip turbo;

    void Start() {
        checkpoint = transform.position;
        animator = GetComponent<Animator>();  
        source = GetComponent<AudioSource>();
    }

    //CAPYBARA COLLIDES WITH SHIT
    private void OnTriggerEnter2D(Collider2D other){
        //DED
        if (other.CompareTag("Spikes")){
            uncanny.AddUncanny();
            controller.UpdateBoost();
            source.PlayOneShot(dead);
            transform.position = checkpoint;
            
        }
        //teleport to checkpoint
        if (other.CompareTag("Checkpoint")) {
            checkpoint = other.transform.position;
            Destroy(other.gameObject);
        }
    }

    //weed fuel
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Weed") && weedBtn)
        {
            controller.fuel_number += 10;
            controller.UpdateBoost();
            Destroy(other.gameObject);

            source.PlayOneShot(eat);
        }
    }

    //CAPYBARA MOVEMENT
    void Update() {
        weedBtn = Input.GetKey(KeyCode.E);
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (horizontalMove != 0f) {
            //source.PlayOneShot(walk);
            animator.SetBool("isWalking", true);
        }
        else { animator.SetBool("isWalking", false);

        }

        if (Input.GetButtonDown("Jump")) {
            source.PlayOneShot(a_jump);
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
