using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CPHandler : MonoBehaviour
{
/*    [SerializeField]
    private GameObject playerCPObject;
    [SerializeField]
    private GameObject aiCPObject;*/

    private int[] playerCPcount;
    private int[] aiCPcount;

    [SerializeField]
    private GameObject playerCountTextGO;

    [SerializeField]
    private GameObject aiCountTextGO;

    // Start is called before the first frame update
    void Start()
    {
        playerCPcount = new int[1];
        aiCPcount = new int[1];

        // init array of 2 size, [1, 1]
        playerCPcount = new int[] { 1, 1 };
        aiCPcount = new int[] { 1, 1 };
    }

    // Update is called once per frame
    void Update()
    {
        playerCountTextGO.transform.GetComponent<TextMeshProUGUI>().text
            = "Player hand count: " + playerCPcount[0] + ", " + playerCPcount[1];

        aiCountTextGO.transform.GetComponent<TextMeshProUGUI>().text
            = "AI hand count: " + aiCPcount[0] + ", " + aiCPcount[1];
    }

    public int GetPlayerLCPcount()
    {
        return playerCPcount[0];
    }

    public int GetPlayerRCPcount()
    {
        return playerCPcount[1];
    }

    public void SetPlayerCPcount(int L, int R)
    {
        playerCPcount[0] = L;
        playerCPcount[1] = R;
    }

    public int GetAILCPcount() 
    {
        return aiCPcount[0];
    }
    
    public int GetAIRCPcount() 
    {
        return aiCPcount[1];
    }

    public void SetAICPcount(int L, int R)
    {
        aiCPcount[0] = L;
        aiCPcount[1] = R;
    }
}
