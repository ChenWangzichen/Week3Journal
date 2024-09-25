using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public Transform playerTransform;
    public float targetDistance;
    public float speed;
    private void Update()
    {
        EnemyMovement();
    }

    public void EnemyMovement()
    {
        //set enemy direction
        Vector3 direction = playerTransform.position - transform.position;
        //move toward player
        if(Vector3.Distance(transform.position, playerTransform.position) > targetDistance)
        {
            transform.position += direction * speed * Time.deltaTime;
        }
        //keep away from player
        if(Vector3.Distance(transform.position,playerTransform.position) <= targetDistance)
        {
            transform.position -= direction * speed * Time.deltaTime;
        }
        
    }
}
