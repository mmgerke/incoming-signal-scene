using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{

    Light light;
    public int blink_int;
    float nextSwitch = 0;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
    }

    void Update() {
        if(Time.time > nextSwitch){
            light.enabled = !light.enabled;
            nextSwitch += blink_int;
        }
    }
}
