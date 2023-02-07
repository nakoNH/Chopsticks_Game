using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCPLogic : MonoBehaviour
{
    // transform references for main sticks
    [SerializeField]
    private GameObject LCPObject;
    [SerializeField]
    private GameObject RCPObject;

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
        // if turn number is not divisible by 2, let them play turn
        // *if player wants 2nd turn, make sure turnNumber is divisible by 2 instead
        if (TurnLogicGO.GetComponent<TurnLogic>().GetTurnNumber() % 2 != 0)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (LCPParent.transform.childCount != 0)
                    AddLChopstick();

                // check if hand is more than 4, then destroys all GO under parent
                if (LCPParent.transform.childCount > 4)
                {
                    while (LCPParent.transform.childCount > 0)
                    {
                        DestroyImmediate(LCPParent.transform.GetChild(0).gameObject);
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                // only add CP if hand is not 0
                if (RCPParent.transform.childCount != 0)
                    AddRChopstick();

                // check if hand is more than 4, then destroys all GO under parent
                if (RCPParent.transform.childCount > 4)
                {
                    while (RCPParent.transform.childCount > 0)
                    {
                        DestroyImmediate(RCPParent.transform.GetChild(0).gameObject);
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                int LCPcount = CPHandlerGO.GetComponent<CPHandler>().GetPlayerLCPcount();
                int RCPcount = CPHandlerGO.GetComponent<CPHandler>().GetPlayerRCPcount();

                if (LCPcount == 0 && RCPcount > 1)
                {
                    SplitRHand();
                }
                else if (LCPcount > 1 && RCPcount == 0)
                {
                    SplitLHand();
                }
            }

            CPHandlerGO.transform.GetComponent<CPHandler>()
                .SetPlayerCPcount(LCPParent.transform.childCount, RCPParent.transform.childCount);
        }
    }

    void AddLChopstick()
    {
        // get new offset depending on how many are already spawned
        LCPOffset = new Vector3(0.05f, -0.1f, 0) * (LCPParent.transform.childCount);

        var newLCP = Instantiate(LCPObject, (LCPObject.transform.position + LCPOffset), LCPObject.transform.localRotation);
        newLCP.SetActive(true);
        newLCP.transform.parent = LCPParent.transform;

        TurnLogicGO.GetComponent<TurnLogic>().SetTurnNumber();
    }

    void AddRChopstick()
    {
        // get new offset depending on how many are already spawned
        RCPOffset = new Vector3(-0.05f, -0.1f, 0) * (RCPParent.transform.childCount);

        var newRCP = Instantiate(RCPObject, (RCPObject.transform.position + RCPOffset), RCPObject.transform.localRotation);
        newRCP.SetActive(true);
        newRCP.transform.parent = RCPParent.transform;

        TurnLogicGO.GetComponent<TurnLogic>().SetTurnNumber();

        // ^ MIGHT CRASH PC, LOOK AT TASK MANAGER (NVM LOL)
    }

    void SplitRHand()
    {
        int RCPcount = CPHandlerGO.GetComponent<CPHandler>().GetPlayerRCPcount();
        int tempNo = SplitHandCalc(RCPcount);

        while (tempNo != 0)
        {
            // destroy children from the bottom, then instantiate on L hand
            DestroyImmediate(RCPParent.transform.GetChild(RCPParent.transform.childCount - 1).gameObject);
            AddLChopstick();

            tempNo--;
        }
    }

    void SplitLHand()
    {
        int LCPcount = CPHandlerGO.GetComponent<CPHandler>().GetPlayerLCPcount();
        int tempNo = SplitHandCalc(LCPcount);

        while (tempNo != 0)
        {
            // destroy children from the bottom, then instantiate on L hand
            DestroyImmediate(LCPParent.transform.GetChild(LCPParent.transform.childCount - 1).gameObject);
            AddRChopstick();

            tempNo--;
        }
    }

    int SplitHandCalc(int handCount)
    {
        // if count is divisible by 2, then split evenly
        // if not split 1
        if (handCount % 2 == 0)
        {
            int splitNo = handCount / 2;

            return splitNo;
        }
        else
        {
            int splitNo = handCount % 2;

            return splitNo;
        }
    }
}