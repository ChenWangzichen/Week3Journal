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

    //set velocity as a float
    private float velocity;
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
        //if (velocity < maxSpeed)
        //{
        //    velocity += acceleration * Time.deltaTime;
        //}
        //else
        //{
        //    velocity = maxSpeed;
        //}

        ////press leftArrow, x-1
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.position += velocity * Vector3.left*Time.deltaTime;
        //}
        ////press right, x+1
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.position += velocity * Vector3.right*Time.deltaTime;
        //}
        ////press up, y+1
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    transform.position += velocity * Vector3.up*Time.deltaTime;
        //}
        ////press down, y-1
        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    transform.position += velocity * Vector3.down*Time.deltaTime;
        //}
        ////reset the velocity when releaced the key. so it won't speed up forever
        //if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        //{
        //    velocity = 0;
        //}

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += velocity * Vector3.left * Time.deltaTime;
        }
    }
}
