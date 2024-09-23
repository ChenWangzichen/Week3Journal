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
    private Vector3 vVelocity = new Vector3(1f,0);
    private Vector3 hVelocity = new Vector3(0,1f);

    void Update()
    {
        //call player movement method
        PlayerMovement();
    }
    public void PlayerMovement()
    {
        //press leftArrow, x-1
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= vVelocity*Time.deltaTime;
        }
        //press right, x+1
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += vVelocity*Time.deltaTime;
        }
        //press up, y+1
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += hVelocity*Time.deltaTime;
        }
        //press down, y-1
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= hVelocity*Time.deltaTime;
        }
    }
}
