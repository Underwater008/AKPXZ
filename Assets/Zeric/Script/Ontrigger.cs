using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ontrigger : MonoBehaviour
{
    public GameObject CarScene;
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Co1());
    }

    IEnumerator Co1()
    {
        yield return new WaitForSeconds(20);
        CarScene.GetComponent<Scene1Transition>().StartTransitionBack();
    }
}
