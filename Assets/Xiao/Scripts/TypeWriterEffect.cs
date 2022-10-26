namespace XiaoWordSystem
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using DG.Tweening;


    public class TypeWriterEffect : MonoBehaviour
    {
        [Header("Properties")]

        public float delay = 1f;

        private Text txt;

        // Start is called before the first frame update
        void Start()
        {
            txt = this.GetComponent<Text>();
            txt.DOColor(Color.clear, 0f);
        }

        public void ShowText()
        {
            txt.DOColor(Color.white, 2f);
        }

        public void HideText()
        {
            txt.DOColor(Color.clear, 1f).OnComplete(() => 
            gameObject.SetActive(false)

            );
        }

    }
}
