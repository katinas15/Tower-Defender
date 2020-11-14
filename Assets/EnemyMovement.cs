using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Block> path){
        print("start");
        foreach(Block b in path){
            transform.position = b.transform.position;
            // print(b.name);
            yield return new WaitForSeconds(1f);
        }
        print("end");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
