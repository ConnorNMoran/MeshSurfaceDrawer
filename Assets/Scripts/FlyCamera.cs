using UnityEngine;

//Some basic free cam script I made to look around the scene
[RequireComponent(typeof(Camera))]
public class FlyCamera : MonoBehaviour
{
    public float speed       = 10.0f;
    public float sensitivity = 30.0f;

    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0.0f, 0.0f));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0.0f, 0.0f));
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0.0f, 0.0f, speed * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0.0f, 0.0f, -speed * Time.deltaTime));
        }

        if (Input.GetMouseButton(1))
        {
            transform.rotation *= Quaternion.AngleAxis(-Input.GetAxis("Mouse Y") * sensitivity, Vector3.right);
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + Input.GetAxis("Mouse X") * sensitivity, transform.eulerAngles.z);
        }
    }
}