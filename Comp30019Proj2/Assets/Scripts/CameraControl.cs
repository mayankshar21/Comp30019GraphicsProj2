using UnityEngine;
using System.Collections;
/// <summary>
/// Camera control and collision detection
/// </summary>
// Created by Judd Guerrero

// Concepts of yaw and pitch taken from
//https://gamedev.stackexchange.com/questions/104693/how-to-use-input-getaxismouse-x-y-to-rotate-the-camera

public class CameraControl : MonoBehaviour
{
    // Speed of the camera movement
    public float speed = 5.0f;
    public float cameraSpeed = 100.0f;
    // Terrain size
    private float xMax;
    private float zMax;
    private float yMax;
    public float minAngle = -10.0f;
    public float maxAngle = 10.0f;


    void Start()
    {
        // Initialize position of camera based on terrain size
        this.transform.position = new Vector3(28.06f, 0.69f, 2.12f);
       /*xMax = 0;
        zMax = 0;
        yMax = 0;

        Vector3 initialPosition = new Vector3(-xMax, yMax*2, -zMax);*/

        //this.transform.position = initialPosition;
        this.transform.eulerAngles += new Vector3(30.0f, 45.0f, 0.0f);

    }


    void FixedUpdate(){

        float yaw = 0.0f;
        float pitch = 0.0f;
        float amountToMove = Time.deltaTime * speed;
        Vector3 temporary;
        Vector3 futurePosition ;
        Vector3 futureAngle;
            
            // Calculate future position and checks whether it goes beyond the terrain size
            // then proceeds if it's within the bounds
            if (Input.GetKey(KeyCode.W))
            {       
                    
                    temporary = this.transform.forward * amountToMove;
                    temporary.y = 0;
                    this.transform.position += temporary;
            }
            if (Input.GetKey(KeyCode.S))
            {
                    temporary = this.transform.forward * amountToMove;
                    temporary.y = 0;
                    this.transform.position -= temporary;
              
            }
            if (Input.GetKey(KeyCode.A))
            {       
                    temporary = this.transform.right * amountToMove;
                    temporary.y = 0;
                    this.transform.position -= temporary;
                
            }
            if (Input.GetKey(KeyCode.D))
            {
                    
                    temporary = this.transform.right * amountToMove;
                    temporary.y = 0;
                    this.transform.position += temporary;
                
            }
                
        // Calculates movement of mouse in the x-axis
        yaw += cameraSpeed * Input.GetAxis("Mouse X") * Time.deltaTime;
        // Calculates movement of mouse in the y-axis
        //pitch += speed * Input.GetAxis("Mouse Y");
        // Applies the change in yaw and pitch to the angle of the camera

        pitch -= Input.GetAxis("Mouse Y") * cameraSpeed * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, minAngle, maxAngle);
        this.transform.eulerAngles += new Vector3(pitch, yaw, 0.0f);


       
    }

  
}
