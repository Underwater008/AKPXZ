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
    private void Start()
    {
        mask = LayerMask.GetMask("Highlighted");
        OriginalColor = this.GetComponent<RawImage>().color;
        IHit = false;

    }
    private void FixedUpdate()
    {

        bool BeforeRay = IHit;
       // Debug.DrawRay(CurrentCamera.position, CurrentCamera.TransformDirection(Vector3.forward) * 1.5f, Color.yellow);
        RaycastHit hit;
        if (Physics.Raycast(CurrentCamera.position, CurrentCamera.TransformDirection(Vector3.forward), out hit, 1.5f, mask))
        {
            IHit = true;
            currentHighlighted = hit.collider.gameObject;
        }
        else
        {
            IHit = false;
        }


        if(IHit != BeforeRay)
        {
            if (!BeforeRay)
            {
                Debug.Log("Just Hit One");
                this.GetComponent<RawImage>().color = HitColor;
                if (hit.collider.gameObject.GetComponent<Outline>() != null)
                {
                    hit.collider.gameObject.GetComponent<Outline>().enabled = true;
                    if (!hit.collider.transform.GetChild(0).GetComponent<Typewriter>().Typed)
                    {
                        currentHighlighted.transform.GetChild(0).gameObject.SetActive(true);
                        hit.collider.transform.GetChild(0).GetComponent<Typewriter>().StartTyping();
                    }
                    else
                    {
                        hit.collider.transform.GetChild(0).gameObject.SetActive(true);
                    }
                }
                else
                {
                    //Outline tempOutline = hit.collider.gameObject.AddComponent<Outline>();
                    //tempOutline.OutlineColor = Color.white;
                    //tempOutline.OutlineWidth = 2;
                    //tempOutline.OutlineMode = Outline.Mode.OutlineVisible;
                    Debug.Log("Outline compoment missing on the highlighted gameobject: " + hit.collider.gameObject.name);
                }
            }
            else
            {
                Debug.Log(" Just leave one");
                this.GetComponent<RawImage>().color = OriginalColor;
                currentHighlighted.GetComponent<Outline>().enabled = false;
                currentHighlighted.transform.GetChild(0).gameObject.SetActive(false);
                currentHighlighted = null;
            }
        }

    }
}
