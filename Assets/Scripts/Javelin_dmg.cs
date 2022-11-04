using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Javelin_dmg : MonoBehaviour
{
    GameObject javelin;
    [SerializeField] float damage;


    // Start is called before the first frame update
    void Start()
    {
        javelin = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDMG(damage);
            if (javelin != null)
            {
                Destroy(javelin);
            }
        }
    }
}
