using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    //set 2 velocity for horizontal and vertical
    //private Vector3 vVelocity = Vector3.right;
    //private Vector3 hVelocity = Vector3.up;

    //set velocity
    private float xSpeed;
    private float ySpeed;
    //private Vector3 velocity;
    //set maxspeed and acceleration time
    public float maxSpeed;
    public float accelerationTime;
    float acceleration;
    //set deceleration time
    float deceleration;
    public float decelerationTime;

    private void Start()
    {
        acceleration = maxSpeed / accelerationTime;
        deceleration = maxSpeed / decelerationTime;
    }
    void Update()
    {
        //call player movement method
        PlayerMovement();

    }
    public void PlayerMovement()
    {
        //set direction towrds noreway
        Vector3 direction = Vector3.zero;
        //press arrow key to give direction a directiong
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = Vector3.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = Vector3.right;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction = Vector3.up;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction = Vector3.down;
        }
        //velocity and accleration calculate
        Vector3 velocity = new Vector3(xSpeed, ySpeed);
        velocity += acceleration * direction.normalized * Time.deltaTime;
        //the line to make player move 
        transform.position += velocity * Time.deltaTime;
        //deceleration
        if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) && xSpeed!=0)
        {
            velocity -= deceleration * direction.normalized * Time.deltaTime;
        }
        else if(Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) && ySpeed!=0)
        {
            velocity -= deceleration * direction.normalized * Time.deltaTime;
        }



   
    }
}
