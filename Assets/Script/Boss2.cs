using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss2 : MonoBehaviour
{
    public int maxHealtPoint;
    public GameObject ParticleFXExplosion;
    // Use this for initialization
    void Awake()
    {
        maxHealtPoint = 11;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("laser"))
        {
            if (maxHealtPoint > 1)
            {
                maxHealtPoint--;
                Destroy(other.gameObject);
                Instantiate(ParticleFXExplosion, other.transform.position, Quaternion.identity);
            }
            else if (maxHealtPoint == 1)
            {
                Destroy(other.gameObject);
                Destroy(this.gameObject);
                Instantiate(ParticleFXExplosion, this.transform.position, Quaternion.identity);
                SceneManager.LoadScene("Search2");
            }
        }
    }
}

