using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {
    //other scripts
    public CharacterController2D controller;
    public Uncanny uncanny;
    public LevelManager levelManager;


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
    public AudioSource dead;
    public AudioSource eat;
    public AudioSource walk;
    public AudioSource a_jump;
    public AudioSource turbo;

    void Start() {
        checkpoint = transform.position;
        animator = GetComponent<Animator>();  

    }


    //CAPYBARA COLLIDES WITH SHIT
    private void OnTriggerEnter2D(Collider2D other){
        //DED
        if (other.CompareTag("Spikes")){
            uncanny.AddUncanny();
            controller.UpdateBoost();
            dead.Play();
            CinemachineShake.Instance.ShakeCamera(4f,.2f);
            transform.position = checkpoint;
            
        }
        //teleport to checkpoint
        if (other.CompareTag("Checkpoint")) {
            checkpoint = other.transform.position;
            Destroy(other.gameObject);
        }
        
            //
            if (other.CompareTag("Finish"))
            {
                SceneManager.LoadScene(levelManager.sceneName);

            }
        
    }

    //weed fuel
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Weed") && weedBtn)
        {
            eat.Play();
            controller.fuel_number += 10;
            controller.UpdateBoost();
            Destroy(other.gameObject);

        }
    }

    //CAPYBARA MOVEMENT
    void Update() {
        weedBtn = Input.GetKey(KeyCode.E);
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (horizontalMove != 0f) {
            
            animator.SetBool("isWalking", true);
        }
        else { animator.SetBool("isWalking", false);

        }

        if (Input.GetButtonDown("Jump")) {
            a_jump.Play();
            //animator.SetBool("isJumping", true);
            jump = true;
        }

        else {/* animator.SetBool("isJumping", false);*/ }
        if (Input.GetKeyDown(KeyCode.Space)) {
            boost = true;
            //animator.SetBool("isJumping", true);
        }
        // play walking audio handicapetion
        if (horizontalMove != 0f) {
            if (!walk.isPlaying) { walk.Play(); }
        } else { walk.Stop(); }
    }
    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump, boost);
        jump = false;
        boost = false;
        
    }
}
