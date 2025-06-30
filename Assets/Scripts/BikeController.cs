using System;
using UnityEngine;

public class BikeController : MonoBehaviour
{
    public Rigidbody bikeRigidbody;

    // movement variables
    public float bikeSpeed = 20f;
    public float bikeRotationSpeed = 20f;

    // falling over variables
    public float bikeTiltSpeed = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bikeRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
        //TiltOverTime();
    }

    void UpdatePosition()
    {
        Vector3 currentPosition = transform.position;

        if (Input.GetKey(KeyCode.W))
        {
            // move the rigidbody forward constantly at the bike speed in the direction of the blue arrow
            bikeRigidbody.MovePosition(currentPosition + transform.forward * bikeSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            // move the rigidbody backwards constantly at the bike speed in the direction of the blue arrow
            bikeRigidbody.MovePosition(currentPosition + -transform.forward * bikeSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            // rotate the bike on the Y axis in the positive direction
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * bikeRotationSpeed, Space.World);
        }

        if (Input.GetKey(KeyCode.A))
        {
            // rotate the bike on the Y axis in the negative direction
            transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * bikeRotationSpeed, Space.World);
        }
    }

    void TiltOverTime()
    {
        Quaternion currentRotation = transform.rotation;

        transform.Rotate(currentRotation.eulerAngles + new Vector3(0, 0, 1) * Time.deltaTime * bikeTiltSpeed, Space.World);
    }
}
