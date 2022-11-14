using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ending : MonoBehaviour
{
    public Camera MainCam, MomCam;
    private void Start()
    {

        //Vector3 camPos = MomCam.transform.position;
        //Vector3 camAngle = MomCam.transform.rota
        MainCam.transform.parent.GetComponent<SimplePlayerController>().enabled = false;
        MainCam.GetComponent<WalkAnim>().enabled = false;
        MainCam.GetComponent<Animator>().enabled = false;
        Debug.Log(MomCam.transform.position);
        MainCam.transform.DOMove(MomCam.transform.position, 2);
        MainCam.transform.DORotate(MomCam.transform.rotation.eulerAngles, 2).OnComplete(() => {
            MainCam.enabled = false;
            MomCam.enabled = true;
            MainCam.GetComponent<AudioListener>().enabled = false;
            MomCam.GetComponent<AudioListener>().enabled = true;
            this.GetComponent<Animation>().Play();
        });
    }
}
