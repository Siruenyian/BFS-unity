# Game Project - Breadth First Search implementation

## Info

Project Lost Infind was made to fulfill the quiz 2 of Design Analysis and Algorithms(C). The project uses a game engine called unity which is flexible for making 3D games. As it was tasked to implement an algorithm for an application/game, this game implements an algorithm called Breadth First Search which is able to find the closest path of a given point A to B.

## The BFS Algorithm

In this game, the enemy pathfinding uses a unity(C#) implementation of the BFS Algorithm. The basic concept behind BFS is where the algo starts exploring the graph from a selected node and then continues on traversing the neighboring nodes layerwise. As the name BFS suggest, it is required to traverse the graph breadthwise as follows:

1. First move horizontally and visit all the nodes of the current layer
2. Move to the next layer
   While traversing other nodes, the algorithm must avoid checking the same node twice, this can be achieved by implementing a Boolean in each node or a Boolean array. In many implementations a queue is used to store a node an mark it as visited until all its neighbours that are connected to it are marked. As a queue follows a FIFO(first in first out) manner, the neighbor of the node will be visited in an orderly fashion.

```
//G is the graph and s is the source node
BFS (G, s)
      let Q be queue.
      //Inserting s in queue until all its neighbour vertices are marked.
      Q.enqueue( s )

      mark s as visited.
      while ( Q is not empty)
           //Removing that vertex from queue,whose neighbour will be visited now
           v  =  Q.dequeue( )

          //processing all the neighbours of v
          for all neighbours w of v in Graph G
               if w is not visited
                        Q.enqueue( w )
                        //Stores w in Q to further visit its neighbour
                        mark w as visited.

```

The above is the implemented pseudocode of the idea.

## Node Representation in Unity

Each node in a graph will be represented as a gameobject with a Node.cs script attached to it. The graph itself is a collection of nodes in a single scene.

## The BFS algorithm

The BFS algorithm is represented by a class that derives from MonoBehaviour called SearchPath.cs. In this script, the search parameters are declared, such as:

1. Starting Point Node
2. Ending Point Node
3. Current Node

   In addition to the initial search parameters several other objects are also declared:

4. \_block = Dictionary to store all the nodes and their positions
5. \_directions = Array to store searching directions(up, down, left, right)
6. \_queue = a queue which be used for the BFS
7. \_path = a list for storing the correct path to the target

### BFS()

the main BFS function firstly enqueues the starting point. Then while the queues still has an element, assigns the \_searchingpoint node to the node which is dequeued off. Right after, the helper function ExploreNeighbourNodes is called which will explore the neighbour nodes and push them into the queue, effectively making this a breath first search.

### ExploreNeighbourNodes()

The helper function ExploreNeighbourNodes will firstly loop trough all direction(up, down, left, right) o try and find the neighbour node. If a node in a given direction exist, it must also be a key to a value in the \_block dictionary. After validating the node, enqueue it to the queue, mark it as explored and, make a note of its parent where it was explored from.
