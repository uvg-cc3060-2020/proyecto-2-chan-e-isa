using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    private new Rigidbody rigidbody;
    public GameObject ourProjectile;
    private bool canShoot = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        Vector3 vectorMovement = new Vector3(xInput, 0, 0);

        rigidbody.AddForce(vectorMovement * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 vectorJump = new Vector3(0, jumpForce, 0);
            rigidbody.AddForce(vectorJump * jumpForce * Time.deltaTime, ForceMode.Impulse);
        }

        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {
            Instantiate(ourProjectile, transform.position, Quaternion.identity);
            Debug.Log("tirando balas");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            Debug.Log(collision.gameObject.tag);

            SceneManager.LoadScene("SampleScene");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WeakSpot")
        {
            Destroy(other.transform.parent.gameObject);
            canShoot = true;
        }
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log(other.gameObject.tag);

            SceneManager.LoadScene("SampleScene");
        }
    }

    
}
