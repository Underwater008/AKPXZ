using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class TextFadeIn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<TMP_Text>().DOFade(1, 1);
    }

}
