using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public bool isExplored = false;
    public Block exploredFrom;
    const int gridSize = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int GetGridSize(){
        return gridSize;
    }

    public Vector2Int GetGridPos(){
        return new Vector2Int(
                (int) transform.position.x / gridSize / gridSize,
                (int) transform.position.z / gridSize / gridSize);
    }

    public void SetTopColor(Color color){
        var top = transform.Find("Top");
        var render = top.GetComponent<MeshRenderer>();
        // print("colored");
        render.material.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
