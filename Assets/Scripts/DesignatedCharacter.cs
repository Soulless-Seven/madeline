using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//@author Sebastian Bate
/**
 * Switches Character Control and Camera View
 * 
 * Requires a CharacterManager with the Designated Character Script attached 
 * Q and left control must be Character switch and crouch respectively
 * 
 * How to use:
 * Drag Cameras into their respective slots
 * Drag Characters into their respective slots
 * 
 */


public class DesignatedCharacter : MonoBehaviour
{

    public GameObject camera1;
    public GameObject camera2;

    //public GameObject otherCharacter;
    public GameObject character1;
    public GameObject character2;


    /**
     * Character 1 is set as default
     * Therefore Camera1 and Controls are enabled by default only for character 1
     */
    void Start ()
    {
        camera1.SetActive(true);
        camera2.SetActive(false);
        character1.GetComponent<PlayerMovement>().enabled = true;
        character2.GetComponent<PlayerMovement>().enabled = false;
        character1.GetComponent<CrouchScript>().enabled = true;
        character2.GetComponent<CrouchScript>().enabled = false;
    }
    void Update()
    {
        //swap from character 1 to character 2
        if (Input.GetButtonDown("Swap_Character") && character1.GetComponent<PlayerMovement>().enabled == true)
        {
            //disable movement
            character1.GetComponent<PlayerMovement>().enabled = false;
            //GetComponent<PlayerMovement>().enabled = true;
            character2.GetComponent<PlayerMovement>().enabled = true;
            //disable camera
            camera1.SetActive(false);
            camera2.SetActive(true);
            //disable crouch script
            character1.GetComponent<CrouchScript>().enabled = false;
            character2.GetComponent<CrouchScript>().enabled = true;

        }
        else if (Input.GetButtonDown("Swap_Character") && character2.GetComponent<PlayerMovement>().enabled == true)
        {
            character1.GetComponent<PlayerMovement>().enabled = true;
            character2.GetComponent<PlayerMovement>().enabled = false;

            camera1.SetActive(true);
            camera2.SetActive(false);

            character1.GetComponent<CrouchScript>().enabled = true;
            character2.GetComponent<CrouchScript>().enabled = false;
        }
    }
}
