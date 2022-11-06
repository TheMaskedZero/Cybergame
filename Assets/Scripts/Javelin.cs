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

    [Header("Settings")]
    //[SerializeField] int totalThrows; (don't use this part but found it neat, since it can be used for setting how many times the javelin can be thrown)
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
        
        //Changes the fill amount of the the white square over time, slowy filling it up again, over a given time.
        if (readyToThrow == false)
        {
            javelinQUi.fillAmount += 1 / throwCD * Time.deltaTime;

        }
    }

    //Throw is the function that Instantiates the javelin, and where it adds forces to the object.
    void Throw()
    {
        readyToThrow = false;

        spear = Instantiate(javelin, atkPoint.position, cam.rotation);

        Rigidbody spearRB = spear.GetComponent<Rigidbody>();

        Vector3 forceToAdd = cam.transform.forward * throwForce + transform.up * throwUpForce;

        spearRB.AddForce(forceToAdd, ForceMode.Impulse);

        //totalThrow --; (for the not used part)

        Invoke(nameof(ResetThrow), throwCD);
    }

    void ResetThrow()
    {
        readyToThrow = true;
    }
}
