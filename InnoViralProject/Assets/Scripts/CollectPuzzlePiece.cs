using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPuzzlePiece : MonoBehaviour
{
   public level4Manager manager;
  // public GameObject puzzleText;

        /*
    private void Start()
    {
        puzzleText.SetActive(false);
    }

    */


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Submarine")
        {
            manager.CollectPiece();
            Destroy(gameObject);
        }
    }
}
