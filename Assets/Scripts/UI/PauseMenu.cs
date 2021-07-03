using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private Animator ToolBarAnimator;

    private void Start()
    {
        ShowToolBar();
    }

    private void ShowToolBar()
    {
        ToolBarAnimator.SetTrigger("Click");
    }
}
