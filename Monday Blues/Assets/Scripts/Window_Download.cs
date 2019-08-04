using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Window_Download : MonoBehaviour
{

    public float maxDownloadProgress;

    public bool downloading;
    public bool finishedDownloading;
    public float downloadProgress;

    public float delayDownloadTimer;
    public float delayWindow;

    public bool failing;
    public float failTime;
    public float failTimer;

    public Image progressBar;

    public TextMeshProUGUI progressText;

    public AudioSource audio;
    public AudioClip[] clips;

    public PopupScript downloadPausedPopup;

    // Start is called before the first frame update
    void Start()
    {
        downloading = false;
        finishedDownloading = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (downloading == true)
        {
            downloadProgress = downloadProgress + Time.deltaTime;
            delayDownloadTimer = delayDownloadTimer + Time.deltaTime;

            if (delayDownloadTimer >= delayWindow)
            {
                PauseDownload();
            }

            if (downloadProgress > maxDownloadProgress)
            {
                downloadProgress = maxDownloadProgress;
            }

            if (downloadProgress >= maxDownloadProgress)
            {
                Debug.Log("Success!");
                downloading = false;
                finishedDownloading = true;
            }
        }
        else if (failing == true)
        {
            failTimer = failTimer + Time.deltaTime;

            if (failTimer >= failTime)
            {
                ResetDownload();
            }
        }


        progressBar.fillAmount = downloadProgress / maxDownloadProgress;
        progressText.text = (Mathf.RoundToInt((downloadProgress / maxDownloadProgress) * 100).ToString()) + "%";
   
    }

    public void StartDownload()
    {
        Debug.Log("Starting Download");

        if (finishedDownloading == true)
        {
            Debug.LogWarning("Already downloaded");
            return;
        }

        downloading = true;
        delayDownloadTimer = 0;

        failing = false;
        failTimer = 0;
    }

    public void PauseDownload()
    {
        Debug.Log("Pausing Download");

        downloading = false;
        if (!failing)
        {
            audio.PlayOneShot(clips[0]);
        }
        failing = true;
        failTimer = 0;

        downloadPausedPopup.TriggerPopup();
    }

    public void ResetDownload()
    {
        Debug.Log("Reset Download");

        failing = false;
        downloadProgress = 0;
        audio.PlayOneShot(clips[1]);
        delayDownloadTimer = 0;
    }
}
