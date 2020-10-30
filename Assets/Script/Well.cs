using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Well : MonoBehaviour {

    Quiz quiz;
    Quiz2 quiz2;
    Animator anim;
    Player p;
    bool bIsCatch = false;
    int pCatch = 0;
    bool thr=false;
    // Use this for initialization
    void Start()
    {
        quiz = GameObject.Find("GameUI").GetComponent<Quiz>();
        quiz2 = GameObject.Find("GameUI").GetComponent<Quiz2>();
        anim = gameObject.GetComponentInChildren<Animator>();
        p = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bIsCatch)
        {
            anim.SetBool("break", true);
            
        }
        else
        {
            anim.SetBool("break", false);
        }

        if (pCatch == 1)//맞춤
        {
            Destroy(gameObject, 2);
            bIsCatch = true;
        }
    }

    public void GetWellCatch(int a)
    {
        pCatch = a;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            quiz.VisibleQuiz(1);
            //gameObject.SetActive(false);
            //   checkitem.DisItem();
        }
        else if (col.CompareTag("Player2"))
        {
            quiz2.VisibleQuiz(1);
        }
    }
}


