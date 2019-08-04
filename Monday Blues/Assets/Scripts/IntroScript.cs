using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroScript : MonoBehaviour
{
    public Image image1;
    public Image image2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RunIntro());
    }

    

    public IEnumerator RunIntro()
    {

        image1.gameObject.SetActive(true);

        yield return new WaitForSeconds(6.0f);

        image1.gameObject.SetActive(false);
        image2.gameObject.SetActive(true);

        yield return new WaitForSeconds(10.0f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

}
