
using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CodePanel : MonoBehaviour
{
    
    [SerializeField] private GameObject exitBarrier;
    //Variables for checking if player inputted correct answer 
    public List<int> comboNumstemp;
    private List<int> Digits;
    private string input;
    private bool inArea; 
    private int output1, output2 , output3, output4;
    [SerializeField] private TextMeshProUGUI instructionsMid, instructionsTopRight; 
    [SerializeField]GameObject[] CodePanels;
    [SerializeField] private Image map;
    [SerializeField]private List<TMP_InputField> inputs;
    private bool digit1Correct, digit2Correct, digit3Correct, digit4Correct;
    private bool isClicked;

    // Text for board
    [SerializeField] TMP_Text Board1;
    [SerializeField] TMP_Text Board2;
    [SerializeField] TMP_Text Board3;
    [SerializeField] TMP_Text Board4;
    [SerializeField]CinemachineInputProvider inputProvider;
    void Start()
    {
        //Placing generated numbers on signs 
        Board1.text = comboNumstemp[0].ToString();
        Board2.text = comboNumstemp[1].ToString();
        Board3.text = comboNumstemp[2].ToString();
        Board4.text = comboNumstemp[3].ToString();
    }
    private void OnTriggerStay(Collider other)
    {
        //Opening code panel UI
        if (other.CompareTag("Player"))
        {
            inArea = true;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        //Closing code panel UI
        if (other.CompareTag("Player"))
        {
            inArea = false;
            CloseCodePanel();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            
        }
        
    }

    

  
    
/// <summary>
///  Checking each number to see if they are correct
/// </summary>

    public void modNumber1(string input1)
    {
        input = input1;
        int.TryParse(input1, out output1);
        print(output1);
        if (output1 == comboNumstemp[0] && inputs[0] != null)
        {
            digit1Correct = true;
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
       
       
     
        

    }

    public void OpenCloseCodePanel()
    {
        if (!isClicked)
        {
            isClicked = true;
            print(true);
            if (inArea && isClicked)
            {
                inputProvider.enabled = false;

                foreach (var item in CodePanels)
                {
                    item.SetActive(true);
                }

                map.enabled = false;
                Cursor.lockState = CursorLockMode.Confined;
                return;
            }
            if (!inArea)
            {
                foreach (var item in CodePanels)
                {
                    item.SetActive(false);
                }
                map.enabled = true;
                inputProvider.enabled = true;
                isClicked = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
      
        }
    }

    public void CloseCodePanel()
    {
        if (inArea && isClicked || !inArea)
        {
            isClicked = false;
            map.enabled = true;
            inputProvider.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            foreach (var item in CodePanels)
            {
                item.SetActive(false);
            }
        }
        
    }

    public void Input0()
    {
        for (int i = 0; i < inputs.Count; i++)
        {
            if (inputs[i].text.Length != 1|| inputs[i].text == null)
            {
                inputs[i].text = "0";
                return;
            }
        }
    }
    public void Input1()
    {
        for (int i = 0; i < inputs.Count; i++)
        {
            if (inputs[i].text.Length != 1 || inputs[i].text == null)
            {
                inputs[i].text = "1";
                return;
            }
        }
    }
    public void Input2()
    {
        for (int i = 0; i < inputs.Count; i++)
        {
            if (inputs[i].text.Length != 1|| inputs[i].text == null)
            {
                inputs[i].text = "2";
                return;
            }
        }
    }
    public void Input3()
    {
        for (int i = 0; i < inputs.Count; i++)
        {
            if (inputs[i].text.Length != 1|| inputs[i].text == null)
            {
                inputs[i].text = "3";
                return;
            }
        }
    }
    public void Input4()
    {
        for (int i = 0; i < inputs.Count; i++)
        {
            if (inputs[i].text.Length != 1 )
            {
                inputs[i].text = "4";
                return;
            }
        }
    }
     public void Input5()
    {
        for (int i = 0; i < inputs.Count; i++)
        {
            if (inputs[i].text.Length != 1)
            {
                inputs[i].text = "5";
                return;
            }
        }
        
    }
    public void Input6()
    {
        for (int i = 0; i < inputs.Count; i++)
        {
            if (inputs[i].text.Length != 1)
            {
                inputs[i].text = "6";
                return;
            }
        }
        
    }
    public void Input7()
    {
        for (int i = 0; i < inputs.Count; i++)
        {
            if (inputs[i].text.Length != 1 )
            {
                inputs[i].text = "7";
                return;
            }
        }
        
    }
    public void Input8()
    {
        for (int i = 0; i < inputs.Count; i++)
        {
            if (inputs[i].text.Length != 1)
            {
                inputs[i].text = "8";
                return;
            }
        }
        
    }
    public void Input9()
    {
        for (int i = 0; i < inputs.Count; i++)
        {
            if (inputs[i].text.Length != 1 )
            {
                inputs[i].text = "9";
                return;
            }
        }
            
        
    }
         public void EnterCode()
         {
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
                     for (int i = 0; i < inputs.Count; i++)
                     {
                         inputs[i].text = "";
                        print(inputs[i].text.Length); 
                     }

                     output1 = 0;
                     output2 = 0;
                     output3 = 0;
                     output4 = 0;
                     instructionsMid.text = " Wrong Code, reenter your code!";
              }
                
         }

     






}
