using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for snapping the nodes / cube in the editor
// The size of cube is currently 10 in x and z

// This script will be executed in edit mode
[ExecuteInEditMode]                                       
[RequireComponent(typeof(Node))]
public class CubeEditorInEditMode : MonoBehaviour
{
    private Node _node;
    private int _gridSize;                                



    private void OnEnable()
    {
        _node = GetComponent<Node>();                     
    }



    void Start()
    {
        _gridSize = _node.GridSize;
    }


    // Ensure that grid is always snapped
    void Update()
    {
        SnapToGrid();
    }


    // For snapping to grid
    private void SnapToGrid()
    {
        transform.position = new Vector3(_node.GetPos().x * _gridSize, 0f, _node.GetPos().y * _gridSize);
    }
}
