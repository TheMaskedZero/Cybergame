using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    //this script is basically just the gun script but slightly changed, to not have ammo for exmaple.

    [SerializeField] float damage;
    [SerializeField] float swingRange;
    [SerializeField] Camera swordCam;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Slash();
        }
    }

    void Slash()
    {
        RaycastHit hit;
        if (Physics.Raycast(swordCam.transform.position, swordCam.transform.forward, out hit, swingRange))
        {
            Debug.Log(hit.transform.name);

            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDMG(damage);
            }
        }
    }
}
