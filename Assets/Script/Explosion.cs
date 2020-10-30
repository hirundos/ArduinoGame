using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 0.8f);
    }
    void Update()
    {

    }
}
