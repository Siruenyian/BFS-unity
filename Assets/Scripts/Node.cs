using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    
    [SerializeField] private int _gridSize = 11;                              // Grid snap units
    [SerializeField] private GameObject _highlight;
    public int GridSize { get { return _gridSize; } }
    private SearchPath searchPath;
    public bool isExplored = false;
    public Node isExploredFrom;
    Player player;
    private void Start()
    {
        searchPath = FindObjectOfType<SearchPath>();
        player = FindObjectOfType<Player>();
    }


    private void Update()
    {
        
    }

    // Get the current pos
    // Used in CubeEditorInEditMode.cs for snapping to grid
    public Vector2Int GetPos()
    {
        return new Vector2Int(Mathf.RoundToInt(transform.position.x / _gridSize), 
                              Mathf.RoundToInt(transform.position.z / _gridSize));
    }

    //For highlighting a destination
    private void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }
    private void OnMouseExit()
    {
        _highlight.SetActive(false);

    }
    // Every click sets an ending point, right after we move to that point
    private void OnMouseDown()
    {
        Debug.Log("Pressed!");
        searchPath._endingPoint = this.gameObject.GetComponent<Node>();
        player.move();
    }
}
