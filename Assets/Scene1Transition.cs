using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1Transition : MonoBehaviour
{
    private void OnMouseDown()
    {
        Cursor.visible = false;

        Cursor.lockState = CursorLockMode.Locked;


    }
}
