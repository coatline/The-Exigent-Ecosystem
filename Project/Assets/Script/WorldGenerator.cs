using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator
{
    int width, height;

    public void GenerateWorld(int width, int height, float scale, World world)
    {
        world.openCells = new List<WorldCell>();

        this.width = width;
        this.height = height;

        Generate(scale, world);
    }

    //AddInitialLife();

    void Generate(float scale, World world)
    {
        int offsetX = Random.Range(0, 1000000);
        int offsetY = Random.Range(0, 1000000);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                TileType type = GetTileType((offsetX + x), (offsetY + y), scale);
                WorldCell cell = new WorldCell(type, x, y);

                world.SetCell(x, y, cell);

                if (type.passable)
                {
                    world.openCells.Add(cell);
                }
            }
        }
    }

    TileType GetTileType(float x, float y, float scale)
    {
        var val = Mathf.PerlinNoise(((x * scale) /*/ width*/), ((y * scale) /*/ height*/));

        if (val < .35f)
        {
            return DataLibrary.I.GetTile("Water");
        }
        else
        {
            return DataLibrary.I.GetTile("Grass");
        }
    }

    //void AddInitialLife()
    //{
    //    for (int i = 0; i < animals.Count; i++)
    //    {
    //        for (int j = 0; j < animals[i].initalAmount; j++)
    //        {
    //            var rand = Random.Range(0, openTiles.Count);

    //            var animal = Instantiate(animalPrefab, openTiles[rand], Quaternion.identity, this.transform);
    //            animal.GetComponent<Animal>().myData = animals[i];
    //        }
    //    }
    //}
}
