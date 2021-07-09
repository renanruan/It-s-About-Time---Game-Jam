using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageSystem : MonoBehaviour
{
    [SerializeField]
    private Animator MessageAnimator;

    [SerializeField]
    private TextMeshProUGUI Text;

    [SerializeField]

    private static MessageSystem Instance;

    [SerializeField]
    private float Timer = 1;

    public static void ShowMessage(string message)
    {
        Instance.SetMessage(message);
        Instance.SetTime(message.Length);
        Instance.InitiateMessage();
    }

    private void SetMessage(string message)
    {
        Text.text = message;
    }

    private void SetTime(int count)
    {
        Timer = 0.1f * count;
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if(Timer > 0)
        {
            enabled = false;
        }
    }

    private void Update()
    {
        Timer -= Time.deltaTime;

        if (Timer <= 0)
        {
            MessageAnimator.SetBool("Show", false);
            enabled = false;
        }
    }

    private void InitiateMessage()
    {
        enabled = true;
        MessageAnimator.SetBool("Show", true);


    }

    public void FinalizeMessage()
    {
        enabled = false;
    }
}
