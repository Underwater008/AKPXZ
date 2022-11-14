using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAnim : MonoBehaviour
{
    public static WalkAnim instance;
    // Start is called before the first frame update
    private void OnEnable()
    {
        instance = this;
    }

    public void ChangeAnimState(bool Iswalking)
    {
        this.GetComponent<Animator>().SetBool("Walking", Iswalking);
        if (Iswalking)
        {
            if(!this.GetComponent<AudioSource>().isPlaying)
            this.GetComponent<AudioSource>().Play();
        }
        else
        {
            if (this.GetComponent<AudioSource>().isPlaying)
                this.GetComponent<AudioSource>().Stop();
        }

    }
}
