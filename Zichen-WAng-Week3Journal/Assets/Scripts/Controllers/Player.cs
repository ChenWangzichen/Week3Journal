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
    private Vector3 velocity;
    //set maxspeed and acceleration time
    public float maxSpeed;
    public float accelerationTime;
    float acceleration;

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
        velocity += acceleration * direction.normalized * Time.deltaTime;
        //the line to make player move 
        transform.position += velocity * Time.deltaTime;

        ////if (velocity < maxSpeed)
        ////{
        ////    velocity += acceleration * Time.deltaTime;
        ////}
        ////else
        ////{
        ////    velocity = maxSpeed;
        ////}

        //////press leftArrow, x-1
        ////if (Input.GetKey(KeyCode.LeftArrow))
        ////{
        ////    transform.position += velocity * Vector3.left*Time.deltaTime;
        ////}
        //////press right, x+1
        ////if (Input.GetKey(KeyCode.RightArrow))
        ////{
        ////    transform.position += velocity * Vector3.right*Time.deltaTime;
        ////}
        //////press up, y+1
        ////if (Input.GetKey(KeyCode.UpArrow))
        ////{
        ////    transform.position += velocity * Vector3.up*Time.deltaTime;
        ////}
        //////press down, y-1
        ////if (Input.GetKey(KeyCode.DownArrow))
        ////{
        ////    transform.position += velocity * Vector3.down*Time.deltaTime;
        ////}
        //////reset the velocity when releaced the key. so it won't speed up forever
        ////if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        ////{
        ////    velocity = 0;
        ////}

        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.position += velocity * Vector3.left * Time.deltaTime;
        //}
    }
}
