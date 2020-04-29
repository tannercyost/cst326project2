using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI scoreText;

    public float countdown;
    private int score = 0;
    
    public void addScore (int score)
    {
        this.score += score;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        timeText.SetText("TIME \n" + (int) countdown);
        scoreText.SetText("C:x0" + score);
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
                    score++;
                }
                Destroy(obj);
            }
        }
    }
}
