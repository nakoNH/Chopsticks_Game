using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICPLogic : MonoBehaviour
{
    // transform references for main sticks
    [SerializeField]
    private GameObject LCPPrefab;
    [SerializeField]
    private GameObject RCPPrefab;

    private GameObject LCPParent;
    private GameObject RCPParent;

    // offset when instantiating
    Vector3 LCPOffset;
    Vector3 RCPOffset;

    [SerializeField]
    private GameObject TurnLogicGO;

    [SerializeField]
    private GameObject CPHandlerGO;

    // Start is called before the first frame update
    void Start()
    {
        LCPParent = gameObject.transform.GetChild(0).gameObject;
        RCPParent = gameObject.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // PLAYING A TURN
        // if turn number is not divisible by 2, let them play turn
        // *if player wants 2nd turn, make sure turnNumber is divisible by 2 instead
        if (TurnLogicGO.GetComponent<TurnLogic>().GetTurnNumber() % 2 == 0)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                AddLChopstick();

                TurnLogicGO.GetComponent<TurnLogic>().SetTurnNumber();
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                AddRChopstick();

                TurnLogicGO.GetComponent<TurnLogic>().SetTurnNumber();
            }
        }

        // BEING TAPPED LOGIC
        // check if number of children in parent is not equal to new number (after being tapped)
        if (CPHandlerGO.transform.GetComponent<CPHandler>().GetAILCPcount() != LCPParent.transform.childCount)
        {
            int diff = CPHandlerGO.transform.GetComponent<CPHandler>().GetAILCPcount() - LCPParent.transform.childCount;

            for (int i = 0; i < diff; i++)
            {
                AddLChopstick();
                Debug.Log(CPHandlerGO.transform.GetComponent<CPHandler>().GetAILCPcount());
            }
        }

        if (CPHandlerGO.transform.GetComponent<CPHandler>().GetAIRCPcount() != RCPParent.transform.childCount)
        {
            int diff = CPHandlerGO.transform.GetComponent<CPHandler>().GetAIRCPcount() - RCPParent.transform.childCount;

            for (int i = 0; i < diff; i++)
            {
                AddRChopstick();
                Debug.Log(CPHandlerGO.transform.GetComponent<CPHandler>().GetAIRCPcount());
            }
        }

        // check if LEFT hand is more than 4, then destroys all GO under parent
        if (LCPParent.transform.childCount > 4)
        {
            while (LCPParent.transform.childCount > 0)
            {
                DestroyImmediate(LCPParent.transform.GetChild(0).gameObject);
            }

            CPHandlerGO.transform.GetComponent<CPHandler>()
                .SetAICPcount(0, CPHandlerGO.transform.GetComponent<CPHandler>().GetAIRCPcount());
        }

        // check if RIGHT hand is more than 4, then destroys all GO under parent
        if (RCPParent.transform.childCount > 4)
        {
            while (RCPParent.transform.childCount > 0)
            {
                DestroyImmediate(RCPParent.transform.GetChild(0).gameObject);
            }

            CPHandlerGO.transform.GetComponent<CPHandler>()
                .SetAICPcount(CPHandlerGO.transform.GetComponent<CPHandler>().GetAILCPcount(), 0);
        }

        CPHandlerGO.transform.GetComponent<CPHandler>()
            .SetAICPcount(LCPParent.transform.childCount, RCPParent.transform.childCount);
    }

    void AddLChopstick()
    {
        // get new offset depending on how many are already spawned
        LCPOffset = new Vector3(0.05f, -0.1f, 0) * (LCPParent.transform.childCount);

        var newLCP = Instantiate(LCPPrefab, (LCPPrefab.transform.position + LCPOffset), LCPPrefab.transform.localRotation);
        newLCP.SetActive(true);
        newLCP.transform.parent = LCPParent.transform;
    }

    void AddRChopstick()
    {
        // get new offset depending on how many are already spawned
        RCPOffset = new Vector3(-0.05f, -0.1f, 0) * (RCPParent.transform.childCount);

        var newRCP = Instantiate(RCPPrefab, (RCPPrefab.transform.position + RCPOffset), RCPPrefab.transform.localRotation);
        newRCP.SetActive(true);
        newRCP.transform.parent = RCPParent.transform;
    }
}
