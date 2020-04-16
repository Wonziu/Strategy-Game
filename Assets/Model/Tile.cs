public enum TileType {
    Empty,
    Building,
    Terrain
}

public class Tile
{
    public TileType Type = TileType.Empty;

    private Terrain terrain;
    private Building building;

    public int X { get; private set; }
    public int Y { get; private set; }

    public Tile(int x, int y)
    {
        X = x;
        Y = y;
    }
}