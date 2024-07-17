using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CubeGameManager : MonoBehaviour
{
    public static CubeGameManager Instance
    {
        get; private set;
    }

    [SerializeField]
    private GameObject FinalCount;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void EndGame()
    {
        FinalCount.SetActive(true);
        Counter.Instance.FinalCount();
    }
}
