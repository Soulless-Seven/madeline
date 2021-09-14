using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Camera _camera;
    private Vector2 _currRotation;

    public float ForwardVelocity = 3f;
    public float BackwardVelocity = 1f;
    public float LateralVelocity = 2f;
    public float VerticalSensitivity = 10f;
    public float HorizontalSensitivity = 10f;
    public float MaximumYAngle = 80f;

    public float horiz;
    public float vert;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        _camera = gameObject.GetComponentInChildren<Camera>();
        _currRotation = new Vector2(0f, 0f);
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        _currRotation.x += Input.GetAxis("Mouse X") * HorizontalSensitivity;
        _currRotation.y -= Input.GetAxis("Mouse Y") * VerticalSensitivity;
        _currRotation.x = Mathf.Repeat(_currRotation.x, 360);
        _currRotation.y = Mathf.Clamp(_currRotation.y, -MaximumYAngle, MaximumYAngle);
        transform.rotation = Quaternion.Euler(0, _currRotation.x, 0);
        _camera.transform.localRotation = Quaternion.Euler(_currRotation.y, 0, 0);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float transZ = Input.GetAxis("Vertical");
        float transX = Input.GetAxis("Horizontal");

        float vZ = transZ > 0 ? transZ * ForwardVelocity : transZ * BackwardVelocity;
        _rigidbody.velocity = Quaternion.Euler(0, _currRotation.x, 0) * 
            new Vector3(transX * LateralVelocity, _rigidbody.velocity.y, vZ);
    }
}
