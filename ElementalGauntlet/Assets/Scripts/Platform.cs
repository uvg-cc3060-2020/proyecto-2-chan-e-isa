using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float speed;
    public Transform[] patrolPoints;
    private int counter = 0;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[counter].position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, patrolPoints[counter].position) < 0.2F)
        {
            counter = (counter + 1) % patrolPoints.Length;
        }
    }
}
