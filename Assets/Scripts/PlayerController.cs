using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // public float speed = 12.0f;
    [SerializeField] private float horsePower = 100f;
    [SerializeField] private float turnSpeed = 5.0f;
    [SerializeField] private float speed;
    [SerializeField] private float rpm;
    private float horizontalInput;
    private float verticalInput;
    private string horizontalAxis;
    private string verticalAxis;
    private Rigidbody playerRb;
    [SerializeField] private GameObject centerOfMass;
    [SerializeField] private TextMeshProUGUI speedometerText;
    [SerializeField] private TextMeshProUGUI rpmText;
    [SerializeField] private List<WheelCollider> allWheels;
    [SerializeField] private int wheelsOnGround;
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
        if (IsOnGround())
        {
            Move();
        }
        CalcSpeedAndRPM();
    }

    private void CalcSpeedAndRPM()
    {
        speed = Mathf.Round(playerRb.velocity.magnitude * 3.6f);
        rpm = Mathf.Round((speed % 30) * 40);
        speedometerText.SetText("Speed : " + speed + " km/h");
        rpmText.SetText("RPM : " + rpm);
    }

    private void SetAxes()
    {
        if (gameObject.CompareTag("Player_1"))
        {
            horizontalAxis = "Horizontal";
            verticalAxis = "Vertical";
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

    private bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if (wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
