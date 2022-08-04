using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalStats
{
    public OrganismType Type { get; private set; }

    public string sex;
    public float age;

    public float maxGrowth;
    public float size;

    public float hunger;
    public float thirst;
    public float reproductiveUrge;

    public AnimalStats(OrganismType type, float initialAge = -1)
    {
        initialAge = initialAge == -1 ? type.maxAge / 2f : initialAge;

        this.Type = type;

        sex = Random.Range(0, 2) == 0 ? "Male" : "Female";
        maxGrowth = 1;

        age = initialAge;

        // Make size dependant of age using a curve
        size = 1;
    }

    public void Simulate(float deltaTime)
    {
        thirst += deltaTime;
        hunger += deltaTime;
        reproductiveUrge += deltaTime;

        size += deltaTime;
        age += deltaTime;
    }
}
