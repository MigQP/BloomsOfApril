using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    bool canMovePetals;

    public bool canPickUp;

    public GameObject[] objectsArray;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        objectsArray = GameObject.FindGameObjectsWithTag("Petal");
    }

    private void Update()
    {
        

    }

    public bool ReadCanMovePetals()
    {
        return canMovePetals;
    }

    public void SetCanMovePetals()
    {
        canMovePetals = true;
    }

    public void LockCanMovePetals()
    {
        canMovePetals = false;
    }


}
