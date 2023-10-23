using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float speed;
    private GameObject focalPoint;

    // Start is called before the first frame update
    void Start()
    {
        focalPoint = GameObject.Find("Focal");
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        rigidbody.AddForce(focalPoint.transform.forward * speed * forwardInput);
    }
}
