using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz2 : MonoBehaviour
{
    Well well;
    Fire fire;
    Spike spike;
    private bool q=false, stopgame=true;
    private int quizNum = 0;
    private int score = 0;
    private int whatbtn = 0;
    Quiz quiz;
    public Text scoretxt;

	// Use this for initialization
	void Start ()
    {
        quiz = GameObject.Find("GameUI").GetComponent<Quiz>();
        well = GameObject.Find("dudu").GetComponent<Well>();
        fire = GameObject.Find("new fire").GetComponent<Fire>();
        spike = GameObject.Find("spike").GetComponent<Spike>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        whatbtn = quiz.GetpushBtn();
	}

    public void VisibleQuiz(int a)
    {
        q = true;
        quizNum=a;
    }

    public bool StopTheGame()
    {
        return stopgame;
    }

    public int WhatScore()
    {
        return score;
    }

    public void OnGUI()
    {
        if (q)
        {
            GUILayout.BeginArea(new Rect(0, 50, Screen.width, Screen.height));
            if (quizNum == 1)
            {
                GUILayout.TextArea("面 다음 한자의 뜻과 음은 무엇인가\n a. 나라 국 b. 낯 면");
                stopgame = false;
                if (Input.GetKeyDown(KeyCode.A) || whatbtn==3)
                {
                    q = false;
                    score -= 50;
                    stopgame = true;
                    well.GetWellCatch(2);
                }
                else if (Input.GetKeyDown(KeyCode.B) || whatbtn==5)
                {
                    q = false;
                    score += 100;
                    stopgame = true;
                    well.GetWellCatch(1);
                }
            }
            else if (quizNum == 2)
            {
                GUILayout.TextArea("後 다음 한자의 반대되는 한자는 무엇인가\n a. 前 b. 答");
                stopgame = false;
                if (Input.GetKeyDown(KeyCode.A) || whatbtn==3)
                {
                    q = false;
                    score += 100;
                    stopgame = true;
                    fire.GetFireCatch(1);
                }
                else if (Input.GetKeyDown(KeyCode.B) || whatbtn==5)
                {
                    q = false;
                    score -= 50;
                    stopgame = true;
                    fire.GetFireCatch(2);
                }
            }
            else if (quizNum == 3)
            {
                GUILayout.TextArea("中心 다음 한자어의 독음은 무엇인가\n a. 세상 b. 중심");
                stopgame = false;
                if (Input.GetKeyDown(KeyCode.A) || whatbtn==3)
                {
                    q = false;
                    score -= 50;
                    stopgame = true;
                    spike.GetSpikeCatch(2);
                }
                else if (Input.GetKeyDown(KeyCode.B) || whatbtn==5)
                {
                    q = false;
                    score += 100;
                    stopgame = true;
                    spike.GetSpikeCatch(1);
                }
            }
            scoretxt.text =  "score <color=#ffff00>"+score.ToString()+"</color>";
            GUILayout.EndArea();
        }
        else
        {
            GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
            GUILayout.EndArea();
        }
    }

}
