using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 13f;
    public float sprintSpeed = 16f;
    bool moving = false;
    public GameObject camera;

 
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        move();
        rotate();

        

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Cursor.lockState== CursorLockMode.Locked)
            {
                CursorLock(false);
            }
            else
            {
                CursorLock(true);
            }
        }
    }

    void rotate()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {

            float mouseX = Input.GetAxis("Mouse X");
            transform.Rotate(0, mouseX, 0);
            float mouseY = -Input.GetAxis("Mouse Y");
            camera.transform.Rotate(mouseY, 0, 0);
        }
    }

    void move()
    {

        float speed = moveSpeed;

        if (moving)
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                speed = sprintSpeed;
            }
            else
            {
                speed = moveSpeed;
            }
        }

        if(Input.GetKey(KeyCode.A))
        {

            transform.Translate(Vector3.left * speed * Time.deltaTime);
            moving = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(-Vector3.left * speed * Time.deltaTime);
            moving = true;
        }
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            moving = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * speed * Time.deltaTime);
            moving = true;
        }
        
        if(!getKey(KeyCode.A) && !getKey(KeyCode.D) && !getKey(KeyCode.W) && !getKey(KeyCode.S))
        {
            moving = false;
        }
    }

    bool getKey(KeyCode keyCode)
    {
        return Input.GetKey(keyCode);
    }
    void CursorLock(bool locked)
    {
        if(locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
