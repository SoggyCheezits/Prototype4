using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{

    public Rigidbody rb;
    public float forcePower = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.up * forcePower, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*IEnumerator Shoot(float seconds)
    {

        yield return new WaitForSeconds(seconds);
    }*/
}
