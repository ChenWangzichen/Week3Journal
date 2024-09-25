using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    //set velocity
    private Vector3 velocity;
    //set maxspeed and acceleration time
    public float maxSpeed;
    public float accelerationTime;
    public float acceleration;
    //set deceleration time
    public float decelerationTime;
    //check if is decelerat
    bool isDecelerat = false;
    //set direction towrds noreway
    Vector3 direction = Vector3.zero;

    private void Start()
    {
        acceleration = maxSpeed / accelerationTime;
    }
    void Update()
    {
        //call player movement method
        PlayerMovement();

    }

    public void PlayerMovement()
    {

        //press arrow key to give direction a directiong
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //when get key hold, set acceleration, decelerat set as false.
            direction = Vector3.left;
            acceleration = maxSpeed / accelerationTime;
            isDecelerat = false;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = Vector3.right;
            acceleration = maxSpeed / accelerationTime;
            isDecelerat = false;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction = Vector3.up;
            acceleration = maxSpeed / accelerationTime;
            isDecelerat = false;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction = Vector3.down;
            acceleration = maxSpeed / accelerationTime;
            isDecelerat = false;
        }

        //when there no arrow key is hold and is not decelerat, decelerat.
        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) 
            && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) && !isDecelerat)
        {
            direction = -velocity;
            acceleration = velocity.magnitude / decelerationTime;
            isDecelerat=true;
        }
        //if it's decelerate and velocity small enough, set to 0
        if (isDecelerat && velocity.magnitude < 0.1)
        {
            velocity = Vector3.zero;
            acceleration = 0;
        }
        //velocity and accleration calculate
        velocity += acceleration * direction.normalized * Time.deltaTime;

        //the line to make player move 
        transform.position += velocity * Time.deltaTime;





   
    }
}
