using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] TMP_Text pressSpace;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text dialogText;
    [SerializeField] GameObject heyButton;
    [SerializeField] Image instructor;
    [SerializeField] AudioClip[] ac;
    AudioSource a;

    public bool isTalking;
    private Queue<string> sentences;

    void Start()
    {
        a = GetComponent<AudioSource>();
        sentences = new Queue<string>();
    }

    private void Update()
    {
        if (isTalking && (Input.GetKeyDown(KeyCode.Space)))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        a.Play();
        instructor.enabled = true;
        pressSpace.gameObject.SetActive(true);
        heyButton.gameObject.SetActive(false);

        isTalking = true;

        Cursor.lockState = CursorLockMode.Locked;

        nameText.text = $"{dialogue.name}:";

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {

        dialogText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            var r = Random.Range(0, ac.Length);
            a.PlayOneShot(ac[r]);
            dialogText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        isTalking = false;
        nameText.enabled = false;
        dialogText.enabled = false;
        pressSpace.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        instructor.enabled = false;
    }

}
