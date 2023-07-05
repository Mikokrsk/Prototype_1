using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // public float speed = 12.0f;
   [SerializeField] private float horsePower = 100f;
   [SerializeField] private float turnSpeed = 5.0f;
    private float horizontalInput;
    private float verticalInput;
    private string horizontalAxis;
    private string verticalAxis;
    private Rigidbody playerRb;
    [SerializeField] private GameObject centerOfMass;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
        SetAxes();
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void SetAxes()
    {
        if (gameObject.CompareTag("Player_1"))
        {
            horizontalAxis = "Horizontal1";
            verticalAxis = "Vertical1";
        }
        else
        {
            horizontalAxis = "Horizontal2";
            verticalAxis = "Vertical2";
        }
    }

    private void Move()
    {
        horizontalInput = Input.GetAxis(horizontalAxis);
        verticalInput = Input.GetAxis(verticalAxis);
        // transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        playerRb.AddRelativeForce(Vector3.forward * verticalInput * horsePower);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}
