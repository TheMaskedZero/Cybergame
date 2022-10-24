using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    [SerializeField] float ammoCount = 0;
    [SerializeField] float magSize;

    [SerializeField] TMP_Text ammoUI;

    [SerializeField] KeyCode relaodKey = KeyCode.R;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ammoUI.text = string(ammoCount);
    }

    void Reload()
    {
        if (Input.GetKeyDown(relaodKey))
        {
            ammoCount = magSize;
        }        
    }
}
