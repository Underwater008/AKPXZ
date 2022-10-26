using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1Transition : MonoBehaviour
{
    //bool keeping track of whether is triggered.
    public bool triggered = false;
    public bool played = false;
    public bool enable = false;
    public bool miniEnable = false;

    public View playerView;
    public View miniView;

    Transform playerCamera;
    Transform targetCamera;
    Transform returnCamera;
    public float timer = 0;

    void Start()
    {
        //sets the camera return posiiton.
        playerCamera = playerView.gameObject.transform.Find("Camera");
        returnCamera = playerView.gameObject.transform.Find("ReturnCam");
        targetCamera = gameObject.transform.Find("Camera");
        returnCamera.transform.position = playerCamera.transform.position;
    }

    void Update()
    {

    }

    public void StartTansition()
    {
        Cursor.visible = false;

        Cursor.lockState = CursorLockMode.Locked;

        Debug.Log("Clicked");

        if (!played)
        {
            timer = 0;
            Debug.Log("????");
            //playerView.enabled = false;
            //miniView.enabled = true;
            playerView.isActive = false;
            miniView.isActive = true;
            played = true;
            enable = false;
            //returnView = playerView;
        }
        //starts main player control, and pauses minigame player control.
        else if (played && (!miniView.trigger.triggered || miniView.trigger.played) && miniView.isActive)
        {
            timer = 0;
            //playerView.enabled = true;
            //miniView.enabled = false;
            //playerView.isActive = true;
            miniView.isActive = false;
            played = false;
            enable = true;
            //targetCamera.transform.rotation = playerCamera.transform.rotation;
        }

    }
}
