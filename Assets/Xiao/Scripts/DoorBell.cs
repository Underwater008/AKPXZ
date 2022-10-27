using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorBell : MonoBehaviour
{
    private SimplePlayerController simplePlayerController;

    public Transform FPSCam;

    public Transform SofaCam;

    public static DoorBell instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        simplePlayerController = GameObject.FindGameObjectWithTag("Player").GetComponent<SimplePlayerController>();
        simplePlayerController.canMove = false;

        SofaCam.GetComponent<Camera>().depth = 1;
        FPSCam.GetComponent<Camera>().depth = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            StandUp();
        }
    }

    //Move Camera and switch to FPS Cam
    public void StandUp()
    {
        SofaCam.DORotate(FPSCam.rotation.eulerAngles, 1f).OnComplete(() => {
        }
);
        SofaCam.DOMove(FPSCam.position, 1f).OnComplete(() => {

            simplePlayerController.canMove = true;
            SofaCam.GetComponent<Camera>().depth = 0;
            FPSCam.GetComponent<Camera>().depth = 1;
        }
            ); 

        //SofaCam.DORotate(new Vector3(-15, 90, SofaCam.rotation.z), 0.5f).OnComplete(() =>

        //    SofaCam.DORotate(new Vector3(0, 90, SofaCam.rotation.z), 0.5f).OnComplete(() => {

        //        simplePlayerController.canMove = true;
        //        SofaCam.GetComponent<Camera>().depth = 0;
        //        FPSCam.GetComponent<Camera>().depth = 1;
        //    }
        //    )
        //);;
    }
}
