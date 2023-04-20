using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    bool canModify;

    public Animator creditsPanel;
    public void MovePetals()
    {
        if (canModify)
        GameManager.instance.SetCanMovePetals();

    }

    public void ModifyTrue()
    {
        canModify = true;
    }

    public void ModifyFalse()
    {
        canModify = false;
    }

    public void FadeCredits()
    {
        creditsPanel.SetTrigger("FadeIn");
    }
}
