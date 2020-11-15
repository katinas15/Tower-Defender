using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public bool isExplored = false;
    public Block exploredFrom;
    const int gridSize = 10;
    public bool isPlacable = true;
    [SerializeField] Tower tower;
    private bool towerPlaced = false;

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

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        if(Input.GetMouseButtonDown(0) && isPlacable){
            Debug.Log(gameObject.name);
            if(!towerPlaced){
                towerPlaced = true;
                Instantiate(tower, transform.position, Quaternion.identity);
            }
        }
        
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject.");
    }
}
