using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //This code was inspired from: https://www.youtube.com/watch?v=THnivyG0Mvo

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

        //Disables the enemy when it runs out of health
        if (enemyHealth <= 0)
        {
            enemy.SetActive(false);
            Debug.Log("HE DEAD");
        }
    }

    //Function used to deal damage to the enemy
    public void TakeDMG (float amount)
    {
        enemyHealth -= amount;
        Debug.Log(enemyHealth);
    }
}
