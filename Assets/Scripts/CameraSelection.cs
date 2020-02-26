using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSelection : MonoBehaviour
{
    public Camera maincamera;
    public Camera screencam;

    // Start is called before the first frame update
    void Start()
    {
        maincamera.enabled = true;
        screencam.enabled = false;
    }

    void OnMouseDown() {
        maincamera.enabled = false;
        screencam.enabled = true;
        Debug.Log("Screencam selected\n");
    }

    void Update() {
        if (Input.GetKeyDown("escape") && maincamera.enabled == true) {
            Application.Quit();
        } else if (Input.GetKeyDown("escape")) {
            maincamera.enabled = true;
            screencam.enabled = false;
            Debug.Log("Exited Screencam\n");
        }
    }
}
