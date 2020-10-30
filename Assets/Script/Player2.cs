using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Player2 : MonoBehaviour
{

    public float moveSpeed = 5.0f;
    private Quiz2 quiz2;
    private Quiz quiz;
    int whatbtn = 0;
    private SpriteRenderer spriterenderder;
    float v=0,h=0;
    SerialPort sp = new SerialPort("COM7", 9600);


    // Use this for initialization
    void Start ()
    {
        quiz = GameObject.Find("GameUI").GetComponent<Quiz>();
        quiz2 = GameObject.Find("GameUI").GetComponent<Quiz2>();
        spriterenderder = gameObject.GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        MoveControl();
        whatbtn = quiz.GetpushBtn();
    }

    void MoveControl()
    {
        if (quiz2.StopTheGame())
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");

            //푸쉬버튼 입력
            if (whatbtn == 1)
                h = -0.5f;
            else if (whatbtn == 2)
                v = 0.5f;
            else if (whatbtn == 3)
                v = -0.5f;
            else if (whatbtn == 4)
                h = 0.5f;

            //애니메이션 좌우회전
            if (h < 0)
                spriterenderder.flipX = true;
            else
                spriterenderder.flipX = false;

            float distanceX = h * Time.deltaTime * moveSpeed;
            float distanceY = v * moveSpeed * Time.deltaTime;
            this.gameObject.transform.Translate(distanceX, distanceY, 0);
        }
    }

}
