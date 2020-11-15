using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    Transform targetEnemy;
    [SerializeField] float attackRange = 10f;
    [SerializeField] ParticleSystem projectile;

    [SerializeField] Transform objectToPan;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetClosestEnemy();
        if(!targetEnemy) return;
        objectToPan.LookAt(targetEnemy);

        float distanceToEnemy = Vector3.Distance(
            targetEnemy.transform.position, 
            gameObject.transform.position);

        var emission = projectile.emission;

        if(distanceToEnemy <= attackRange){
            emission.enabled = true;
        } else {
            emission.enabled = false;
        }
    }

    private void GetClosestEnemy(){
        var enemies = FindObjectsOfType<EnemyMovement>();
        if(enemies.Length == 0) return;

        Transform closest = enemies[0].transform;


        foreach(EnemyMovement enemy in enemies){
            float distanceA = Vector3.Distance(
                gameObject.transform.position,
                closest.position);

            float distanceB = Vector3.Distance(
                gameObject.transform.position,
                enemy.transform.position);

            if(distanceA < distanceB) closest = enemy.transform;
        }

        targetEnemy = closest;

    }


}
