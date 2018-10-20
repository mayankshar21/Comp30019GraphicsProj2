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
    public float minAngle = 20.0f;
    public float maxAngle = -45.0f;


    void Start()
    {
        // Initialize position of camera based on terrain size
        this.transform.position = new Vector3(28.06f, 0.69f, 2.12f);
       
        this.transform.eulerAngles += new Vector3(30.0f, 45.0f, 0.0f);

    }


    void FixedUpdate()
    {

        float yaw = 0.0f;
        float pitch = 0.0f;
        float newXRotation = 0.0f;
        float newYRotation = 0.0f;
        float amountToMove = Time.deltaTime * speed;
        Vector3 temporary;

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
        newYRotation = this.transform.eulerAngles.y + yaw;
        // Calculates movement of mouse in the y-axis
        // Applies the change in yaw and pitch to the angle of the camera
        if (newXRotation < 20.0f && newXRotation > 0.0f){
            this.transform.eulerAngles = new Vector3(newXRotation, newYRotation, 0.0f);
        }

            if (newXRotation < 340.0f && newXRotation < 360.0f)
            {
                this.transform.eulerAngles = new Vector3(newXRotation, newYRotation, 0.0f);
            }

        else{
            this.transform.eulerAngles = new Vector3(newXRotation- pitch, newYRotation , 0.0f);
        }
      
    }

  
}
