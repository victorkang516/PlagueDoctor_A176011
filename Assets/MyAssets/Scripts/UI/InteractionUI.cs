using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionUI : MonoBehaviour
{
    Text infoText;


    void Start()
    {
        infoText = transform.GetChild(0).GetComponent<Text>();
    }

    public void Show(string msg)
    {
        gameObject.SetActive(true);
        infoText.text = msg;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
