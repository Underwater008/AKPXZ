namespace XiaoWordSystem
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class DeliveryBox : MonoBehaviour
    {
        public TypeWriterEffect textCanvas;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                Debug.Log("Show box F");
                gameObject.GetComponentInChildren<TypeWriterEffect>().ShowText();
            }

        }


    }
}
