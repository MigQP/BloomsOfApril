using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    bool canMovePetals;

    public bool canPickUp;


    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    public bool ReadCanMovePetals()
    {
        return canMovePetals;
    }

    public void SetCanMovePetals()
    {
        canMovePetals = true;
        //TextManager.instance.endLeave = 0;
        //TextManager.instance.leaveCount = 0;
        TextManager.instance.mainMenuPanelAnim.SetBool("FadeOut 0", true);
        TextManager.instance.mainMenuPanelAnim.SetBool("FadeIn 1", false);
    }

    public void LockCanMovePetals()
    {
        canMovePetals = false;
        //TextManager.instance.mainMenuPanelAnim.SetTrigger("FadeIn");
        TextManager.instance.mainMenuPanelAnim.SetBool("FadeOut 0", false);
        TextManager.instance.mainMenuPanelAnim.SetBool("FadeIn 1", true);
    }

    public void FadeMainMenu()
    {
        TextManager.instance.mainMenuPanelAnim.SetBool("FadeOut 0", true);
        TextManager.instance.mainMenuPanelAnim.SetBool("FadeIn 1", false);
    }
}
