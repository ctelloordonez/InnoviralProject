using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPuzzleSceneLv4: MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Submarine")
        {
            SceneManager.LoadScene("puzzleLv4");
            Destroy(gameObject);
             
        }
    }
}
