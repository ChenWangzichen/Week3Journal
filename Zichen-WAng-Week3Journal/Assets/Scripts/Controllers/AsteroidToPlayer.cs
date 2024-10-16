using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidToPlayer : MonoBehaviour
{
    Vector3 direction;
    float speed;
    public float hitDistance;
    public Transform playerTransform;
    // Start is called before the first frame update
    public void Initialize(Vector3 moveD, float moveS)
    {
        direction = moveD;
        speed = moveS;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        //CheckHitrPlayer();

        if (IsOffScreen())
        {
            Destroy(gameObject);
        }
    }

    bool IsOffScreen()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        return screenPoint.x < 0 || screenPoint.x > 1 || screenPoint.y < 0 || screenPoint.y > 1;
    }
    //void CheckHitrPlayer()
    //{
    //    float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
    //    if (distanceToPlayer < hitDistance)
    //    {
    //        Player player = playerTransform.GetComponent<Player>();
    //        if (player != null)
    //        {
    //            player.OnHit();
    //        }

    //        Destroy(gameObject);
    //    }
    //}
}
