namespace XiaoWordSystem
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using MText;
    using DG.Tweening;

    public class AnimationEvent : MonoBehaviour
    {
        public string TextChangeInto;
        public Transform personPos;

        public GameObject ObjectToHighlight;

        public GameObject[] thingsSetDefault;
        public void StartLerpBack()
        {
            transform.parent.parent.GetComponent<newsCamTransition>().PlayerLerpBack();
        }

        public void ChangeText()
        {
            if(GetComponent<Outline>() != null)
            {
                Typewriter temp = this.GetComponent<Outline>().MyText.GetComponent<Typewriter>();
                temp.StopAllCoroutines();
                temp.text = TextChangeInto;
                temp.StartTyping();
            }
        }

        public void PickUpGlasses()
        {
            this.transform.DORotate(personPos.rotation.eulerAngles, 1.4f).OnComplete(() => {
            });
            this.transform.DOMove(personPos.position, 1.4f).OnComplete(() => {
                this.gameObject.SetActive(false);
            });
        }

        public void SetThingsHighlight()
        {
            int temp = LayerMask.NameToLayer("Highlighted");
            ObjectToHighlight.layer = temp;
        }

        public void SetThingsDefault()
        {
            int temp = LayerMask.NameToLayer("Default");
            for (int i = 0; i < thingsSetDefault.Length; i++)
            {
                thingsSetDefault[i].layer = temp;
            }
        }
    }
}
