using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    [SerializeField] private int _gridSize = 11;                              // Grid snap units
    [SerializeField] private GameObject _highlight;
    [SerializeField] private GameObject _obstackle;

    public bool isobstacle = false;
    public int GridSize { get { return _gridSize; } }

    public bool isExplored = false;
    public Node isExploredFrom;
    Enemy enemy;
    private void Start()
    {
        enemy = FindObjectOfType<Enemy>();
    }

    //Set or remove obstacle
    public void SetObstacle()
    {
        _obstackle.SetActive(true);
        isobstacle = true;
    }
    public void RemoveObstacle()
    {
        _obstackle.SetActive(false);
        isobstacle = false;
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
        if (GameManager.Instance.isPaused == false)
        {
            _highlight.SetActive(true);
        }
    }
    private void OnMouseExit()
    {
        _highlight.SetActive(false);

    }
    // Every click sets an ending point, right after we move to that point
    private void OnMouseDown()
    {
        Debug.Log("Pressed!");
        if (GameManager.Instance.isPaused == false)
        {
            SetObstacle();
        }

    }
}
