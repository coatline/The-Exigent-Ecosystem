using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnimalVisuals : MonoBehaviour
{
    [SerializeField] GameObject reproductionBarPrefab;
    [SerializeField] GameObject actionTextPrefab;
    [SerializeField] GameObject hungerBarPrefab;
    [SerializeField] GameObject thirstBarPrefab;
    [SerializeField] GameObject gravePrefab;
    GameObject myReproductionBarFill;
    [SerializeField] Canvas canvas;
    GameObject myActionTextObject;
    GameObject myReproductionBar;
    GameObject myHungerBarFill;
    GameObject myThirstBarFill;
    GameObject myHungerBar;
    GameObject myThirstBar;
    TMP_Text myActionText;

    public float X { get; private set; }
    public float Y { get; private set; }

    AnimalStats stats;
    Animal animal;

    public void Setup(Animal animal, AnimalStats stats)
    {
        this.animal = animal;
        this.stats = stats;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    void SetupBars()
    {
        myHungerBar = Instantiate(hungerBarPrefab, transform.position + new Vector3(0, .5f, 0), Quaternion.identity, canvas.transform);
        myHungerBarFill = myHungerBar.transform.GetChild(0).gameObject;

        myThirstBar = Instantiate(thirstBarPrefab, transform.position + new Vector3(0, .75f, 0), Quaternion.identity, canvas.transform);
        myThirstBarFill = myThirstBar.transform.GetChild(0).gameObject;

        myReproductionBar = Instantiate(reproductionBarPrefab, transform.position + new Vector3(0, 1f, 0), Quaternion.identity, canvas.transform);
        myReproductionBarFill = myReproductionBar.transform.GetChild(0).gameObject;
    }

    void DisplayHungerBar()
    {

    }

    void DisplayBars()
    {
        myHungerBarFill.GetComponent<Image>().fillAmount = stats.hunger / 100;
        myHungerBar.transform.position = transform.position + new Vector3(0, .5f, 0);

        myThirstBarFill.GetComponent<Image>().fillAmount = stats.thirst / 100;
        myThirstBar.transform.position = transform.position + new Vector3(0, .75f, 0);

        myReproductionBarFill.GetComponent<Image>().fillAmount = stats.reproductiveUrge / 100;
        myReproductionBar.transform.position = transform.position + new Vector3(0, 1f, 0);
    }

    void DisplayThirstBar()
    {

    }

    void DisplayReproductionBar()
    {

    }

    void UpdateActionTextPosition()
    {
        myActionTextObject.transform.position = transform.position + new Vector3(0, 1.25f, 0);
    }

    void DoBars()
    {
        DisplayHungerBar();
        DisplayThirstBar();
        DisplayReproductionBar();
    }

    void DisplayState()
    {
        //switch (newState)
        //{

        //    case State.GoingToNeed:
        //        myActionText.text = $"Getting {need}";
        //        break;

        //    case State.ConsumingNeed:
        //        myActionText.text = $"Consuming {need}";
        //        break;

        //    case State.Labor:
        //        myActionText.text = "In labor";
        //        break;

        //    case State.Wandering:
        //        myActionText.text = "Wandering";
        //        break;

        //    case State.RunningFromPredator:
        //        myActionText.text = "Running from predator";
        //        break;

        //    case State.SearchingForNeeds:
        //        myActionText.text = $"Searching for {need}";
        //        break;
        //}
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
