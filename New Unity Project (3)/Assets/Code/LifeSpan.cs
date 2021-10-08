using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSpan : MonoBehaviour
{
    public int lifeSeconds = 2;
    void Start()
    {
        Destroy(GameObject, LifeSeconds);
    }
}
