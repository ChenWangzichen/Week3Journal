using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBelt : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public Transform playerTransform;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetAsteroid());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator GetAsteroid()
    {
        while (true)
        {
            //wait for random time
            float time = Random.Range(1, 2);
            yield return new WaitForSeconds(time);

            //move to player
            SpawnAsteroid();
        }
    }

    public void SpawnAsteroid()
    {
        //instantie object in random size
        GameObject astroid = Instantiate(asteroidPrefab, transform.position, Quaternion.identity);
        float randomSize = Random.Range(0.25f, 1);
        astroid.transform.localScale = new Vector2(randomSize, randomSize);

        Vector3 direction = (playerTransform.position - asteroidPrefab.transform.position).normalized;

        AsteroidToPlayer toPlayer = astroid.AddComponent<AsteroidToPlayer>();
        toPlayer.Initialize(direction, speed);
    }
}
