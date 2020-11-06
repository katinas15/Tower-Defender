using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class EditorSnap : MonoBehaviour
{
    [SerializeField] [Range(1f, 20f)] float gridSize = 10f;
    TextMesh textMesh;

    void Start() {
        
    }
    void Update()
    {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / (gridSize * gridSize)) * gridSize * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / (gridSize * gridSize)) * gridSize * gridSize;

        textMesh = GetComponentInChildren<TextMesh>();
        string label = snapPos.x/ gridSize/ gridSize + ", " + snapPos.z / gridSize / gridSize;
        textMesh.text = label;

        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);
        gameObject.name = label;
        
    }
}
