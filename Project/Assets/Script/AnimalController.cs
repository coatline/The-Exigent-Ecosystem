using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    [SerializeField] OrganismVisuals visuals;
    World world;

    void Start()
    {
        world = WorldController.I.World;

        for (int i = 0; i < DataLibrary.I.organisms.Length; i++)
        {
            OrganismType org = DataLibrary.I.organisms[i];

            for (int k = 0; k < org.initalAmount; k++)
            {
                CreateAnimal(org);
            }
        }
    }

    void CreateAnimal(OrganismType o)
    {
        Animal a = new Animal(o, world.GetOpenCell());
        AnimalVisuals av = visuals.GetAnimalVisual(a);
    }
}
