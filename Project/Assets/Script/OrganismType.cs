using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Organism", menuName = "New Animal")]

public class OrganismType : ScriptableObject
{
    public List<OrganismType> prey;

    public AudioClip reproduceSound;
    public AudioClip eatSound;
    public AudioClip dieSound;

    public Sprite sprite;

    public int viewDistance;
    public int initalAmount;
    public int chaseSteps;
    public int maxHealth;
    public int maxAge;

    public float nutrition;
    public float regenerateRate;
    public float hungerRate;
    public float thirstRate;
    public float speed;
}
