using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    [Header("Reload")]
    [SerializeField] float ammoCount = 0;
    [SerializeField] float magSize;

    [SerializeField] TMP_Text ammoUI;

    //[SerializeField] KeyCode relaodKey = KeyCode.R;

    [Header("Pew Pew")]
    [SerializeField] float damage;
    [SerializeField] float pewRange;
    [SerializeField] Camera pewCam;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ammoUI.text = $"{ammoCount}";
        Reload();

        if (Input.GetButtonDown("Fire1"))
        {
            if (ammoCount > 0)
            {
                ammoCount -= 1;
                Pewpew();
            }
        }
    }

    void Pewpew()
    {
        RaycastHit hit;
        if (Physics.Raycast(pewCam.transform.position, pewCam.transform.forward, out hit, pewRange))
        {
            Debug.Log(hit.transform.name);

            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDMG(damage);
            }
        }
    }

    void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R) && ammoCount == 0)
        {
            ammoCount += magSize;
        }        
    }
}
