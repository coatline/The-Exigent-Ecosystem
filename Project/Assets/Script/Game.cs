using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] GameObject LoseUI;

    [SerializeField] TMP_Text populationText;
    [SerializeField] TMP_Text haveToGiveText;

    [SerializeField] AudioClip plopClip;
    [SerializeField] Image plantFill;
    [SerializeField] Image bunnyFill;
    [SerializeField] Image foxFill;
    [SerializeField] Image bearFill;

    Dictionary<OrganismType, int> populations;
    Dictionary<OrganismType, GameObject> ui;
    Dictionary<OrganismType, int> inventory;
    Dictionary<OrganismType, float> timers;
    [SerializeField] bool inMenu;

    OrganismType currentThing;
    AudioSource audioSource;

    void Awake()
    {
        if (!inMenu)
        {
            audioSource = GetComponent<AudioSource>();
        }

        currentThing = DataLibrary.I.GetOrganism("Plant");

        timers = new Dictionary<OrganismType, float>();
        populations = new Dictionary<OrganismType, int>();
        ui = new Dictionary<OrganismType, GameObject>();
        inventory = new Dictionary<OrganismType, int>();


        for (int i = 0; i < DataLibrary.I.organisms.Length; i++)
        {
            OrganismType organism = DataLibrary.I.organisms[i];
            timers.Add(organism, organism.regenerateRate);
            populations.Add(organism, 0);
            inventory.Add(organism, 0);
        }

        UpdateToGiveText();
    }

    IEnumerator Timer(OrganismType type, float time)
    {
        yield return new WaitForSeconds(time);

        EditInventory(1, type);

        StartCoroutine(Timer(type, type.regenerateRate));
    }

    private void Update()
    {
        if (inMenu) { return; }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(2);
        }

        if (lost) { return; }
        Inputs();
        GenerateNewThings();
    }

    bool lost;

    void GenerateNewThings()
    {
        for (int i = 0; i < DataLibrary.I.organisms.Length; i++)
        {
            OrganismType organism = DataLibrary.I.organisms[i];
            timers[organism] += Time.deltaTime;
        }

        //plantFill.fillAmount = plantTimer / 5;
        //bunnyFill.fillAmount = bunnyTimer / 10;
        //foxFill.fillAmount = foxTimer / 20;
        //bearFill.fillAmount = bearTimer / 30;
    }

    void Inputs()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            currentThing = DataLibrary.I.GetOrganism("Plant");
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            currentThing = DataLibrary.I.GetOrganism("Bunny");
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            currentThing = DataLibrary.I.GetOrganism("Fox");
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            currentThing = DataLibrary.I.GetOrganism("Bear");
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (inventory[currentThing] > 0)
            {
                PlaceObject(currentThing);
            }
        }
    }

    void PlaceObject(OrganismType type)
    {
        if (inMenu) { return; }

        //var no = Instantiate(type.prefab, Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10), Quaternion.identity, this.transform);
        //CheckForOverlaps(obj);
    }

    bool CanPlaceThere()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.forward, Mathf.Infinity);

        if (hit)
        {
            return true;
        }

        return false;
    }

    //void CheckForOverlaps(GameObject objec)
    //{
    //    ContactFilter2D contactFilter = new ContactFilter2D();
    //    Collider2D[] colliders = new Collider2D[10];

    //    contactFilter.useLayerMask = true;
    //    contactFilter.layerMask = LayerMask.GetMask("Water", "Border");

    //    int colliderCount = objec.GetComponent<CapsuleCollider2D>().OverlapCollider(contactFilter, colliders);

    //    if (colliderCount > 0)
    //    {
    //        if (objec.tag == "Bunny" || objec.tag == "Fox" || objec.tag == "Bear")
    //        {
    //            objec.GetComponent<Animal>().Die(false);
    //        }
    //        else
    //        {
    //            Destroy(objec);
    //        }
    //    }
    //    else
    //    {
    //        if (objec.tag == "Plant")
    //        {
    //            AddOrSubPop(objec.tag, 1);
    //        }

    //        EditCount(-1, false);

    //        UpdatePopulationText();

    //        audioSource.PlayOneShot(plopClip);
    //    }
    //}

    void EditInventory(int amount, OrganismType type)
    {
        populations[type] += amount;
        UpdateToGiveText();
    }

    void UpdateToGiveText()
    {
        if (inMenu) { return; }

        string t = "";

        for (int i = 0; i < inventory.Count; i++)
        {
            t += $"<color=red>You Have:</color>\n<color=blue>{DataLibrary.I.organisms[i].name}:</color> <color=purple>{inventory[DataLibrary.I.organisms[i]]}</color>\n";
            //$"<color=red>You Have:</color>\n<color=blue>Plant:</color> <color=purple>{plantCount}</color>\n<color=blue>Bunny:</color> <color=purple>{bunnyCount}</color>\n<color=blue>Fox:</color> <color=purple>{foxCount}</color>\n<color=blue>Bear:</color> <color=purple>{bearCount}</color>\n";
        }

        haveToGiveText.text = t;
    }

    void UpdatePopulationText()
    {
        if (inMenu) { return; }

        string t = "";

        for (int i = 0; i < inventory.Count; i++)
        {
            t += $"<color=red>You Have:</color>\n<color=blue>{DataLibrary.I.organisms[i].name}:</color> <color=purple>{populations[DataLibrary.I.organisms[i]]}</color>\n";
        }

        haveToGiveText.text = t;
    }

    public void AddOrSubPop(OrganismType type, int amount)
    {
        if (inMenu) { return; }

        populations[type] += amount;

        UpdatePopulationText();
    }
}
