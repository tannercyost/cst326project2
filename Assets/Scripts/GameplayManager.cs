using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI scoreText;


    public float countdown;
    private int score = 0;
    private int coins = 0;
    
    public void addScore (int score)
    {
        this.score += score;
        scoreText.SetText("MARIO\n000" + this.score);
        Debug.Log("score added: " + score);
    }

    public void addCoin()
    {
        coins++;
        addScore(100);
        coinText.SetText("C:x0" + coins);
        Debug.Log("coin added: " + coins);
    }

    private void Awake()
    {
        coinText.SetText("C:x0" + coins);
        scoreText.SetText("MARIO\n00000" + score);
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        timeText.SetText("TIME \n" + (int) countdown);
        if (countdown <= 0)
        {
            Debug.Log("You ran out of time!");
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                GameObject obj = objectHit.gameObject;

                if (obj.name == "QuestionBox(Clone)")
                {
                    addCoin();
                }
                Destroy(obj);
            }
        }
    }
}
