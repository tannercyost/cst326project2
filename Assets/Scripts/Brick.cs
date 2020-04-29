using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private GameObject gm;
    private GameplayManager gmS;

    private void Start()
    {
        gm = GameObject.Find("GameManager");
        gmS = gm.GetComponent<GameplayManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.CompareTag("QuestionBox"))
        {
            gmS.addCoin();
        }
        else
        {
            gmS.addScore(100);
        }
        Destroy(gameObject);
    }
}
