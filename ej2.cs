using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ej2 : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip recordedClip;
    private bool isRecording = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        // Iniciar la grabación desde el micrófono
        audioSource.clip = Microphone.Start(null, true, 10, 44100);
        isRecording = true;
    }

    void Update()
    {
        // Detener la grabación y guardar el clip si se presiona 'S'
        if (Input.GetKeyDown(KeyCode.S) && isRecording)
        {
            Microphone.End(null);
            recordedClip = audioSource.clip;
            isRecording = false;
        }

        // Reproducir el clip grabado si se presiona 'R'
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (recordedClip != null)
            {
                audioSource.PlayOneShot(recordedClip);
            }
            else
            {
                Debug.Log("No se ha grabado ningún clip de audio aún.");
            }
        }
    }
}
