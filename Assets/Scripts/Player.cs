using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Player : MonoBehaviour
{
    private SearchPath _searchPath;
    [SerializeField] private DialogueUI dialogueUI;

    public DialogueUI DialogueUI => dialogueUI;
    public Iinteractable Interactable { get; set; }
    [SerializeField] private float _movementSmoothing;
    [SerializeField] private float _yOffset;


    private void Start()
    {
        //get the reference to the searchpath
        _searchPath = FindObjectOfType<SearchPath>();
    }

    public void move()
    {
        //get the list first
        List<Node> lis = _searchPath.Path();
        // Check, ensure a path exist
        if (lis != null)        
        {
            StartCoroutine(Movement(lis));
        }
        else
        {
            Debug.Log("path does not exist!");
        }
     
    }

    IEnumerator Movement(List<Node> paths)
    {
        //iterate each tile to move
        foreach (Node path in paths) {

            Vector3 pos = path.transform.position;

            transform.position = new Vector3(pos.x, _yOffset, pos.z);
            yield return new WaitForSeconds(_movementSmoothing);
        }
        _searchPath._startingPoint = paths[paths.Count - 1];

        //_searchPath._startingPoint = paths.Last();

        /* GameManager.Instance.LoadNextLevel();
         Destroy(gameObject);*/
    }
}
