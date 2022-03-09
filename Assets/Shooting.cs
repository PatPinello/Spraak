using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject spearPrefab;

    public float spearForce = 20f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed Button");
            Shoot();
        }
    }


void Shoot()
{
    GameObject spear = Instantiate(spearPrefab, firePoint.position, firePoint.rotation);
    Rigidbody2D rbb = spear.GetComponent<Rigidbody2D>();
    rbb.AddForce(firePoint.up * spearForce, ForceMode2D.Impulse);
}
}