using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Window_Download : MonoBehaviour
{

    public float maxDownloadProgress;

    public bool downloading;
    public bool finishedDownloading;
    public float downloadProgress;

    public float delayDownload;
    public float delayWindow;

    public bool failing;
    public float failTime;
    public float failTimer;

    public Image progressBar;

    public Text progressText;

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
            delayDownload = delayDownload + Time.deltaTime;
        }

        if (downloadProgress > maxDownloadProgress)
        {
            downloadProgress = maxDownloadProgress;
        }

        if (failing == true)
        {
            failTimer = failTimer + Time.deltaTime;

            if (failTimer >= failTime)
            {
                failing = false;
                downloadProgress = 0;
                delayDownload = 0;
            }
        }

        progressBar.fillAmount = downloadProgress / maxDownloadProgress;
        progressText.text = (Mathf.RoundToInt((downloadProgress / maxDownloadProgress) * 100).ToString()) + "%";

        if (downloadProgress >= maxDownloadProgress)
        {
            Debug.Log("Success!");
            downloading = false;
            finishedDownloading = true;
        }

        if (delayDownload >= delayWindow)
        {
            downloading = false;
            failing = true;
        }
    }

    public void StartDownload()
    {
        if (finishedDownloading == true)
        {
            Debug.LogWarning("Already downloaded");
            return;
        }

        downloading = true;
        delayDownload = 0;

        failing = false;
        failTimer = 0;
    }
}
