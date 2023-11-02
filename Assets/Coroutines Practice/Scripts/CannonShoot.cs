using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    public GameObject cannonBall;
    public GameObject barrel;

    public float projectileBase;
    public float shootDelay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Shoot(projectileBase);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            StartCoroutine(RapidFire(projectileBase, shootDelay));
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Shoot(projectileBase * 2);
        }


    }

    public void Shoot(float projectileNum)
    {
        for(int i = 0; i < projectileNum; i++)
        {
            Instantiate(cannonBall, barrel.transform.position, transform.rotation);
        }

    }

    IEnumerator RapidFire(float projectileNum, float delay)
    {
        for (int i = 0; i < projectileNum; i++)
        {
            Instantiate(cannonBall, barrel.transform.position, transform.rotation);
            yield return new WaitForSeconds(delay);
        }
    }
}
