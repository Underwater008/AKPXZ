namespace XiaoWordSystem
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class SimplePlayerUse : MonoBehaviour
    {
        public GameObject mainCamera;
        private GameObject objectClicked;
        public GameObject flashlight;
        public KeyCode OpenClose;
        public KeyCode Flashlight;
        public KeyCode Intereact;

        void Start()
        {

        }

        void Update()
        {
            if (Input.GetKeyDown(OpenClose)) // Open and close action
            {
                RaycastCheck();
            }

            if (Input.GetKeyDown(Flashlight)) // Toggle flashlight
            {
                if (flashlight.activeSelf)
                    flashlight.SetActive(false);
                else
                    flashlight.SetActive(true);
            }

            if (Input.GetKeyDown(Intereact))
            {
                PickUpRaycastCheck();
            }
        }

        void RaycastCheck()
        {
            RaycastHit hit;

            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out hit, 2.3f))
            {
                if (hit.collider.gameObject.GetComponent<SimpleOpenClose>())
                {
                    // Debug.Log("Object with SimpleOpenClose script found");
                    hit.collider.gameObject.BroadcastMessage("ObjectClicked");
                }

            }

        }

        void PickUpRaycastCheck()
        {
            RaycastHit hit;

            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out hit, 5f))
            {
                if (hit.collider.gameObject.GetComponent<DeliveryBox>())
                {
                    TypeWriterEffect _typeWritterEffect = gameObject.GetComponent<DeliveryBox>().textCanvas;
                    _typeWritterEffect.HideText();
                    // Debug.Log("Object with SimpleOpenClose script found");
                    gameObject.GetComponent<CharacterController>().enabled = false;
                    gameObject.GetComponent<SimplePlayerController>().enabled = false;
                    gameObject.GetComponent<SimplePlayerUse>().enabled = false;
                    gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;
                    gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX;
                    gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationY;
                }

            }
        }
    }
}
