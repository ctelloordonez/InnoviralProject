using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerLevel2 : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManagerLevel2>().StartDialogue(dialogue);
    }
}
