using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Block))]
public class EditorSnap : MonoBehaviour
{
    TextMesh textMesh;
    Block block;
    int gridSize;

    void Start() {
        block =  GetComponent<Block>();
        gridSize = block.GetGridSize();
    }

    void Update()
    {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / (gridSize * gridSize)) * gridSize * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / (gridSize * gridSize)) * gridSize * gridSize;

        textMesh = GetComponentInChildren<TextMesh>();
       
        if(textMesh){
            string label = snapPos.x/gridSize/gridSize + ", " + snapPos.z/gridSize/gridSize;

            textMesh.text = label;
            gameObject.name = label;
        }
        

        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);
        
        
    }
}
