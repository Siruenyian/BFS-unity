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
        move();
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
    int tries = 0;
    IEnumerator Movement(List<Node> paths)
    {
        bool prev;
        //iterate each tile to move
        Debug.Log("==============================================================================");
        for (int i = 0; i < paths.Count; i++)
        {
            //Debug.Log("ohoho "+i+paths[i].isobstacle);
            if (paths[i].isobstacle)
            {
                //if the agent is still tring the same path
                Debug.Log("Tries Path " + tries+" "+paths.Count);

                if (tries == paths.Count)
                {
                    paths[i].RemoveObstacle();
                    tries++;
                    //break;
                }
                tries = paths.Count;
                _searchPath._startingPoint = paths[i-1];
                paths = _searchPath.Path();
                StartCoroutine(Movement(paths));
                yield break;
            }
            Vector3 pos = paths[i].transform.position;

            transform.position = new Vector3(pos.x, _yOffset, pos.z);
            yield return new WaitForSeconds(_movementSmoothing);
        }
        paths.Clear();
        //_searchPath._startingPoint = paths[paths.Count - 1];

        //_searchPath._startingPoint = paths.Last();

        /* GameManager.Instance.LoadNextLevel();
         Destroy(gameObject);*/
    }
}
