using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Scene1Transition : MonoBehaviour
{
    //bool keeping track of whether is triggered.
    public bool triggered = false;
    public bool played = false;
    public bool enable = false;
    public bool miniEnable = false;

    public View playerView;
    public View miniView;

    public Transform NewsCamPos;
    public Transform FPSCam;

    void Start()
    {

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
            Debug.Log("????");
            //playerView.enabled = false;
            //miniView.enabled = true;

            FPSCam.DOMove(NewsCamPos.position, 1f);

            playerView.isActive = false;
            miniView.isActive = true;


            played = true;
            enable = false;
            //returnView = playerView;
        }
        //starts main player control, and pauses minigame player control.
        else if (played && (!miniView.trigger.triggered || miniView.trigger.played) && miniView.isActive)
        {
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
