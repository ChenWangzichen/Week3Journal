using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;
    Vector3 target;


    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        AsteroidMovement();
    }
    public void AsteroidMovement()
    {
        //set the target
        Vector3 target = transform.position + new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 0) * maxFloatDistance;
        if (Vector2.Distance(target,transform.position) >= arrivalDistance)
        {
            transform.position += moveSpeed * (target - transform.position).normalized * Time.deltaTime;
        }
        else
        {
            target = transform.position + new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 0) * maxFloatDistance;
        }

    }
}
