using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SearchPath : MonoBehaviour
{

    [Header("Search Parameter")]
    [SerializeField] public Node _startingPoint;
    [SerializeField] public Node _endingPoint;
    [SerializeField] private Color _startingPointColor;
    [SerializeField] private Color _endingPointColor;
    [SerializeField] private Color _pathColor;
    // For storing all the nodes 
    private Dictionary<Vector2Int, Node> _block = new Dictionary<Vector2Int, Node>();
    // Directions to search in neoghtbour nodes(4 directions)
    private Vector2Int[] _directions = { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };
    // Queue for queueing nodes and traversing through them
    private Queue<Node> _queue = new Queue<Node>();
    // Current node we are searching
    private Node _searchingPoint;
    // For tracking if the algo is currently still exploring or not
    private bool _isExploring = true;                       

    // Used for storing the correct path to the target
    private List<Node> _path = new List<Node>();            


    // First method to do the searching and return the path to a player 
    public List<Node> Path() {
        
   
        ResetNods();
        _block.Clear();
        _path.Clear();
        _queue.Clear();
        LoadAllBlocks();
        BFS();
        CreatePath();
        return _path;
        
        
    }
  

    //preload all nodes and position in dictionary
    private void LoadAllBlocks()
    {
       
        Node[] nodes = FindObjectsOfType<Node>();

        foreach (Node node in nodes) {
            Vector2Int gridPos = node.GetPos();
            _block.Add(gridPos, node);

            //Debug.Log(node.name);
            // For checking if 2 nodes are in same position; i.e overlapping nodes
           /* if (_block.ContainsKey(gridPos))
            {
                Debug.LogWarning("2 Nodes present in same position. i.e nodes overlapped.");
            }
            else
            {
                // Add the position of each node as key and the Node as the value
                _block.Add(gridPos, node);       
            }*/
        }
        
    }


    // BFS - For finding the shortest path
    private void BFS()
    {
        //_isExploring = true;
        //operate bfs with queue
        _queue.Enqueue(_startingPoint);
        while (_queue.Count > 0 && _isExploring) {
            _searchingPoint = _queue.Dequeue();
            //OnReachingEnd();
            ExploreNeighbourNodes();
        }
    }


    // To check if we've reached the Ending point
    private void OnReachingEnd()
    {
        if (_searchingPoint == _endingPoint) {
            _isExploring = false;
        }
       
        //_isExploring = true;
        
    }


    // Searching the neighbouring nodes
    private void ExploreNeighbourNodes()
    {
        //if (!_isExploring) { return; }

        foreach (Vector2Int direction in _directions) {
            Vector2Int neighbourPos = _searchingPoint.GetPos() + direction;
            // If the explore neighbour is present in the dictionary _block, which contians all the blocks with Node.cs attached

            if (_block.ContainsKey(neighbourPos))                           
            {
                Node node = _block[neighbourPos];
                // For checking if we've already explore this node
                if (node.isExplored) { 
                //idk do something
                }                        
                else
                {
                    // Queueing the node at this position
                    _queue.Enqueue(node);
                    // Set the parent/predecessor of this node
                    node.isExplored = true;
                    node.isExploredFrom = _searchingPoint;      
                }
            }
        }

    }

    private void ResetNods()
    {
        //Reset every node to unexplored
        //treat the board as a brand new one with nodes unexplored
        foreach (KeyValuePair <Vector2Int, Node>  node in _block)
        {
            node.Value.isExplored = false;
        }


    }


    // Creating path by queueing the previous node
    // It'll provide the path, backwards, which will then be reversed
    public void CreatePath()
    {
        SetPath(_endingPoint);
        Node previousNode = _endingPoint.isExploredFrom;

        // While loop to set the path
        while (previousNode != _startingPoint) {
            SetPath(previousNode);
           

            Node isExploredFrom = previousNode.isExploredFrom;
            previousNode = isExploredFrom;
            
        }
        _path.Add(_startingPoint);
        //SetPath(_startingPoint);
        _path.Reverse();
        SetPathColor();
        
    }

    // For adding to the path
    private void SetPath(Node node) {
        _path.Add(node);
    }


   
    // Setting color to regular nodes
    private void SetPathColor()
    {
        foreach (Node node in _path) {
            node.GetComponentInChildren<Renderer>().material.color = _pathColor;
        }
        SetColor();
    }

    // Setting color to start and end nodes
    private void SetColor()
    {
        _startingPoint.GetComponentInChildren<Renderer>().material.color = _startingPointColor;
        _endingPoint.GetComponentInChildren<Renderer>().material.color = _endingPointColor;
    }
}
