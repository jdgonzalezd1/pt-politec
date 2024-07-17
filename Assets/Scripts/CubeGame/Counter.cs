using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public static Counter Instance
    {
        get; private set;
    }

    [SerializeField]
    private TextMeshProUGUI yellowCounter;

    [SerializeField]
    private TextMeshProUGUI redCounter;

    [SerializeField]
    private TextMeshProUGUI blueCounter;

    [SerializeField]
    private TextMeshProUGUI finalCounter;


    private int yellowCubes;

    private int redCubes;

    private int blueCubes;

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

    private void OnEnable()
    {
        ResetCounters();
    }

    private void Update()
    {
        yellowCounter.text = $"Amarillos\n{yellowCubes}";
        blueCounter.text = $"Azules\n{blueCubes}";
        redCounter.text = $"Rojos\n{redCubes}";
    }

    public void AddCount(CubeColor color)
    {
        switch (color)
        {
            case CubeColor.Yellow:
                yellowCubes++;
                break;
            case CubeColor.Red:
                redCubes++;
                break;
            case CubeColor.Blue:
                blueCubes++;
                break;
        }
    }

    public void FinalCount()
    {
        finalCounter.text = $"Game Over\n" +
            $"Blue score: {blueCubes} Yellow score: {yellowCubes} Red score: {redCubes}\n" +
            $"Total score = {yellowCubes + blueCubes + redCubes}";
    }

    public void ResetCounters()
    {
        blueCubes = 0;
        redCubes = 0;
        yellowCubes = 0;
    }
}
