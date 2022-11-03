using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Javelin : MonoBehaviour
{
    //this code was inspired by https://www.youtube.com/watch?v=F20Sr5FlUlE

    [Header("Javelin")]
    [SerializeField] Transform cam, atkPoint;
    [SerializeField] GameObject javelin;
    [SerializeField] float damage;

    [Header("Settings")]
    //[SerializeField] int totalThrows;
    [SerializeField] float throwCD;

    [Header("UI")]
    [SerializeField] Image javelinQUi;

    [Header("Throwing")]
    [SerializeField] KeyCode throwKey = KeyCode.Q;
    [SerializeField] float throwForce;
    [SerializeField] float throwUpForce;

    bool readyToThrow;
    private GameObject spear;

    // Start is called before the first frame update
    void Start()
    {
        readyToThrow = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(throwKey) && readyToThrow)
        {
            Throw();

            javelinQUi.fillAmount = 0f;
        }

        /*if (throwCD < 10)
        {
            javelinQUi.fillAmount += (1 * Time.deltaTime) / 10;
        }*/
    }

    void Throw()
    {
        readyToThrow = false;

        spear = Instantiate(javelin, atkPoint.position, cam.rotation);

        Rigidbody spearRB = spear.GetComponent<Rigidbody>();

        Vector3 forceToAdd = cam.transform.forward * throwForce + transform.up * throwUpForce;

        spearRB.AddForce(forceToAdd, ForceMode.Impulse);

        //totalThrow --;

        Invoke(nameof(ResetThrow), throwCD);
    }

    void ResetThrow()
    {
        readyToThrow = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDMG(damage);
            if (spear != null)
            {
                Destroy(spear);
            }
        }
    }
}
