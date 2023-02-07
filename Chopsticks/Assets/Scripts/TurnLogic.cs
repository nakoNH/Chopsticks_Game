using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurnLogic : MonoBehaviour
{
    [SerializeField]
    private GameObject turnNumberText;

    private int turnNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        { 
            turnNumber++;
        }

        turnNumberText.transform.GetComponent<TextMeshProUGUI>().text = "Turn no: " + turnNumber;
    }

    public int GetTurnNumber()
    {
       return turnNumber;
    }

    public void SetTurnNumber()
    {
        turnNumber++;
    }
}
