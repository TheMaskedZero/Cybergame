using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemy;

    [SerializeField] float enemyHealth;

    [SerializeField] Transform target;
    NavMeshAgent nav;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(target.position);

        if (enemyHealth <= 0)
        {
            enemy.SetActive(false);
            Debug.Log("HE DEAD");
        }
    }

    public void TakeDMG (float amount)
    {
        enemyHealth -= amount;
        Debug.Log(enemyHealth);
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SLAH"))
        {
            enemyHealth -= 1;
            Debug.Log("he was hit");
        }
    }*/
}
