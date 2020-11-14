using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float between = 2f;
    [SerializeField] EnemyMovement prefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn(){
        while(true){
            Instantiate(prefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(between);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
