namespace XiaoWordSystem
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class AnimationEvent : MonoBehaviour
    {
        public void StartLerpBack()
        {
            transform.parent.parent.GetComponent<newsCamTransition>().PlayerLerpBack();
        }
    }
}
