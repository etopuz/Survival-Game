using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractingPopUpController : MonoBehaviour
{
    private Text key;
    private Text message;
    private Image buttonImage;

    private void Awake()
    {
        key = transform.Find("Key").GetComponent<Text>();
        message = transform.Find("Message").GetComponent<Text>();
        buttonImage = transform.Find("ButtonImage").GetComponent<Image>();
        ClosePopUp();
    }

    public void SetTextAndMessage(string _key, string _message)
    {
        OpenPopUp();
        message.text = _message;
        key.text = _key;
    }

    public void ClosePopUp()
    {
        buttonImage.enabled = false;
        key.enabled = false;
        message.enabled = false;
    }

    private void OpenPopUp()
    {
        buttonImage.enabled = true;
        key.enabled = true;
        message.enabled = true;
    }
}
