using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float rotationSpeed = 20f;
    float updateSpeed = 3f;
    private Quaternion startingRotation;

    public GameObject bikeObject;
    float bikeCameraDistanceX = 0;
    float bikeCameraDistanceZ = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startingRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotationEuler = startingRotation.eulerAngles;

        // turns camera from side to side based on mouse location
        transform.eulerAngles += rotationSpeed * new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime;
        //bikeCameraDistanceX = Mathf.Abs(transform.position.x - bikeObject.transform.position.x);
        //bikeCameraDistanceZ = Mathf.Abs(transform.position.z - bikeObject.transform.position.z);

        //UpdateFollowingDistance();
    }

    void UpdateFollowingDistance()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(bikeCameraDistanceX, 0, bikeCameraDistanceZ) * updateSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(bikeCameraDistanceX, 0, bikeCameraDistanceZ) * updateSpeed * Time.deltaTime;
        }
        
    }
}
