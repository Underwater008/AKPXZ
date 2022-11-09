using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Scene1Transition : MonoBehaviour
{


    public Vector3 PlayerPosBeforeTransition, PlayerPosBeforeRotation;
    public Transform NewsCamPos;
    public Transform FPSCam;

    public Transform targetCam;

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
            crosshair.instance.CurrentCamera = CarPlayer.transform.GetChild(0).transform;
            HousePlayer.GetComponentInChildren<AudioListener>().enabled = false;
            CarPlayer.GetComponentInChildren<AudioListener>().enabled = true;
            CarPlayer.transform.parent.GetComponent<Animation>().Play();
        });
    }



    public void StartTransitionBack()
    {
        Debug.Log("sad");
        Cursor.visible = false;

        Cursor.lockState = CursorLockMode.Locked;

        FPSCam.DORotate(HousePlayer.transform.GetChild(0).rotation.eulerAngles, 1f).OnComplete(() => {
            crosshair.instance.gameObject.SetActive(true);
        });

        FPSCam.DOMove(HousePlayer.transform.GetChild(0).position, 1f).OnComplete(() => {
            HousePlayer.enabled = true;
            CarPlayer.enabled = false;
            //CarPlayer.transform.GetChild(0).GetComponent<WalkAnim>().enabled = true;
            crosshair.instance.CurrentCamera = HousePlayer.transform.GetChild(0).transform;
            HousePlayer.GetComponentInChildren<AudioListener>().enabled = true;
            CarPlayer.GetComponentInChildren<AudioListener>().enabled = false;
            FPSCam.GetComponent<Camera>().enabled = false;
            HousePlayer.transform.GetChild(0).GetComponent<Camera>().enabled = true;
            HousePlayer.transform.parent.GetComponent<Animation>().Play();
        });
    }

    public void StartDocTransition()
    {

    }


    public void LerpPlayertoDrawer()
    {
        Camera houseCam = HousePlayer.transform.GetChild(0).GetComponent<Camera>();
        PlayerPosBeforeTransition = houseCam.transform.position;
        PlayerPosBeforeRotation = houseCam.transform.rotation.eulerAngles;
        houseCam.GetComponent<Animator>().enabled = false;
        houseCam.GetComponent<WalkAnim>().enabled = false;
        HousePlayer.enabled = false;
        crosshair.instance.gameObject.SetActive(false);
        int temp = LayerMask.NameToLayer("Default");
        this.gameObject.layer = temp;

        houseCam.transform.DORotate(targetCam.rotation.eulerAngles, 1f).OnComplete(() => {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        });

        houseCam.transform.DOMove(targetCam.position, 1f).OnComplete(() => {
        });

    }



    public void LerpPlayerbackDrawer()
    {

        Camera houseCam = HousePlayer.transform.GetChild(0).GetComponent<Camera>();

        int temp = LayerMask.NameToLayer("Default");
        this.gameObject.layer = temp;

        houseCam.transform.DORotate(PlayerPosBeforeRotation, 1f).OnComplete(() => {
        });

        houseCam.transform.DOMove(PlayerPosBeforeTransition, 1f).OnComplete(() => {
            houseCam.GetComponent<Animator>().enabled = true;
            houseCam.GetComponent<WalkAnim>().enabled = true;
            HousePlayer.enabled = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            crosshair.instance.gameObject.SetActive(true);
        });

    }

    public void StartTansitionToDoc()
    {
        Camera houseCam2 = HousePlayer.transform.GetChild(0).GetComponent<Camera>();
        Cursor.visible = false;

        Cursor.lockState = CursorLockMode.Locked;
        houseCam2.transform.DORotate(NewsCamPos.rotation.eulerAngles, 1f).OnComplete(() => {
            crosshair.instance.gameObject.SetActive(true);
        });

        houseCam2.transform.DOMove(NewsCamPos.position, 1f).OnComplete(() => {
            HousePlayer.enabled = false;
            //DoctorPlayer.enabled = true;
            DoctorPlayer.GetComponent<Animation>().Play();
            //DoctorPlayer.transform.GetChild(0).GetComponent<WalkAnim>().enabled = true;
            crosshair.instance.CurrentCamera = DoctorPlayer.transform.GetChild(0).transform;
            HousePlayer.GetComponentInChildren<AudioListener>().enabled = false;
            DoctorPlayer.GetComponentInChildren<AudioListener>().enabled = true;
            //DoctorPlayer.transform.parent.GetComponent<Animation>().Play();
        });
    }


}
