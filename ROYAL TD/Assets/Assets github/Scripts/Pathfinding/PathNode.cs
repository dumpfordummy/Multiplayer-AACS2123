public class PathNode
{

    private GridBase<PathNode> grid;
    public int x;
    public int y;

    public int gCost; // walking cost from the start node
    public int hCost; // cost to reach end node
    public int fCost; // g + h
    public bool isOccupied;
    public bool isWalkable; 
    public PathNode cameFromNode; // for backtracking to find back the path

    public PathNode(GridBase<PathNode> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
        isWalkable = true;
        isOccupied = false;
    }

    public void CalculateFCost()
    {
        fCost = gCost + hCost;
    }

    public void SetIsWalkable(bool isWalkable)
    {
        this.isWalkable = isWalkable;
        grid.TriggerGridObjectChanged(x, y);
    }

    public override string ToString()
    {
        return x + "," + y;
    }

    public bool IsEqual(PathNode node)
    {
        return this.x == node.x && this.y == node.y;
    }
}
