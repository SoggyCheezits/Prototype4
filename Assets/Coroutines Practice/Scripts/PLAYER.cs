using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PLAYER : MonoBehaviour
{
    #region [Movement]
    public float horizontalInput;
    public float verticalInput;
    public float moveSpeed = 10;
    public float turnSpeed = 180;
    #endregion

    #region [Jumping]
    public float jumpForce = 5;
    public bool isOnGround;
    public Rigidbody rb;
    #endregion

    #region [Shooting]
    public GameObject bullet;
    public GameObject spawnPoint;
    public float shootDelay;
    public bool canShoot = true;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        isOnGround = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        #region [Movement]
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * moveSpeed);
        transform.Rotate(Vector3.up * Time.deltaTime * horizontalInput * turnSpeed);
        #endregion

        #region [Jumping]
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
        #endregion

        #region [Shooting]
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            Instantiate(bullet, spawnPoint.transform.position, spawnPoint.transform.rotation);
            StartCoroutine(CoolDown(shootDelay));
        }
        #endregion
    }

    private void OnCollisionEnter(Collision collision)
    {
        #region [isOnGround]
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true; 
        }
        #endregion
    }

    #region [CoolDown]
    IEnumerator CoolDown(float seconds)
    {
        canShoot = false;
        yield return new WaitForSeconds(seconds);
        canShoot = true;
    }
    #endregion
}
