using UnityEngine;
using System.Collections;
using System.Xml.Serialization;

public class Enemy : MonoBehaviour
{
    public Transform playerTransform;
    public float targetDistance;
    public float speed;
    public float bombSpeed;
    public GameObject bombPrefab;

    private void Start()
    {
        StartCoroutine(SpawnBombs());
    }

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

    IEnumerator SpawnBombs()
    {
        while(true)
        {
            yield return new WaitForSeconds(3f);

            FireBomb();
        }
    }
    public void FireBomb()
    {
        Vector3 spawnPosition = transform.position + Vector3.up;
        GameObject bomb = Instantiate(bombPrefab, spawnPosition, Quaternion.identity);

        Vector3 bDirection = (playerTransform.position - spawnPosition).normalized;

        Bomb bombMovement = bomb.AddComponent<Bomb>();
        bombMovement.Initialized(bDirection, bombSpeed);        
    }
}
