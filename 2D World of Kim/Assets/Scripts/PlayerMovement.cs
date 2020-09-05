using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Reference of CharacterController2D.cs script
    public CharacterController2D controller;

    float horizontalMove = 0f;

    public float runSpeed = 40f;

    bool jump = false;

    bool crouch = false;

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

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
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
