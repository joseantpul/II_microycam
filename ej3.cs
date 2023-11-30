using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ej3 : MonoBehaviour
{
    private Material materialtv;
    private WebCamTexture webcamTexture;
    private bool isPlaying = false;
    private int captureCounter = 0;

    void Start()
    {
        // Crea una nueva WebCamTexture y la asigna al material del objeto "Pantalla"
        webcamTexture = new WebCamTexture();
        materialtv = GetComponent<Renderer>().material;
        materialtv.mainTexture = webcamTexture;
        //renderer.material.mainTexture = webcamTexture;
    }

    void Update()
    {
        // Inicia la captura de video con la cámara web cuando se presiona 'Q'
        if (Input.GetKeyDown(KeyCode.Q) && !isPlaying)
        {
            webcamTexture.Play();
            isPlaying = true;
        }

        // Detiene la captura de video cuando se presiona 'P'
        if (Input.GetKeyDown(KeyCode.P) && isPlaying)
        {
            webcamTexture.Pause();
            isPlaying = false;
        }

        // Muestra un fotograma estático cuando se presiona 'X'
        if (Input.GetKeyDown(KeyCode.X))
        {
            string savePath = "C:/Users/jantu/microycam/Assets/capturas/";
            Texture2D snapshot = new Texture2D(webcamTexture.width, webcamTexture.height);
            snapshot.SetPixels(webcamTexture.GetPixels());
            snapshot.Apply();
            System.IO.File.WriteAllBytes(savePath + captureCounter.ToString() + ".png", snapshot.EncodeToPNG());
            captureCounter++;
        }
    }
}
