using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO.Ports;

public class Player_Battle : MonoBehaviour
{
    public const float moveSpeed = 5.0f;
    public GameObject explosionPrefab;
    public int maxhealthPoint;
    public GameObject laserPrefab; 
    public bool canShoot = true; 
    const float shootDelay = 0.5f; 
    float shootTimer = 0; 
    float push_x, push_y;
    SerialPort sp = new SerialPort("COM4", 9600); 
    int[] val = new int[5];
    int[] angle = new int[2];

    // Use this for initialization
    void Awake()
    {
        maxhealthPoint = 10;
    }
    void Start ()
    {
        sp.Open();  //Serial port open
        sp.ReadTimeout = 15;  //set Serial timeout
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (sp.IsOpen)
        {
            Debug.Log("open");

            try
            {
                sp.Write("s");  //send start data
                val[0] = sp.ReadByte();  //read a byte
                if (val[0] == 0xff)
                {  //check start byte
                    for (int i = 1; i < 5; i++)
                    {
                        val[i] = sp.ReadByte();
                    }

                    angle[0] = val[1] * (val[2] - 2);  //calculate value
                    angle[1] = val[3] * (val[4] - 2);

                    Debug.Log(angle[0]);
                    Debug.Log(angle[1]);

                    if (angle[0] > 0)
                        push_x = 0.1f;
                    else
                        push_x = -0.1f;

                    if (angle[1] > 0)
                        push_y = 0.1f;
                    else
                        push_y = -0.1f;

                }
            }
            catch (System.Exception) { }
        }
        MoveControl();
        ShootControl();
	}

    void MoveControl()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position); 
        viewPos.x = Mathf.Clamp01(viewPos.x); 
        viewPos.y = Mathf.Clamp01(viewPos.y);
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos); 
        transform.position = worldPos; 
        float distanceX = push_x * Time.deltaTime * moveSpeed;
        float distanceY = push_y * Time.deltaTime * moveSpeed;
        this.gameObject.transform.Translate(distanceX, distanceY, 0);
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
                Instantiate(explosionPrefab,
                this.transform.position,
                Quaternion.identity);
                Destroy(other.gameObject);
                Destroy(this.gameObject);
            SceneManager.LoadScene("Gameover");

        }
    }
    void ShootControl() // 발사를 관리하는 함수 입니다.
    {
        if (canShoot)
        {
            if (shootTimer > shootDelay && Input.GetKey(KeyCode.Space)) //쿨타임이 지났는지와, 공격키인 스페이스가 눌려있는지 검사합니다.
            {
                Instantiate(laserPrefab, transform.position, Quaternion.identity); //레이저를 생성해줍니다.
                SoundManager.instance.PlaySound();
                shootTimer = 0; //쿨타임을 다시 카운트 합니다.
            }
            shootTimer += Time.deltaTime; //쿨타임을 카운트 합니다.
        }
    }
}
