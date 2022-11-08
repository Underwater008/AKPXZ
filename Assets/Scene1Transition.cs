using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Scene1Transition : MonoBehaviour
{



    public Transform NewsCamPos;
    public Transform FPSCam;

    public SimplePlayerController HousePlayer, CarPlayer, DoctorPlayer;
    public void StartTansitionToCar()
    {
        Cursor.visible = false;

        Cursor.lockState = CursorLockMode.Locked;
        FPSCam.DORotate(NewsCamPos.rotation.eulerAngles, 1f).OnComplete(() => {
            crosshair.instance.gameObject.SetActive(true);
        });

        FPSCam.DOMove(NewsCamPos.position, 1f).OnComplete(() => {
            HousePlayer.enabled = false;
            CarPlayer.enabled = true;
            CarPlayer.transform.GetChild(0).GetComponent<WalkAnim>().enabled = true;
            });
    }
}
