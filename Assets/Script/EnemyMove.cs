using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour
{
    void Start()
    {
        iTween.MoveBy(gameObject, iTween.Hash("y", 3.5, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", 0.5));
    }
}


