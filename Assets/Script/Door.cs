using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

    Animator anim;
    Quiz quiz;
    CheckItem checkitem;
    int score = 0;
    string hint = "";
    bool finalquiz = false, DoorOpen=false;
    string textFieldString="";
   

    // Use this for initialization
    void Start()
    {
        quiz = GameObject.Find("GameUI").GetComponent<Quiz>();
        checkitem = GameObject.Find("GameUI").GetComponent<CheckItem>();
        anim = gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    { }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (checkitem.ItemNumers() == 0)
        {
            if (col.CompareTag("Player"))
            {
                score = quiz.WhatScore();
                if (score >= 200)
                { hint = "鳥一二石"; }
                else if (score >= 100)
                { hint = "石鳥"; }
                finalquiz = true;
            }
        }
        else
        {
            DoorOpen = true;
        }

    }

    private void DoorClear()
    {
        SceneManager.LoadScene("ClearScene");
    }

    private void DoorBox()
    {
        DoorOpen = false;
    }

    public void OnGUI()
    {
        if (DoorOpen)//조건을 충족하지 않고 문을 열 때
        {
            GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
            GUILayout.TextArea("모든 아이템을 습득하여야 문이 열립니다.");
            Invoke("DoorBox", 2);
            GUILayout.EndArea();
        }

        if (finalquiz)//문을 열기전 문제
        {
            GUILayout.BeginArea(new Rect(0, 50, Screen.width, Screen.height));
            GUILayout.TextArea("하나의 돌로 두마리의 참새를 잡는다.\n"+hint);
            textFieldString = GUI.TextField(new Rect(0, 50, 100, 55), textFieldString);
            if (textFieldString == "일석이조" || textFieldString == "一石二鳥")//답을 맞춘경우
            {
                anim.SetBool("OpenDoor", true);
                Invoke("DoorClear", 2);
           
            }
            Debug.Log(textFieldString);
            GUILayout.EndArea();
        }
        else
        {
            GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
            GUILayout.EndArea();
        }
    }
}
