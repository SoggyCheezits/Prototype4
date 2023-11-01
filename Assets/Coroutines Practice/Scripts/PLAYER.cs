using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PLAYER : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;

    public float moveSpeed = 10;
    public float turnSpeed = 180;
    public float jumpForce = 5;

    public bool isOnGround;

    public Rigidbody rb;
    public GameObject bullet;

    public GameObject spawnPoint;
    public float shootDelay;

    public bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        isOnGround = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * moveSpeed);
        transform.Rotate(Vector3.up * Time.deltaTime * horizontalInput * turnSpeed);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            Instantiate(bullet, spawnPoint.transform.position, spawnPoint.transform.rotation);
            StartCoroutine(CoolDown(shootDelay));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true; 
        }
    }

    IEnumerator CoolDown(float seconds)
    {
        canShoot = false;
        yield return new WaitForSeconds(seconds);
        canShoot = true;
    }
}
