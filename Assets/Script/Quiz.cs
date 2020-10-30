using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;

public class Quiz : MonoBehaviour
{
    Well well;
    Fire fire;
    private bool q = false, stopgame = true;
    private int quizNum = 0;
    private int score = 0;

    public Text scoretxt;

    int whatbtn = 0;
    SerialPort sp = new SerialPort("COM4", 9600);

    // Use this for initialization
    void Start()
    {
        well = GameObject.Find("dudu").GetComponent<Well>();
        fire = GameObject.Find("new fire").GetComponent<Fire>();
                sp.Open();
                sp.ReadTimeout = 1;
    }

    // Update is called once per frame
    void Update()
    {
            GetpushBtn();
        
    }

    public int GetpushBtn()
    {
        if (sp.IsOpen)
        {
            try
            {
                whatbtn = sp.ReadByte();
                Debug.Log(whatbtn);
                print(sp.ReadByte());
            }
            catch (System.Exception)
            { }
        }
        else
            whatbtn = 0;
        return whatbtn;
    }
    

    public void VisibleQuiz(int a)
    {
        q = true;
        quizNum = a;
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
                GUILayout.TextArea("우물 몬스터가 나타났다! 물리치려면 어떤 한자를 써야할까?\n a. 土 b. 水");
                stopgame = false;
                
                if (Input.GetKeyDown(KeyCode.A) || whatbtn == 3)
                {
                    q = false;
                    score += 100;
                    stopgame = true;
                    well.GetWellCatch(1);
                   
                }
                else if (Input.GetKeyDown(KeyCode.B) || whatbtn == 5)
                {
                    q = false;
                    score -= 50;
                    stopgame = true;
                    well.GetWellCatch(2);
                 
                }
            }
            else if (quizNum == 2)
            {
                GUILayout.TextArea("앞에 불무더기가 있다! 어떤 한자를 써서 지나가야 할까?\n a. 油 b. 消");
                stopgame = false;
              
                if (Input.GetKeyDown(KeyCode.A) || whatbtn == 3)
                {
                    q = false;
                    score -= 50;
                    stopgame = true;
                    fire.GetFireCatch(2);
                 
                }
                else if (Input.GetKeyDown(KeyCode.B) || whatbtn == 5)
                {
                    q = false;
                    score += 100;
                    fire.GetFireCatch(1);
    
                    stopgame = true;
                }
            }
            scoretxt.text = "score <color=#ffff00>" + score.ToString() + "</color>";
            GUILayout.EndArea();
        }
        else
        {
            GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
            GUILayout.EndArea();
        }
    }

}
