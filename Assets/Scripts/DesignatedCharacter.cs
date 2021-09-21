using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//@author Sebastian Bate
//First time Q is pressed, choose the first character
//afterwards it swaps character control
//
//How to use:
//Drag onto 1st character, and drag onto 2nd character
//fill in the "Other Character" field by dragging the other character into it


public class DesignatedCharacter : MonoBehaviour
{
    //public GameObject camera1;
    //public GameObject camera2;

    public GameObject otherCharacter;
    void Start ()
        {
            //camera1.setActive(true);
            //camera2.setActive(false);
        }
    void Update()
    {
        if (Input.GetButtonDown("Swap_Character"))
        {
            //disable 2nd character, control 1st character
            //inverse each time Q is pressed
            otherCharacter.GetComponent<PlayerMovement>().enabled = false;
            GetComponent<PlayerMovement>().enabled = true;
            //switch camera
           // if (camera1.setActive(true))
           // {
               // camera1.setActive(true);
             //   camera2.setActive(false);
            //}
           // else
            //{
            //    camera1.setActive(true);
            //    camera2.setActive(false);
           // }
            //same for crouch script
            //idk if it's needed, stfu
            otherCharacter.GetComponent<CrouchScript>().enabled = false;
            GetComponent<CrouchScript>().enabled = true;
        }
    }
}
