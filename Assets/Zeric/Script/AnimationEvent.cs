namespace XiaoWordSystem
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using MText;


    public class AnimationEvent : MonoBehaviour
    {
        public string TextChangeInto;
        public void StartLerpBack()
        {
            transform.parent.parent.GetComponent<newsCamTransition>().PlayerLerpBack();
        }

        public void ChangeText()
        {
            if(GetComponent<Outline>() != null)
            {
                Typewriter temp = this.GetComponent<Outline>().MyText.GetComponent<Typewriter>();
                temp.text = TextChangeInto;
                temp.StartTyping();
            }
        }
    }
}
