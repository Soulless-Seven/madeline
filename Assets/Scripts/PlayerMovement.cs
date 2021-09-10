using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;

    public float ForwardVelocity;
    public float BackwardVelocity;
    public float LateralVelocity;
    public float VerticalSensitivity;
    public float HorizontalSensitivity;

    public float horiz;
    public float vert;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float transZ = Input.GetAxis("Vertical");
        vert = transZ; // TODO: removeme
        float transX = Input.GetAxis("Horizontal");
        horiz = transX; // TODO: removeme
        float rotX = Input.GetAxis("Mouse Y");
        float rotY = Input.GetAxis("Mouse X");

        float vZ = transZ > 0 ? transZ * ForwardVelocity : transZ * BackwardVelocity;
        _rigidbody.velocity = new Vector3(transX * LateralVelocity, 0, vZ);
    }
}
