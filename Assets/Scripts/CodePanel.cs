
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CodePanel : MonoBehaviour
{
    
    [SerializeField] private GameObject exitBarrier;
    //Variables for checking if player inputted correct answer 
    public List<int> comboNumstemp;
    private List<int> Digits;
    private string input;
    private int output1, output2, output3, output4;
    [SerializeField]GameObject[] CodePanels;
    [SerializeField]private List<TMP_InputField> inputs;
    private bool digit1Correct, digit2Correct, digit3Correct, digit4Correct;

    // Text for board
    [SerializeField] TMP_Text Board1;
    [SerializeField] TMP_Text Board2;
    [SerializeField] TMP_Text Board3;
    [SerializeField] TMP_Text Board4;
    void Start()
    {
        
        //Placing generated numbers on signs 
        Board1.text = comboNumstemp[0].ToString();
        Board2.text = comboNumstemp[1].ToString();
        Board3.text = comboNumstemp[2].ToString();
        Board4.text = comboNumstemp[3].ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        //Opening code panel UI
        if (other.CompareTag("Player"))
        {
            foreach (var item in CodePanels)
            {
                item.SetActive(true);
            }
            Cursor.lockState = CursorLockMode.Confined;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        //Closing code panel UI
        if (other.CompareTag("Player"))
        {
            foreach (var item in CodePanels)
            {
                item.SetActive(false);
            }
            Cursor.lockState = CursorLockMode.Locked;
        }
        
    }

    

  
    
/// <summary>
///  Checking each number to see if they are correct
/// </summary>

    public void modNumber1(string input1)
    {
        input = input1;
        int.TryParse(input1, out output1);
        if (output1 == comboNumstemp[0] && inputs[0] != null)
        {
            digit1Correct = true;
            inputs[0].enabled = false;
        }
        else
        {
            return;
        }
    }
    public void modNumber2(string input2)
    {
       
        input = input2;
        int.TryParse(input2, out output2);
        if (output2 ==  comboNumstemp[1] && inputs[1] != null)
        {
            digit2Correct = true;
            inputs[1].enabled = false;
        }
        else
        {
            return;
        }
    }
    public void modNumber3(string input3)
    {
       
        input = input3;
        int.TryParse(input3, out output3);
        if (output3 == comboNumstemp[2]&& inputs[2] != null)
        {
            digit3Correct = true;
            inputs[2].enabled = false;
        }
        else
        {
            return;
        }
    }
    public void modNumber4(string input4)
    {
       
        input = input4;
        int.TryParse(input4, out output4);
        if (output4 == comboNumstemp[3]&& inputs[3] != null)
        {
            digit4Correct = true;
            inputs[3].enabled = false;
        }
        else
        {
            return;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        //Opening exit door if correct input is given 
        if (digit1Correct && digit2Correct && digit3Correct && digit4Correct)
        {
            exitBarrier.SetActive(false);
            foreach (var item in CodePanels)
            {
                item.SetActive(false);
            }
        }
       
        else
        {
            return;
        }
        

    }
}
