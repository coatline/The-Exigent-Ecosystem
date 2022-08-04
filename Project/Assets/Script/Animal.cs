using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animal
{
    //if you see a mate and reproductive urge is enough stop what you are doing and go have sex


    public int X { get; private set; }
    public int Y { get; private set; }

    public enum State
    {
        RunningFromPredator,
        SearchingForNeeds,
        ConsumingNeed,
        GoingToNeed,
        Wandering,
        Labor
    }

    AnimalVisuals visuals;
    World world;

    public Animal predator;
    Animal targetAnimal;

    State currentState;

    WorldCell targetCell;
    WorldCell currentCell;

    AnimalStats stats;

    public Animal(OrganismType type, WorldCell cell)
    {
        stats = new AnimalStats(type);

        world = WorldController.I.World;

        currentCell = cell;

        currentState = State.Wandering;
    }

    bool dead;

    void Die()
    {
        dead = true;
        visuals.Die();
    }

    public void ChangeState(State newState)
    {
        currentState = newState;

        //string need = "";
        //if (needIsFood) { need = "food"; }
        //else if (needIsWater) { need = "water"; }
        //else if (needIsReproduction) { need = "a mate"; }
    }

    void Logic()
    {

    }

    void DoStates()
    {
        if (currentState == State.Wandering)
        {
            Wander();
        }
        else if (currentState == State.SearchingForNeeds)
        {
            SearchForNeed();
        }
        else if (currentState == State.GoingToNeed)
        {
            //ChaseNeed();
        }
        else if (currentState == State.ConsumingNeed)
        {
            //ConsumeNeed();
        }
        else if (currentState == State.RunningFromPredator)
        {
            Run();
        }
        else if (currentState == State.Labor)
        {
            //Labor();
        }
    }

    //IEnumerator Disappear(bool showGrave)
    //{
    //    aSource.Play();
    //    yield return new WaitWhile(() => aSource.isPlaying);

    //    //if (showGrave)
    //    //{
    //    //    Instantiate(gravePrefab, transform.position, Quaternion.identity);
    //    //}

    //    //Destroy(myActionTextObject);

    //    //if (reproductiveUrge >= 100)
    //    //{
    //    //    Destroy(myReproductionBar, 5);
    //    //}
    //    //else
    //    //{
    //    //    Destroy(myReproductionBar);
    //    //}

    //    //if (needIsFood && hunger > 99)
    //    //{
    //    //    Destroy(myHungerBar, 5);
    //    //}
    //    //else
    //    //{
    //    //    Destroy(myHungerBar);
    //    //}

    //    //if (needIsWater && thirst > 99)
    //    //{
    //    //    Destroy(myThirstBar, 5f);
    //    //}
    //    //else
    //    //{
    //    //    Destroy(myThirstBar);
    //    //}

    //    //Destroy(gameObject);
    //}

    void Run()
    {
        //do not use hop use grid for movement

        //if (runTimer > .25f)
        //{
        //    if (predator.transform.position.x > transform.position.x)
        //    {
        //        rb.AddForce(new Vector2(-myData.speed, 0), ForceMode2D.Impulse);
        //    }
        //    else if (predator.transform.position.x < transform.position.x)
        //    {
        //        rb.AddForce(new Vector2(myData.speed, 0), ForceMode2D.Impulse);
        //    }

        //    if (predator.transform.position.y > transform.position.y)
        //    {
        //        rb.AddForce(new Vector2(0, -myData.speed), ForceMode2D.Impulse);
        //    }
        //    else if (predator.transform.position.y < transform.position.y)
        //    {
        //        rb.AddForce(new Vector2(0, myData.speed), ForceMode2D.Impulse);
        //    }

        //    runTimer = 0;
        //}
        //else
        //{
        //    runTimer += Time.deltaTime;
        //}
    }

    public void Update(float deltaTime)
    {
        if (dead) return;

        stats.Simulate(deltaTime);

        DoStates();
    }

    void SearchForNeed()
    {
        HopAround(1);
    }

    float hopTimer;

    void HopAround(float timeBeforeNewHop)
    {
        if (hopTimer > timeBeforeNewHop + RandomFloat(-.2f, .2f))
        {
            targetCell = RandAdjacentCell();
            hopTimer = 0;
        }
        else
        {
            hopTimer += Time.deltaTime;
        }
    }

    IEnumerator Move()
    {

        yield return new WaitForSeconds(0);


    }

    WorldCell RandAdjacentCell()
    {
        var rand = Random.Range(0, 4);

        switch (rand)
        {
            case 0: return world.GetCell(X + 1, Y);
            case 1: return world.GetCell(X - 1, Y);
            case 2: return world.GetCell(X, Y + 1);
            default: return world.GetCell(X, Y - 1);
        }
    }

    //void HopInRandomDir()
    //{
    //    var rand = Random.Range(0, 4);
    //    Vector2 force = Vector2.zero;
    //    switch (rand)
    //    {
    //        case 0: force = new Vector2(0, 1); break;
    //        case 1: force = new Vector2(0, -1); break;
    //        case 2: force = new Vector2(1, 0); break;
    //        case 3: force = new Vector2(-1, 0); break;
    //    }

    //    rb.AddForce(force);
    //}

    //void ChaseNeed()
    //{
    //if (target == null)
    //{
    //    ChangeState(State.SearchingForNeeds);
    //    return;
    //}

    //if (chaseTimer > .25f)
    //{
    //    chaseSteps++;

    //    if (target.transform.position.x > transform.position.x)
    //    {
    //        rb.AddForce(new Vector2(1, 0), ForceMode2D.Impulse);
    //    }
    //    else if (target.transform.position.x < transform.position.x)
    //    {
    //        rb.AddForce(new Vector2(-1, 0), ForceMode2D.Impulse);
    //    }

    //    if (target.transform.position.y > transform.position.y)
    //    {
    //        rb.AddForce(new Vector2(0, 1), ForceMode2D.Impulse);
    //    }
    //    else if (target.transform.position.y < transform.position.y)
    //    {
    //        rb.AddForce(new Vector2(0, -1), ForceMode2D.Impulse);
    //    }

    //    if (Vector2.Distance(transform.position, target.transform.position) <= .85f)
    //    {
    //        if (needIsReproduction)
    //        {
    //            if (sex == "Male")
    //            {
    //                reproductiveUrge = 0;
    //                target.GetComponent<Animal>().currentState = State.Labor;
    //            }
    //            //else
    //            //{
    //            //    ChangeState(State.Labor);
    //            //}
    //        }
    //        else
    //        {
    //            ChangeState(State.ConsumingNeed);
    //        }
    //    }

    //    if (chaseSteps >= myData.chaseSteps)
    //    {
    //        GiveUp();
    //    }

    //    chaseTimer = 0;
    //}
    //else
    //{
    //    chaseTimer += Time.deltaTime;
    //}
    //}

    void Wander()
    {
        HopAround(2);
    }

    #region OldCollisionStuff

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Water") && currentState == State.GoingToNeed && needIsWater)
    //    {
    //        ChangeState(State.ConsumingNeed);
    //    }
    //    else if (collision.gameObject.CompareTag("Border") && currentState == State.RunningFromPredator)
    //    {
    //        HopAround(.25f);
    //        predator = null;
    //    }
    //}

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Water") && currentState == State.GoingToNeed && needIsWater)
    //    {
    //        ChangeState(State.ConsumingNeed);
    //    }
    //    else if (collision.gameObject.CompareTag("Border") && currentState == State.RunningFromPredator)
    //    {
    //        HopAround(.25f);
    //    }
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (currentState != State.SearchingForNeeds) { return; }

    //    if (collision.gameObject.tag == "Animal")
    //    {
    //        var animalScript = collision.gameObject.GetComponent<Animal>();

    //        if (needIsFood && myData.prey.Contains(animalScript.myData))
    //        {
    //            if (collision.gameObject.tag == "Animal")
    //            {
    //                if (hunger < 50)
    //                {
    //                    return;
    //                }
    //            }

    //            target = collision.gameObject;
    //            ChangeState(State.GoingToNeed);

    //            target.gameObject.GetComponent<Animal>().predator = this.gameObject;
    //        }
    //        else if (needIsReproduction)
    //        {
    //            if (myData == animalScript.myData)//SAME SPECIES HAVE SEX
    //            {
    //                if ((sex == "Male" && collision.gameObject.GetComponent<Animal>().sex == "Female") || (sex == "Female" && collision.gameObject.GetComponent<Animal>().sex == "Male"))
    //                {
    //                    target = collision.gameObject;
    //                    ChangeState(State.GoingToNeed);
    //                }
    //            }
    //        }
    //    }
    //    else if (needIsWater && collision.gameObject.CompareTag("Water"))
    //    {
    //        target = collision.gameObject;
    //        ChangeState(State.GoingToNeed);
    //    }
    //}

    #endregion

    float RandomFloat(float min, float max)
    {
        return Random.Range(min, max);
    }
}
