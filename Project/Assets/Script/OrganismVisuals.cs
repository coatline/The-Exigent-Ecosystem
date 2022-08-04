using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganismVisuals : MonoBehaviour
{
    [SerializeField] AnimalVisuals avPrefab;

    public AnimalVisuals GetAnimalVisual(Animal o)
    {
        return Instantiate(avPrefab, new Vector3(o.X, o.Y), Quaternion.identity);
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
