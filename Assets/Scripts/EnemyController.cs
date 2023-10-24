using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed;
    public Rigidbody rigidbody;

    public float yLimit = -10;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerDirection = player.transform.position - transform.position;
        rigidbody.AddForce(playerDirection.normalized * moveSpeed);

        if(transform.position.y < yLimit)
        {
            Destroy(gameObject);
        }
    }
}
