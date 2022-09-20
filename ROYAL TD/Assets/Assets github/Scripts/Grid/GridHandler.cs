using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHandler : MonoBehaviour
{
    public static GridBase<PathNode> grid = new GridBase<PathNode>(100, 50, 1, new Vector3(-50, -25), (GridBase<PathNode> g, int x, int y) => new PathNode(g, x, y));
    public static Pathfinding pathInit = new Pathfinding(grid);
}
