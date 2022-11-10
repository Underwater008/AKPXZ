using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NewsInteract : MonoBehaviour
{


    public Camera newsCam, MainCam;
    public Transform NewsReadingPos;
    public void Read()
    {
        if (crosshair.HaveGlasses)
        {
            StartCoroutine(LerpPlayerToNewsView(NewsReadingPos.position, NewsReadingPos.rotation, 1f, newsCam.transform));
            int temp = LayerMask.NameToLayer("Default");
            this.gameObject.layer = temp;
            //crosshair.instance.gameObject.SetActive(false);
        }

    }


    IEnumerator LerpPlayerToNewsView(Vector3 targetPosition, Quaternion targetRotation, float duration, Transform Transformee)
    {
        //change the active camera to the news cam
        newsCam.transform.position = MainCam.transform.position;
        newsCam.transform.rotation = MainCam.transform.rotation;
        MainCam.enabled = false;
        newsCam.enabled = true;
        //lerp the position to the animation position
        float time = 0;
        Vector3 startPosition = Transformee.position;
        Quaternion startRotation = Transformee.rotation;
        while (time < duration)
        {
            Transformee.rotation = Quaternion.Lerp(startRotation, targetRotation, time / duration);
            Transformee.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        Transformee.position = targetPosition;
        Transformee.rotation = targetRotation;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //now set the animation to true
    }

}
