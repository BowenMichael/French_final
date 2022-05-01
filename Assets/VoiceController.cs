using System.Collections;
using System.Collections.Generic;
using SpeechLib;
using UnityEngine;
using UnityEngine.UI;

public class VoiceController : MonoBehaviour
{
    [SerializeField]Text txt;

    public void speak()
    {
        SpVoice voice = new SpVoice();
        voice.Speak(txt.text);
    }
}
