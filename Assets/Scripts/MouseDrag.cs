using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    Rigidbody rb;

    Vector3 offset;

    private TextManager textManager;

    public bool stopPickUp;

    public EndTrigger endTrigger;


    public GameObject[] objectsArray; // reference to the array of objects
    public GameObject excludedObject; // reference to the object to be excluded

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        textManager = FindObjectOfType<TextManager>();
        rb.isKinematic = true;
        endTrigger = FindObjectOfType<EndTrigger>();
        objectsArray = GameObject.FindGameObjectsWithTag("Petal");
        excludedObject = this.gameObject;
  
    }

    private void Update()
    {
        objectsArray = GameObject.FindGameObjectsWithTag("Petal");
    }


    private void OnMouseDown()
    {

        if (!GameManager.instance.ReadCanMovePetals())
            return;

        if (!stopPickUp )
        {
            offset = transform.position - MouseWorldPosition();
            //TextManager.instance.leaveCount++;
            //TextManager.instance.textAnim.SetTrigger("FadeIn");

            TextManager.instance.textAnim.SetBool("Fadein", true);
            TextManager.instance.textAnim.SetBool("Fadeout", false);
            if (TextManager.instance.endLeave == 0)
                TextManager.instance.tutorialAnim.SetBool("FadeOut 0", true);
        }


    }

    private void OnMouseDrag()
    {

        if (!GameManager.instance.ReadCanMovePetals())
            return;

        if (!stopPickUp)
        {
            transform.position = MouseWorldPosition() + offset;
            TextManager.instance.textAnim.SetBool("Fadein", true);
            TextManager.instance.textAnim.SetBool("Fadeout", false);
            if (TextManager.instance.endLeave == 0)
                TextManager.instance.tutorialAnim.SetBool("FadeOut 0", true);
        }

    }




    private void OnMouseUp()
    {

        if (!GameManager.instance.ReadCanMovePetals())
            return;
        objectsArray = GameObject.FindGameObjectsWithTag("Petal");
        rb.isKinematic = false;
        rb.useGravity = true;
        //textManager.textAnim.SetTrigger("FadeOut");
        stopPickUp = true;
        TextManager.instance.tutorialAnim.SetBool("FadeOut 0", false);

        for (int i = 0; i < objectsArray.Length; i++)
        {
            if (objectsArray[i] != excludedObject)
            {
                // change the bool value of the current object in the loop
                Destroy(objectsArray[i].GetComponent<MouseDrag>());
            }
        }

    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }

}
