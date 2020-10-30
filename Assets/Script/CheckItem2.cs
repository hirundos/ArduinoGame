using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CheckItem2 : MonoBehaviour
{

    public Text txtNum;
    private Quiz2 quiz;
  
    private int itemNum = 3;

    private void Start()
    {
        quiz = GameObject.Find("GameUI").GetComponent<Quiz2>();
    }
    private void Update()
    {
        /*
        if (itemNum == 0&&quiz.StopTheGame())
        {
            SceneManager.LoadScene("ClearScene");
        }
        */
    }

    public int ItemNumers()
    { return itemNum; }

    public void DisItem()
    {
        itemNum--;
        txtNum.text = "남은 아이템 <color=#ff0000>" + itemNum.ToString() + "</color>" ;
    } 

}
