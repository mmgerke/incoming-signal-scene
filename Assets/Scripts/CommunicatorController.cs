using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommunicatorController : MonoBehaviour
{
    public GameObject reel1;
    public GameObject reel2;
    public bool power_on;


    // Start is called before the first frame update
    void Start()
    {
        reel1.GetComponent<Rotate>().enabled = false;
        reel2.GetComponent<Rotate>().enabled = false;
        power_on = false;
    }

    void OnMouseDown(){
        Debug.Log("Communicator power triggered");
        reel1.GetComponent<Rotate>().enabled = true;
        reel2.GetComponent<Rotate>().enabled = true;
        power_on = true;
    }

}
