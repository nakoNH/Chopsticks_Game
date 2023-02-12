using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondaryInputLogic : MonoBehaviour
{
    [SerializeField]
    private Button AILCPButton;
    [SerializeField]
    private Button AIRCPButton;

    [SerializeField]
    private Button playerLCPButton;
    [SerializeField]
    private Button playerRCPButton;

    private bool SelectedAILCP;
    private bool SelectedAIRCP;

    private bool SelectedPlayerLCP;
    private bool SelectedPlayerRCP;
    
    // Start is called before the first frame update
    void Start()
    {
        SelectedAILCP = false;
        SelectedAIRCP = false;

        SelectedPlayerLCP = false;
        SelectedPlayerRCP = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //LEFT
    public bool GetAILCPSelectedState()
    {
        return SelectedAILCP;
    }
    public void SetAILCPSelectedState()
    {
        SelectedAILCP = !SelectedAILCP;
    }
    //RIGHT
    public bool GetAIRCPSelectedState()
    {
        return SelectedAIRCP;
    }
    public void SetAIRCPSelectedState()
    {
        SelectedAIRCP = !SelectedAIRCP;
    }

    // PLAYER BOOL GETTERS AND SETTERS
    //LEFT
    public bool GetPlayerLCPSelectedState()
    {
        return SelectedPlayerLCP;
    }
    public void SetPlayerLCPSelectedState()
    {
        SelectedPlayerLCP = !SelectedPlayerLCP;
    }
    //RIGHT
    public bool GetPlayerRCPSelectedState()
    {
        return SelectedPlayerRCP;
    }
    public void SetPlayerRCPSelectedState()
    {
        SelectedPlayerRCP = !SelectedPlayerRCP;
    }
}
