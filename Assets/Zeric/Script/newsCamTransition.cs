namespace XiaoWordSystem
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class newsCamTransition : MonoBehaviour
    {
        public TypeWriterEffect textCanvas;
        public Camera newsCam, MainCam;
        public Transform NewsReadingPos;
        private int IsInPosition;


        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                //Debug.Log("Show box F");
                gameObject.GetComponentInChildren<TypeWriterEffect>().ShowText();
            }

        }

        private void OnTriggerExit(Collider other)
        {
            //Debug.Log("Show box F");
            gameObject.GetComponentInChildren<TypeWriterEffect>().HideText();
        }

        private void OnTriggerStay(Collider other)
        {
            if (Input.GetKeyDown(KeyCode.F) && IsInPosition == 0)
            {
                Debug.Log("Show box F");
                StartCoroutine(LerpPlayerToNewsView(NewsReadingPos.position, NewsReadingPos.rotation, 1f, newsCam.transform));
            }

            if (Input.GetKey(KeyCode.Escape) && IsInPosition == 2)
            {
                IsInPosition = 1;
                newsCam.GetComponent<Animator>().SetBool("CamIn", false);
            }
        }

            IEnumerator LerpPlayerToNewsView(Vector3 targetPosition, Quaternion targetRotation, float duration, Transform Transformee)
            {
                IsInPosition = 1;
                //change the active camera to the news cam
                newsCam.transform.position = Camera.main.transform.position;
                newsCam.transform.rotation = Camera.main.transform.rotation;
                MainCam = Camera.main;
                Camera.main.enabled = false;
                newsCam.enabled = true;
                //lerp the position to the animation position
                float time = 0;
                Vector3 startPosition = Transformee.position;
                Quaternion startRotation = Transformee.rotation;
                while (time < duration)
                {
                    Transformee.rotation = Quaternion.Lerp(startRotation, targetRotation, time / duration);
                    Transformee.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
                    time += Time.deltaTime;
                    yield return null;
                }
                Transformee.position = targetPosition;
                Transformee.rotation = targetRotation;

                //now set the animation to true
                newsCam.GetComponent<Animator>().enabled = true;
                newsCam.GetComponent<Animator>().SetBool("CamIn", true);
                IsInPosition = 2;
            }

        public void PlayerLerpBack()
        {
            StartCoroutine(LerpingPlayerBackToMain(MainCam.transform.position, MainCam.transform.rotation, 1f, newsCam.transform));
        }

        IEnumerator LerpingPlayerBackToMain(Vector3 targetPosition, Quaternion targetRotation, float duration, Transform Transformee)
            {
                newsCam.GetComponent<Animator>().enabled = false;
                float time = 0;
                Vector3 startPosition = Transformee.position;
                Quaternion startRotation = Transformee.rotation;
                while (time < duration)
                {
                    Transformee.rotation = Quaternion.Lerp(startRotation, targetRotation, time / duration);
                    Transformee.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
                    time += Time.deltaTime;
                    yield return null;
                }
                Transformee.position = targetPosition;
                Transformee.rotation = targetRotation;
                //targetTransform.gameObject.SetActive(false);
                MainCam.enabled = true;
                newsCam.enabled = false;
                IsInPosition = 0;
            }
        
    }
}
