using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    public GameObject powerUpPrefab;

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

    //set public parameters of radar
    public float radius = 3;
    public int circlePoints = 5;

    public float powerRadius = 3;
    public int numberOfPowerups = 8;

    private void Start()
    {
        acceleration = maxSpeed / accelerationTime;
    }
    void Update()
    {
        //call player movement method
        PlayerMovement();
        //call the method
        EnemyRadar(radius, circlePoints);
        //call power up
        SpawnPowerups(powerRadius, numberOfPowerups);

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
        //set the velocity remain the max speed
        if (velocity.magnitude >= maxSpeed)
        {
            velocity = maxSpeed * velocity.normalized;
        }
        //the line to make player move 
        transform.position += velocity * Time.deltaTime;

    }
    public void EnemyRadar(float radius, int circlePoints)
    {
        //set color for change color
        Color circle;
        if (Vector3.Distance(transform.position, enemyTransform.position) <= radius)
        {
            circle = Color.red;
        }
        else
        {
            circle = Color.green;
        }

        //set starting point of the cirecle
        Vector3 point = new Vector3(radius, 0);

        //in a for loop, calculate position of next point, then draw from point to next point
        for (int i = 1; i <= circlePoints; i++)
        {
            //get end point of 1 line, start with 1 since starting point is setted.
            Vector3 nextPoint = new Vector3(Mathf.Cos(360 / circlePoints * i * Mathf.Deg2Rad), Mathf.Sin(360 / circlePoints * i * Mathf.Deg2Rad)) * radius;

            //add player position so the circle is around player not origin
            Debug.DrawLine(nextPoint + transform.position, point + transform.position, circle);

            //ready for next next point
            point=nextPoint;
        }

    }

    public void SpawnPowerups(float radius, int numberOfPowerups)
    {
        //in a for loop, calculate position the point
        for (int i = 0; i < numberOfPowerups; i++)
        {
            //get point position
            Vector3 point = new Vector3(Mathf.Cos(360 / numberOfPowerups * i * Mathf.Deg2Rad), Mathf.Sin(360 / numberOfPowerups * i * Mathf.Deg2Rad)) * radius;

            //instantiate the prefab at that point
            GameObject power = Instantiate(powerUpPrefab);

            //change around origin to around olayer
            power.transform.position = point + transform.position;
        }
    }
}
