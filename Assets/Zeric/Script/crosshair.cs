using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MText;

public class crosshair : MonoBehaviour
{
    LayerMask mask;
    public Transform CurrentCamera;
    public int OutlineWidth;
    public Outline.Mode OutlineMode;
    private Color OriginalColor;
    public Color HitColor;
    private bool IHit;
    GameObject currentHighlighted;
    public bool CanClick;

    //phone called
    private bool MaddyCalled;

    public static bool HaveGlasses;

    public static crosshair instance;
    public float CrosshairLenth;
    private void Start()
    {
        instance = this;
        //HaveGlasses = true;
        mask = LayerMask.GetMask("Highlighted");
        OriginalColor = this.GetComponent<RawImage>().color;
        IHit = false;
        CrosshairLenth = 2f;

    }
    private void FixedUpdate()
    {

        bool BeforeRay = IHit;
        // Debug.DrawRay(CurrentCamera.position, CurrentCamera.TransformDirection(Vector3.forward) * 1.5f, Color.yellow);
        RaycastHit hit;
        if (Physics.Raycast(CurrentCamera.position, CurrentCamera.TransformDirection(Vector3.forward), out hit, CrosshairLenth, mask))
        {
            IHit = true;
            currentHighlighted = hit.collider.gameObject;
        }
        else
        {
            IHit = false;
        }


        if (IHit != BeforeRay)
        {
            if (!BeforeRay)
            {
                Debug.Log("Just Hit One");
                this.GetComponent<RawImage>().color = HitColor;
                if (hit.collider.gameObject.GetComponent<Outline>() != null)
                {
                    hit.collider.gameObject.GetComponent<Outline>().enabled = true;
                    Outline temp = hit.collider.gameObject.GetComponent<Outline>();
                    if (temp.MyText != null)
                    {
                        if (!temp.MyText.GetComponent<Typewriter>().Typed)
                        {
                            temp.MyText.SetActive(true);
                            temp.MyText.GetComponent<Typewriter>().StartTyping();
                        }
                        else
                        {
                            temp.MyText.SetActive(true);
                        }
                    }
                    if (temp.HasButton)
                    {
                        CanClick = true;
                    }
                }
                else
                {
                    //foreach (Outline tempoutline in hit.collider.gameObject.GetComponentsInChildren<Outline>())
                    //{
                    //    tempoutline.enabled = true;
                    //}
                    //Outline temp = hit.collider.gameObject.GetComponent<Outline>();
                    //if (temp.MyText != null)
                    //{
                    //    if (!temp.MyText.GetComponent<Typewriter>().Typed)
                    //    {
                    //        temp.MyText.SetActive(true);
                    //        temp.MyText.GetComponent<Typewriter>().StartTyping();
                    //    }
                    //    else
                    //    {
                    //        temp.MyText.SetActive(true);
                    //    }
                    //}

                }
            }
            else
            {

                this.GetComponent<RawImage>().color = OriginalColor;
                if (currentHighlighted.GetComponent<Outline>().MyText != null)
                    currentHighlighted.GetComponent<Outline>().MyText.SetActive(false);
                currentHighlighted.GetComponent<Outline>().enabled = false;
                currentHighlighted = null;
                CanClick = false;
            }
        }

        InteractionCheck(hit);

        //maddy call's
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!MaddyCalled)
            {
                MaddyCalled = true;

                PhoneCall.instance.PhoneStart();
            }
        }

    }

    public void InteractionCheck(RaycastHit hit)
    {
        if (CanClick)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (hit.collider.gameObject.GetComponent<PhoneCall>() != null)
                {
                    Debug.Log("S");
                    hit.collider.gameObject.GetComponent<Animation>().Stop();
                    hit.collider.gameObject.GetComponent<Animation>().Play("PickUp");
                    return;
                }

                hit.collider.gameObject.GetComponent<Animation>().Play();

            }
        }
    }
}
