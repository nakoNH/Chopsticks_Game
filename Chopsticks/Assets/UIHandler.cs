using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject PrimaryInputGO;
    [SerializeField]
    private GameObject SecondaryInputGO;

    [SerializeField]
    private TurnLogic TurnLogicScript;

    [HideInInspector]
    public bool activate;


    // Start is called before the first frame update
    void Start()
    {
        activate = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (TurnLogicScript.GetTurnNumber() % 2 == 0)
        {
            PrimaryInputGO.SetActive(false);

            EnableAllObjects(SecondaryInputGO);
            SecondaryInputGO.SetActive(false);
        }
        else
        {
            if (activate)
            {
                PrimaryInputGO.SetActive(true);
                activate = false;
            }
        }
    }

    public void DisablePIGO()
    {
        PrimaryInputGO.SetActive(false);
    }
    private void EnableAllObjects(GameObject go)
    {
        for (int i = 0; i < go.transform.childCount; i++)
        {
            go.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
