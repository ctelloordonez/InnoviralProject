using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBoxTriggerLv2 : MonoBehaviour
{
    DialogueTriggerLevel2 m_DialogueTrigger;

    // Start is called before the first frame update
    void Start()
    {
        m_DialogueTrigger = GetComponent<DialogueTriggerLevel2>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Submarine")
        {
            m_DialogueTrigger.TriggerDialogue();
            Destroy(gameObject);
        }
    }

}
