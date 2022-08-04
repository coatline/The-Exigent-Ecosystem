using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileVisuals : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    World world;

    private void Awake()
    {
        world = WorldController.I.World;

        Dictionary<Vector3Int, Tile> initialTiles = new Dictionary<Vector3Int, Tile>();

        for (int x = 0; x < world.Width; x++)
            for (int y = 0; y < world.Height; y++)
            {
                WorldCell cell = world.GetCell(x, y);

                cell.RegisterOnTileTypeChanged(TileChanged);

                initialTiles.Add(new Vector3Int(x, y, 0), cell.Tile.tile);
            }

        tilemap.SetTiles(initialTiles.Keys.ToArray(), initialTiles.Values.ToArray());
    }

    void TileChanged(WorldCell cell)
    {
        tilemap.SetTile(new Vector3Int(cell.X, cell.Y, 0), cell.Tile.tile);
    }
}
