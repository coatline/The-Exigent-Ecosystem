using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-10)]
public class DataLibrary : MonoBehaviour
{
    #region Statics
    static DataLibrary instance;
    public static DataLibrary I
    {
        get
        {
            return instance;
        }
        set
        {
            if (instance) { return; }
            else
            {
                instance = value;
            }
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Already A DataLibrary in scene. Deleting this one!");
            Destroy(gameObject);
            return;
        }

        Setup();
    }

    #endregion

    [HideInInspector]
    public OrganismType[] organisms;
    [HideInInspector]
    TileType[] tiles;

    Dictionary<string, OrganismType> getOrganism;
    Dictionary<string, TileType> getTile;

    void Setup()
    {
        organisms = Resources.FindObjectsOfTypeAll<OrganismType>();
        tiles = Resources.FindObjectsOfTypeAll<TileType>();

        getOrganism = new Dictionary<string, OrganismType>();
        getTile = new Dictionary<string, TileType>();

        for (int i = 0; i < organisms.Length; i++)
        {
            if (!organisms[i]) { print("Null Data!"); continue; }
            getOrganism.Add(organisms[i].name, organisms[i]);
        }

        for (int i = 0; i < tiles.Length; i++)
        {
            if (!tiles[i]) { print("Null Data!"); continue; }
            getTile.Add(tiles[i].name, tiles[i]);
        }
    }

    public OrganismType GetOrganism(string n)
    {
        getOrganism.TryGetValue(n, out OrganismType j);
        if (!j) { Debug.LogError($"Couldn't get {n}"); }
        return j;
    }

    public TileType GetTile(string n)
    {
        getTile.TryGetValue(n, out TileType j);
        if (!j) { Debug.LogError($"Couldn't get {n}"); }
        return j;
    }
}
