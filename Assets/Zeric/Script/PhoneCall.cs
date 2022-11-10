using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MText;

public class PhoneCall : MonoBehaviour
{
    public static PhoneCall instance;
    private Typewriter mytypewriter;
    public GameObject SlideDoor;
    public AudioClip MaddySpeaking;
    public void PhoneSetup()
    {
        instance = this;
        StartCoroutine(timerStart());
    }

    public void PhoneStart()
    {
        this.GetComponent<Animation>().Play();
       mytypewriter = this.GetComponent<Outline>().MyText.GetComponent<Typewriter>();
        this.GetComponent<Outline>().MyText = null;
        mytypewriter.gameObject.SetActive(true);
        mytypewriter.Typed = true;
        mytypewriter.text = "Phone Ringing! " +
            "[Pick up]";
        //this.GetComponent<Outline>().HasButton = true;
        mytypewriter.StartTypingLoop();
        StartCoroutine(RingTimer(10));
        this.GetComponent<AudioSource>().Play();
        
    }

    public void PhonePickedup()
    {
        this.GetComponent<AudioSource>().Stop();
        this.GetComponent<AudioSource>().clip = MaddySpeaking;
        this.GetComponent<AudioSource>().Play();
        this.StopAllCoroutines();
        this.GetComponent<Outline>().HasButton = false;
    }


    public void PhoneEnd()
    {
        this.GetComponent<AudioSource>().Stop();
        this.GetComponent<Outline>().HasButton = false;
        mytypewriter.modular3DText.Text = "Maddy just called to remind you of your pills.";
        this.GetComponent<Outline>().MyText = mytypewriter.gameObject;
        this.GetComponent<Outline>().MyText.GetComponent<Typewriter>().StopAllCoroutines();
        int temp = LayerMask.NameToLayer("Highlighted");
        SlideDoor.layer = temp;
    }

    IEnumerator RingTimer(float duration)
    {
        yield return new WaitForSeconds(duration);
        RingEnd();
    }


    public void RingEnd()
    {
        this.GetComponent<Animation>().Stop();
        this.GetComponent<AudioSource>().Stop();
        this.GetComponent<Outline>().HasButton = false;
        mytypewriter.modular3DText.Text = "You missed a phone call.";
        this.GetComponent<Outline>().MyText = mytypewriter.gameObject;
        this.GetComponent<AudioSource>().clip = MaddySpeaking;
        this.GetComponent<AudioSource>().Play();
        this.GetComponent<Outline>().MyText.GetComponent<Typewriter>().StopAllCoroutines();
    }

    IEnumerator timerStart()
    {
        yield return new WaitForSeconds(60);
        PhoneStart();
    }

}
