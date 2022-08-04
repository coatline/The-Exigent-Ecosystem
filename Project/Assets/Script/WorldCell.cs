using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldCell
{
    public int X { get; private set; }
    public int Y { get; private set; }

    #region Tile
    TileType tileType;

    public TileType Tile
    {
        get { return tileType; }
        set
        {
            if (value == tileType) return;

            tileType = value;

            TileTypeChanged?.Invoke(this);
        }
    }

    Action<WorldCell> TileTypeChanged;

    public void RegisterOnTileTypeChanged(Action<WorldCell> a)
    {
        TileTypeChanged += a;
    }

    #endregion

    Animal animal;
    public Animal CurrentAnimal
    {
        get
        {
            return animal;
        }
        set
        {
            if (animal == value) return;

            animal = value;

            NewAnimal?.Invoke(this);
        }
    }

    Action<WorldCell> NewAnimal;

    public void RegisterNewAnimal(Action<WorldCell> a)
    {
        NewAnimal += a;
    }

    public WorldCell(TileType type, int x, int y)
    {
        this.Tile = type;
        this.X = x;
        this.Y = y;
    }
}
