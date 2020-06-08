using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OurProjectile : MonoBehaviour
{

    public float speed;
    private Transform positionTransform;
    private Vector3 direction;
    private new Rigidbody rigidbody;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        positionTransform = GameObject.FindGameObjectWithTag("BulletDirection").transform;
        Vector3 direction = new Vector3(positionTransform.position.x, positionTransform.position.y, positionTransform.position.z);
        rigidbody.AddForce(direction * speed, ForceMode.Impulse);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WeakSpot")
        {
            Destroy(other.transform.parent.gameObject);
        }
    }
}
