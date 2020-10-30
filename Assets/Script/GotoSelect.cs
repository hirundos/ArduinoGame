using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoSelect : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
    }

    public void OnButtonSelect()
    {
        SceneManager.LoadScene("SelectStage");
    }
    public void OnButtonMap1()
    {
        SceneManager.LoadScene("Search");
    }
    public void OnButtonMap2()
    {
        SceneManager.LoadScene("Search2");
    }
}
