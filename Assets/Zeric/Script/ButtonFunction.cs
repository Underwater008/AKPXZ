using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class ButtonFunction : MonoBehaviour
{
    public GameObject Title, Play, Point;
    public GameObject Phone;
    public void StartGame()
    {
        Title.GetComponent<TMP_Text>().DOFade(0,1).OnComplete(() => {
            Title.SetActive(false);
        });
        Play.GetComponent<TMP_Text>().DOFade(0, 1).OnComplete(() => {
            DoorBell.instance.StandUp();
            Play.SetActive(false);
            Point.SetActive(true);
            Phone.GetComponent<PhoneCall>().PhoneSetup();
        }).OnStart(() => {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        });
    }
}
