using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]

public class Dialogue
{
    public string name;
    TMP_Text text;
    [TextArea(3, 10)]
    public string[] sentences;
}
