using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DidYouKnows : MonoBehaviour
{
    string[] DidYouKNows;
    public Text DidYouKnowText;
    int randomSelector;
    public int waitTime;

    public GameObject DidYouKnowPanel;

    private void Start()
    {
        DidYouKNows = new string[3];
        DidYouKNows[0] = " Did you know Hepatitis C is only transmitted through contact with infected blood.";
        DidYouKNows[1] = "Did you know Hepatitis C is a liver disease. It's caused by the hepatitis C virus, called HCV for short";
        DidYouKNows[2] = "Did you know 36.7 million people are living with HIV worldwide ";

        DidYouKnowPanel.SetActive(false);

        StartCoroutine(ShowDidYouKnow());
    }

    IEnumerator ShowDidYouKnow()
    {
        yield return new WaitForSeconds(waitTime);
        randomSelector = Random.Range(0, DidYouKNows.Length);
        DidYouKnowPanel.SetActive(true);
        DidYouKnowText.text = DidYouKNows[randomSelector];
    }

    public void ClosePanel()
    {
        DidYouKnowPanel.SetActive(false);
    }
}
