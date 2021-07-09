using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarTransparency : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    private bool isVisible = false;

    private void StopAnimation()
    {
        if(anim.GetFloat("Direction") < 0)
        {
            anim.SetFloat("Direction", 0);
        }
        
    }

    private void ToggleVisibility()
    {
        isVisible = !isVisible;

        if (isVisible)
        {
            anim.SetTrigger("Visible");
        }
    }

    private void RewindAnimation()
    {
        anim.SetFloat("Direction", -1);
    }

    public void ShowBar()
    {
        if (isVisible)
        {
            anim.SetTrigger("RestartWait");
        }
        else
        {
            anim.SetFloat("Direction", 1);
        }
    }
}
