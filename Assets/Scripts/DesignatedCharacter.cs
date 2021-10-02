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

    private Camera madelineCamera;
    private Camera carolineCamera;

    private AudioListener madelineEars;
    private AudioListener carolineEars;

    private List<Behaviour> madelineBehaviours;
    private List<Behaviour> carolineBehaviours;

    public GameObject soundManager;
    private SoundBoard _soundBoard;

    /**
     * Madeline GO is set as default
     * Therefore Camera and Controls are enabled by default only for character 1
     */
    void Start ()
    {
        madelineBehaviours = new List<Behaviour>();
        madelineBehaviours.Add(madelineGO.GetComponentInChildren<Camera>());
        madelineBehaviours.Add(madelineGO.GetComponentInChildren<AudioListener>());
        madelineBehaviours.Add(madelineGO.GetComponentInChildren<PlayerMovement>());
        madelineBehaviours.Add(madelineGO.GetComponentInChildren<CrouchScript>());

        carolineBehaviours = new List<Behaviour>();
        carolineBehaviours.Add(carolineGO.GetComponentInChildren<Camera>());
        carolineBehaviours.Add(carolineGO.GetComponentInChildren<AudioListener>());
        carolineBehaviours.Add(carolineGO.GetComponentInChildren<PlayerMovement>());
        carolineBehaviours.Add(carolineGO.GetComponentInChildren<CrouchScript>());
        carolineBehaviours.Add(carolineGO.GetComponentInChildren<FollowPath>());

        foreach (Behaviour mb in madelineBehaviours)
            mb.enabled = true;

        foreach (Behaviour cb in carolineBehaviours)
            cb.enabled = false;

        carolineGO.GetComponentInChildren<FollowPath>().enabled = true;

        _soundBoard = soundManager.GetComponent<SoundBoard>();
        _soundBoard.InEarSource = madelineGO.GetComponentInChildren<AudioSource>();
    }
    void Update()
    {
        //swap from character 1 to character 2
        if (Input.GetButtonDown("Swap_Character") && madelineGO.GetComponent<PlayerMovement>().enabled == true)
        {
            SwapBehaviors();

            //change headphone to play through
            _soundBoard.InEarSource = carolineGO.GetComponentInChildren<AudioSource>();
        }
        else if (Input.GetButtonDown("Swap_Character") && carolineGO.GetComponent<PlayerMovement>().enabled == true)
        {
            SwapBehaviors();

            _soundBoard.InEarSource = madelineGO.GetComponentInChildren<AudioSource>();
        }
    }

    private void SwapBehaviors()
    {
        foreach (Behaviour mb in madelineBehaviours)
            mb.enabled = !mb.enabled;

        foreach (Behaviour cb in carolineBehaviours)
            cb.enabled = !cb.enabled;
    }
}
