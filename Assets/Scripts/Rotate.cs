using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    //private GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        //obj = GameObject.getComponent<>
    }

    // Update is called once per frame
    void Update()
    {
         this.transform.Rotate(0, 2f, 0, Space.Self);
    }
}
