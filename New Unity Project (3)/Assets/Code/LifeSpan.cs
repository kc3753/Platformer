using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LifeSpan : MonoBehaviour
{
    public int lifeSeconds = 2;
    void Start()
    {
        Destroy(gameObject, lifeSeconds);
    }
}
