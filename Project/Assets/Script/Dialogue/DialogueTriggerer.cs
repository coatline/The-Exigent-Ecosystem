using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerer : MonoBehaviour
{
    public Dialogue dialogue;

    void Start()
    {
        if(gameObject.tag == "NPC")
        {
            GetComponentInChildren<TextMesh>().text = dialogue.name;
        }
    }

    public void TriggerDialogue()
    {
        //singleton
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
