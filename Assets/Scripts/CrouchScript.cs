using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//@author Sebastian Bate

public class CrouchScript : MonoBehaviour
{
    CapsuleCollider playerCol;
    float originalHeight;
    public float reducedHeight;

    void Start()
    {
        playerCol = GetComponent<CapsuleCollider>();
        originalHeight = playerCol.height;
    }
    void Update()
    {
        //Crouch
        if (Input.GetButton("Crouch"))
            Crouch();
        else if (!Input.GetButton("Crouch"))
            GoUp();
    }

    //Reduce Height

    void Crouch()
    {
        playerCol.height = reducedHeight;
    }

    //Reset Height
    void GoUp()
    {
        playerCol.height = originalHeight;
    }
}
