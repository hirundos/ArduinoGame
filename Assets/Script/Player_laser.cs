using UnityEngine;
using System.Collections;
using System;

public class Player_laser : MonoBehaviour
{
    //public GameObject ParticleFXExplosion;
    private const float moveSpeed = 2.5f;
   
    void Start()
    {
    }
    void Update()
    {
        float moveY = moveSpeed * Time.deltaTime;
        transform.Translate(0, moveY, 0);
    }
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
    
}
