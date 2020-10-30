using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{

    private CheckItem checkitem;
    private CheckItem2 checkitem2;
    private Quiz quiz;
    private Quiz2 quiz2;

    void Start()
    {
        checkitem = GameObject.Find("GameUI").GetComponent<CheckItem>();
        checkitem2 = GameObject.Find("GameUI").GetComponent<CheckItem2>();
        quiz = GameObject.Find("GameUI").GetComponent<Quiz>();
        quiz2 = GameObject.Find("GameUI").GetComponent<Quiz2>();
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            gameObject.SetActive(false);
    //        quiz.VisibleQuiz();
            checkitem.DisItem();
        }
        else if (col.CompareTag("Player2"))
        {
            gameObject.SetActive(false);
          //  quiz2.VisibleQuiz();
            checkitem2.DisItem();
        }
    }
}
