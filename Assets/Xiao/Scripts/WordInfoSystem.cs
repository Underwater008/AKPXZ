namespace XiaoWordSystem
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class WordInfoSystem : MonoBehaviour
    {
    [Header("Properties")]
    [SerializeField]
    private TypeWriterEffect TextCanvas; // the single char genarated
                                   //private List<TypeWriterEffect> wordItemList; // all the word

        private void OnTriggerEnter(Collider other)
        {

            if(other.tag == "Player")
            {
                Debug.Log("Collide");
                TextCanvas.ShowText();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            Debug.Log("Exit trigger");
            TextCanvas.HideText();
        }
    }
}
