using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;

    public float radius = 1f;
    public float speed = 20f;
    float angle = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(radius, speed, planetTransform);
    }

    public void OrbitalMotion(float radius, float speed, Transform target)
    {

        //speed is linear velocity,speed = angular velocity*radius.so angular velocity = speed/radius
        angle += speed / radius * Time.deltaTime;

        //get spin and plus target position to spin around target
        transform.position = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle))*radius + target.position;

    }
}
