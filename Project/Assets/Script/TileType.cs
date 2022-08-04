using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Tile", fileName = "New Tile")]

public class TileType : ScriptableObject
{
    public Tile tile;
    public bool passable;
    public bool grazable;
}
