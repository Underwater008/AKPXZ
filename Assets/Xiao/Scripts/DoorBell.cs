using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorBell : MonoBehaviour
{
    private SimplePlayerController simplePlayerController;

    public Transform FPSCam;

    public Transform SofaCam;

    // Start is called before the first frame update
    void Start()
    {
        simplePlayerController = GameObject.FindGameObjectWithTag("Player").GetComponent<SimplePlayerController>();
        simplePlayerController.canMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            StandUp();
            Debug.Log("C pressed to stand up");
        }
    }

    //Move Camera and switch to FPS Cam
    public void StandUp()
    {
        SofaCam.DOMove(FPSCam.position, 1f);

        SofaCam.DORotate(new Vector3(-15, 90, SofaCam.rotation.z), 0.5f).OnComplete(() =>

            SofaCam.DORotate(new Vector3(0, 90, SofaCam.rotation.z), 0.5f).OnComplete(() => {

                simplePlayerController.canMove = true;
                FPSCam.GetComponent<Camera>().depth = Camera.main.depth + 1;
            }
            )
        );;
    }
}
