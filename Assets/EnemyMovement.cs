﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Block> path;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Block b in path){
            print(b.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
