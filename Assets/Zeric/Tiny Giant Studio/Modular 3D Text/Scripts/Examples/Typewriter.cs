using System.Collections;
using UnityEngine;

namespace MText
{
    public class Typewriter : MonoBehaviour
    {
        [SerializeField] public Modular3DText modular3DText = null;
        [TextArea]
        public string text = "Typewriter text";
        [Tooltip("Minimum and maximum possible speed.")]
        public float speed;
        [Tooltip("Minimum and maximum possible volume.")]
        [SerializeField] Vector2 volume = Vector2.one;
        [SerializeField] AudioSource audioSource = null;

        [SerializeField] string typingSymbol = null;
        [SerializeField] bool startAutomatically = true;
        [SerializeField] float startDelay = 0;

        public bool TypeFromStart;
        public bool Typed;

        void Start()
        {
            modular3DText.Text = "";
            Debug.Log("Disable all text");
            speed = 0.00001f;
            if(TypeFromStart)
            { StartTyping(); }
        }

        //call this
        public void StartTyping()
        {
            modular3DText.Text = "";
            Coroutine typing = StartCoroutine(TypingRoutine());
        }

        IEnumerator TypingRoutine()
        {
            if (modular3DText)
            {
                for (int i = 0; i <= text.Length; i++)
                {
                    modular3DText.Text = (text.Substring(0, i) + typingSymbol);


                    yield return null;
                    //yield return new WaitForSeconds(speed);
                }

            }
            else
            {
                Debug.Log("<color=red>No text object is selected on typewriter.</color> :" + gameObject.name, gameObject);
            }
            Typed = true;
        }

        public void StartTypingLoop()
        {
            modular3DText.Text = "";
            Coroutine typing = StartCoroutine(TypingRoutineLoop());
        }
        IEnumerator TypingRoutineLoop()
        {
            if (modular3DText)
            {
                for (int i = 0; i <= text.Length; i++)
                {
                    modular3DText.Text = (text.Substring(0, i) + typingSymbol);


                    yield return null;
                    //yield return new WaitForSeconds(speed);

                }

            }
            else
            {
                Debug.Log("<color=red>No text object is selected on typewriter.</color> :" + gameObject.name, gameObject);
            }
            StartCoroutine(TypingRoutineLoop());
        }
    }
}