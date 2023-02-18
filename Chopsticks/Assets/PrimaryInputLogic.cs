using System.Collections;
using TMPro;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrimaryInputLogic : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI PIText;

    [SerializeField]
    private Button PlayerLCPButton;
    [SerializeField]
    private Button PlayerRCPButton;

    private bool SelectedLCP;
    private bool SelectedRCP;


    // Start is called before the first frame update
    void Start()
    {
        SelectedLCP = false;
        SelectedRCP = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool GetLCPSelectedState()
    {
        return SelectedLCP;
    }
    public void SetLCPSelectedState()
    {
        SelectedLCP = !SelectedLCP;
    }

    public bool GetRCPSelectedState()
    {
        return SelectedRCP;
    }
    public void SetRCPSelectedState()
    {
        SelectedRCP = !SelectedRCP;
    }

    public void SetPIText(string x)
    {
        PIText.text = x;
    }

}
