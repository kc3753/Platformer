using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    public GameObject platform;
    public float currTime = 0;
    public bool enable = true;
    public float timeToDisappear;
    void Start() {
        timeToDisappear = 4f + Random.Range(-1.0f,1.0f);
    }
    
    void Update()
    {
        currTime += Time.deltaTime;
        if(enable){
            if(currTime >= timeToDisappear){
              platform.SetActive(false); 
              enable = false; 
              currTime = 0;
            }
        }
        if(!enable){
            if(currTime >= 1){
                platform.SetActive(true); 
                enable = true; 
                currTime = 0;
            }
        }
    }
}
