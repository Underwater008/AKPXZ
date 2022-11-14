using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ending : MonoBehaviour
{
    public Camera MainCam, MomCam;
    private void Start()
    {
        MainCam.transform.DOMove(MomCam.transform.position, 1);
        MainCam.transform.DOMove(MomCam.transform.rotation.eulerAngles, 1).OnComplete(() => {
            MainCam.enabled = false;
            MomCam.enabled = true;
            MainCam.GetComponent<AudioListener>().enabled = false;
            MomCam.GetComponent<AudioListener>().enabled = true;

        });
    }
}
