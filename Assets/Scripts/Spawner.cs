using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obj;

    bool isClicked;
    Vector2 spawner;
    public void TaskOnClick() 
    {
        isClicked = true;
    }
    void Update() {
        if (isClicked)
        {

            spawner = new Vector2(transform.position.x, transform.position.y);
            GameObject Enemy = Instantiate(obj, spawner, Quaternion.identity);
            isClicked = false;
            
        }
    }
}
