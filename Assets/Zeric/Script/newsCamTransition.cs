namespace XiaoWordSystem
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using DG.Tweening;

    public class newsCamTransition : MonoBehaviour
    {
        public TypeWriterEffect textCanvas;
        public Camera newsCam, MainCam;
        public Transform NewsReadingPos;
        private int IsInPosition;
        public Transform News;
        public Transform NewsInFrontPos;
        private bool triggered = false;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player" && !triggered)
            {
                //Debug.Log("Show box F");
                gameObject.GetComponentInChildren<TypeWriterEffect>().ShowText();
                triggered = true;
            }

        }

        private void OnTriggerExit(Collider other)
        {
            //Debug.Log("Show box F");

        }

        private void OnTriggerStay(Collider other)
        {
            if (Input.GetKeyDown(KeyCode.F) && IsInPosition == 0)
            {
                IsInPosition = 1;

                Debug.Log("Show box F");
                //Disable hint text
                gameObject.GetComponentInChildren<TypeWriterEffect>().HideText();
                //Stop player movement
                var simplePlayerController = GameObject.FindGameObjectWithTag("Player").GetComponent<SimplePlayerController>();
                var playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>();
                var mainCamAnimator = GameObject.Find("MainCamera").GetComponent<Animator>();
                playerAnimator.enabled = false;
                mainCamAnimator.enabled = false;
                simplePlayerController.canMove = false;

                //StartCoroutine(LerpPlayerToNewsView(NewsReadingPos.position, NewsReadingPos.rotation, 1f, newsCam.transform));

                News.SetParent(Camera.main.transform);
                News.DOMove(NewsInFrontPos.position, 2f);
                News.DORotate(NewsInFrontPos.eulerAngles, 2f).OnComplete(() =>
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    var houseScene = GameObject.Find("/HouseScene").GetComponent<Transform>();
                    News.SetParent(houseScene);
                });
                //News.LookAt(Camera.main.transform.position);
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
