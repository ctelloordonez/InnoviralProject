using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level4Manager : MonoBehaviour
{
    private int pieces;
    public GameObject door;

    public GameObject collectedOnePiece;
    public GameObject collectedBothPieces;

    private void Start()
    {
        collectedOnePiece.SetActive(false);
        collectedBothPieces.SetActive(false);
    }

    public void CollectPiece()
    {
        pieces++;
        if(pieces == 2)
        {
            collectedBothPieces.SetActive(true);
            collectedOnePiece.SetActive(false);
            Destroy(collectedBothPieces, 3f);
            Destroy(door);
        }
        else if(pieces == 1)
        {
            collectedOnePiece.SetActive(true);
        }
    }
   
}
