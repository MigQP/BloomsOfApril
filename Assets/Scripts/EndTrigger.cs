using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    private TextManager textManager;


    public GameObject petal;
    public GameObject petals;
    public GameObject sunflower;

    public GameObject[] objectsArray;


    // Start is called before the first frame update
    void Start()
    {
      
        textManager = FindObjectOfType<TextManager>();
        objectsArray = GameObject.FindGameObjectsWithTag("Petal");
    }

    private void Update()
    {
        objectsArray = GameObject.FindGameObjectsWithTag("Petal");
    }


    private void OnTriggerEnter(Collider other)
    {
        textManager.textAnim.SetTrigger("FadeOut");
        TextManager.instance.textAnim.SetBool("Fadein", false);
        TextManager.instance.textAnim.SetBool("Fadeout", true);
        TextManager.instance.endLeave++;
        
        if (TextManager.instance.endLeave == 12)
        {
            TextManager.instance.animPostProcessing.FadeOut();
            TextManager.instance.mainMenuPanelAnim.SetTrigger("FadeIn");
            GameManager.instance.LockCanMovePetals();
            var myNewSmoke = Instantiate(petals, new Vector3(sunflower.transform.position.x, sunflower.transform.position.y, sunflower.transform.position.z), sunflower.transform.rotation);
            myNewSmoke.transform.parent = sunflower.transform;
            TextManager.instance.endLeave = 0;
            TextManager.instance.leaveCount = 0;
        }
    }



    private void OnTriggerExit(Collider other)
    {
        textManager.textAnim.SetTrigger("FadeOut");
        Destroy(other.gameObject);
        //objectsArray = GameObject.FindGameObjectsWithTag("Petal");
        if (TextManager.instance.endLeave != 12)

            for (int i = 0; i < objectsArray.Length; i++)
            {
                objectsArray[i].AddComponent<MouseDrag>();
            }
    }
}