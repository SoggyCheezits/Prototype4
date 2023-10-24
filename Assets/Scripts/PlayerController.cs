using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float speed;
    private GameObject focalPoint;

    public bool hasPowerUp;
    public float powerForce;
    public int powerCoolDown;

    public GameObject powerIndicator;


    // Start is called before the first frame update
    void Start()
    {
        focalPoint = GameObject.Find("Focal");
        rigidbody = GetComponent<Rigidbody>();
        powerIndicator.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        rigidbody.AddForce(focalPoint.transform.forward * speed * forwardInput);

        powerIndicator.transform.position = transform.position;

        if (hasPowerUp)
        {
            powerIndicator.gameObject.SetActive(true);
        }
        else if (!hasPowerUp)
        {
            powerIndicator.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position).normalized;

            enemyRigidbody.AddForce(awayFromPlayer * powerForce, ForceMode.Impulse);
            StartCoroutine(PowerupCountdown(powerCoolDown));
        }
    }

    IEnumerator PowerupCountdown(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        hasPowerUp = false;
    }
}
