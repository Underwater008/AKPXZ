using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAnim : MonoBehaviour
{
    public static WalkAnim instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void ChangeAnimState(bool Iswalking)
    {
        this.GetComponent<Animator>().SetBool("Walking", Iswalking);
    }
}
