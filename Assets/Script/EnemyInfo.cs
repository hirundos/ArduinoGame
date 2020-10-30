using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyInfo : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RestartGame()
    {
        SceneManager.LoadScene("BattleMode");
    }
    public void RestartGame2()
    {
        SceneManager.LoadScene("BattleMode2");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            SceneManager.LoadScene("BattleMode");
        }
        else if (col.CompareTag("Player2"))
        {
            SceneManager.LoadScene("BattleMode2");
        }
    }
}