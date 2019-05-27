using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBoxTrigger : MonoBehaviour
{
    DialogueTrigger m_DialogueTrigger;

    // Start is called before the first frame update
    void Start()
    {
        m_DialogueTrigger = GetComponent<DialogueTrigger>();
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
