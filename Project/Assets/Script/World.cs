using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World
{
    public int Width { get; private set; }
    public int Height { get; private set; }

    public List<WorldCell> openCells;
    WorldGenerator generator;
    WorldCell[,] map;

    public World(int width, int height, float scale)
    {
        Width = width;
        Height = height;

        map = new WorldCell[width, height];
        generator = new WorldGenerator();

        generator.GenerateWorld(width, height, scale, this);
    }

    public void SetCell(int x, int y, WorldCell cell)
    {
        map[x, y] = cell;
    }

    public WorldCell GetCell(int x, int y)
    {
        return map[x, y];
    }

    public WorldCell GetOpenCell()
    {
        return openCells[Random.Range(0, openCells.Count)];
    }
}
