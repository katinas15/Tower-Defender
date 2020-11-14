using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Block start, end;
    Dictionary<Vector2Int, Block> grid = new Dictionary<Vector2Int, Block>();
    Queue<Block> queue = new Queue<Block>();
    Block center;
    private List<Block> path = new List<Block>();

    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.down,
        Vector2Int.left,
        Vector2Int.right
    };

    void Start()
    {

        
    }

    public List<Block> GetPath(){
        if(path.Count <= 0) {
            start.SetTopColor(Color.blue);
            grid.Add(start.GetGridPos(), start);

            end.SetTopColor(Color.black);
            grid.Add(end.GetGridPos(), end);
            
            LoadBlocks();
            Traverse();
            CreatePath();
        }
        
        return path;
    }

    private void CreatePath(){
        path.Add(end);
        Block previous = end.exploredFrom;
        while(previous != start){
            path.Add(previous);
            previous = previous.exploredFrom;
        }
        path.Add(start);
        path.Reverse();
    }

    private void Traverse(){
        queue.Enqueue(start);
        while(queue.Count > 0){
            center = queue.Dequeue();
            center.isExplored = true;
            print(center);
            if(center == end){
                print("found the end");
                break;
            }

            Explore();
        }
    }

    private void Explore(){
        foreach (var item in directions)
        {
            var pos = center.GetGridPos() + item;
            
            if(grid.ContainsKey(pos)){
                Block searching = grid[pos];
                if(!searching.isExplored || queue.Contains(searching)){
                    searching.SetTopColor(Color.green);
                    queue.Enqueue(searching);
                    searching.exploredFrom = center;
                    print("queeueing " + searching);  
                }
                
            }
            
        }
    }

    void LoadBlocks(){
        var blocks = FindObjectsOfType<Block>();
        foreach(Block b in blocks){
            var pos = b.GetGridPos();
            
            if(grid.ContainsKey(pos)){
                Debug.LogWarning("duplicate block found " + pos);
            } else {
                grid.Add(pos, b);
            }

        }
        print("all blocks loaded");
    }

    void Update()
    {
        
    }
}
