using UnityEngine;
using System.Collections;

public class Enemy_BattleMode : MonoBehaviour
{
    public const float moveSpeed = 1.3f;
    public GameObject ParticleFXExplosion;

    void Start()
    {

    }
    void Update()
    {
        MoveControl();
    }
    void MoveControl()
    {
        float distanceY = moveSpeed * Time.deltaTime;
        this.gameObject.transform.Translate(0, -1 * distanceY, 0);
    }
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);    
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("laser")||other.tag.Equals("Player"))
        { 
            Destroy(other.gameObject); 
            Destroy(this.gameObject); 
            Instantiate(ParticleFXExplosion, this.transform.position, Quaternion.identity); 
        }
    }
}