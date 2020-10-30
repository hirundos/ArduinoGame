using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door2 : MonoBehaviour {

    Animator anim;
    Quiz2 quiz2;
    CheckItem2 checkitem2;
    int score = 0;
    string hint = "";
    bool finalquiz = false, DoorOpen = false;
    string textFieldString = "";


    // Use this for initialization
    void Start()
    {
        quiz2 = GameObject.Find("GameUI").GetComponent<Quiz2>();
        checkitem2 = GameObject.Find("GameUI").GetComponent<CheckItem2>();
        anim = gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    { }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (checkitem2.ItemNumers() == 0)
        {
            if (col.CompareTag("Player2"))
            {
                score = quiz2.WhatScore();
                if (score >= 300)
                { hint = "文友房四"; }
                else if (score >= 200)
                { hint = "房四"; }
                else if (score >= 100)
                    hint = "文";
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
            GUILayout.TextArea("서재에 꼭 있어야 할 네 벗, 즉 종이, 붓, 벼루, 먹을 말함 .\n" + hint);
            textFieldString = GUI.TextField(new Rect(0, 50, 100, 55), textFieldString);
            if (textFieldString == "문방사우" || textFieldString == "文房四友")//답을 맞춘경우
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
