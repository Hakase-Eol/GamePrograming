using UnityEngine;
using UnityEngine.Timeline;

public class Test : MonoBehaviour
{
    float jumpForce = 5.0f;
    float gravity = 9.8f;
    float groundY = 0.0f;
    bool isJumping = false;
    float verticalVelocity = 0.0f;
    bool groundYSet = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Position: " + transform.position);
        Debug.Log("Rotation (Quaternion): " + transform.rotation);
        Debug.Log("Euler Angles: " + transform.eulerAngles);
        Debug.Log("Forward: " + transform.forward);
        Debug.Log("Up: " + transform.up);
        Debug.Log("Right: " + transform.right);
    }

    // Update is called once per frame
    void Update()
    {
        
        float moveSpeed = 5f;
        float rotateSpeed = 100f;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.World);
            if (transform.position.x > 2)
            {
                transform.position = new Vector3(2, transform.position.y, transform.position.z);
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime, Space.World);
            if (transform.position.x < -2)
            {
                transform.position = new Vector3(-2, transform.position.y, transform.position.z);
            }
        }
        if (Input.GetKey(KeyCode.R))
        {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);
        }

        if(!groundYSet)
        {
            groundY = transform.position.y;
            groundYSet = true;
        }

        if(Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            verticalVelocity = jumpForce;
        }

        if(isJumping)
        {
            verticalVelocity -= gravity * Time.deltaTime;
            Vector3 pos = transform.position;
            pos.y += verticalVelocity * Time.deltaTime;

            if (pos.y <= groundY)
            {
                pos.y = groundY;
                isJumping = false;
                verticalVelocity = 0f;
            }
            transform.position = pos;
        }
    }
}
