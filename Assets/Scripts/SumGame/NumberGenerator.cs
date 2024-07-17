using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class NumberGenerator : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField playerInput;

    [SerializeField]
    private TextMeshProUGUI randomNumbers;

    [SerializeField]
    private TextMeshProUGUI result;

    public UnityEvent wrongNumber;

    private void OnEnable()
    {
        randomNumbers.text = null;
        result.text = null;
        playerInput.text = null;
    }


    public void GenerateNumbers()
    {
        int tmpNum = int.Parse(playerInput.text);
        int tmpResult = 0;
        int tmpAux;
        if (tmpNum <= 0 || tmpNum > 20)
        {
            WrongNumber();
            return;
        }
        else
        {
            for (int i = 0; i < tmpNum; i++) 
            {
                tmpAux = Random.Range(1, 101);
                randomNumbers.text += $"{tmpAux} ";
                tmpResult += tmpAux;
            }
        }
        result.text = $"Sumatoria = {tmpResult}";        
    }


    private void WrongNumber()
    {       
        wrongNumber.Invoke();
        WarningMessage.Instance.SetWarningMessage("Debes ingresar un número entre 1 y 20");
    }
}
