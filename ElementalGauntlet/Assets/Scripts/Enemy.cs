using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Transform[] patrolPoints;
    private int counter = 0;

    public Transform player;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectile;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[counter].position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, patrolPoints[counter].position) < 0.2F)
        {
            counter = (counter + 1) % patrolPoints.Length;
        }

        if(Vector3.Distance(transform.position, player.position) < 10f)
        {
            if(timeBtwShots <= 0)
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
            }else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }
}
