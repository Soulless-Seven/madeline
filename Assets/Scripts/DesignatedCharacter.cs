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
    //public GameObject otherCharacter;
    public GameObject madelineGO;
    public GameObject carolineGO;

    private GameObject madelineCamera;
    private GameObject carolineCamera;

    public GameObject soundManager;
    private SoundBoard _soundBoard;

    /**
     * Character 1 is set as default
     * Therefore Camera1 and Controls are enabled by default only for character 1
     */
    void Start ()
    {
        madelineCamera = madelineGO.transform.Find("Madeline Camera").gameObject;
        carolineCamera = carolineGO.transform.Find("Caroline Camera").gameObject;
        madelineCamera.SetActive(true);
        carolineCamera.SetActive(false);
        madelineGO.GetComponent<PlayerMovement>().enabled = true;
        carolineGO.GetComponent<PlayerMovement>().enabled = false;
        madelineGO.GetComponent<CrouchScript>().enabled = true;
        carolineGO.GetComponent<CrouchScript>().enabled = false;

        _soundBoard = soundManager.GetComponent<SoundBoard>();
        _soundBoard.InEarSource = madelineGO.GetComponentInChildren<AudioSource>();
    }
    void Update()
    {
        //swap from character 1 to character 2
        if (Input.GetButtonDown("Swap_Character") && madelineGO.GetComponent<PlayerMovement>().enabled == true)
        {
            //disable movement
            madelineGO.GetComponent<PlayerMovement>().enabled = false;
            //GetComponent<PlayerMovement>().enabled = true;
            carolineGO.GetComponent<PlayerMovement>().enabled = true;
            //disable camera
            madelineCamera.SetActive(false);
            carolineCamera.SetActive(true);
            //disable crouch script
            madelineGO.GetComponent<CrouchScript>().enabled = false;
            carolineGO.GetComponent<CrouchScript>().enabled = true;
            //change headphone to play through
            _soundBoard.InEarSource = carolineGO.GetComponentInChildren<AudioSource>();
            // Deactivate follow script when going to caroline
            carolineGO.GetComponent<FollowPath>().enabled = false;
        }
        else if (Input.GetButtonDown("Swap_Character") && carolineGO.GetComponent<PlayerMovement>().enabled == true)
        {
            madelineGO.GetComponent<PlayerMovement>().enabled = true;
            carolineGO.GetComponent<PlayerMovement>().enabled = false;

            madelineCamera.SetActive(true);
            carolineCamera.SetActive(false);

            madelineGO.GetComponent<CrouchScript>().enabled = true;
            carolineGO.GetComponent<CrouchScript>().enabled = false;

            _soundBoard.InEarSource = madelineGO.GetComponentInChildren<AudioSource>();

            // Activate follow script when going to madeline
            carolineGO.GetComponent<FollowPath>().enabled = true;
        }
    }
}
