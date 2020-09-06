using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class kimPlayerMovement : MonoBehaviour // inheritance (left is the child, right is the parent)
{
    // Reference of CharacterController2D.cs script
    public CharacterController2D controller;

    float horizontalMove = 0f;

    public float runSpeed = 40f;

    bool jump = false;

    bool crouch = false;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // We use update to get input from the player

        // a value between -1 and 1
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed; // if left -40 : if right 40

        // set animation to running (always positive value for horizontalMove)
        anim.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            anim.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }
    public void OnLandEvent()
    {
        anim.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {
        // and we use fixedupdate to apply the input to the character

        // Move our character
        // * Time.fixedDeltaTime to make it consistent on all platforms
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false; // so that we don't keep jumping forever
    }

}
