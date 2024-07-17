using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CubeGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] cubes;

    [SerializeField]
    private Transform positions;

    private float Timer = 30;

    private List<Transform> availablePositions = new List<Transform>();

    public UnityEvent EndGame;

    private void OnEnable()
    {
        foreach (Transform tmpChild in positions)
        {
            availablePositions.Add(tmpChild);
        }
        StartCoroutine(StartGame());
    }

    private void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer < 0)
        {
            Timer = 0;
        }
    }

    public void GenerateCube()
    {
        Transform tmpRandomPosition = availablePositions[Random.Range(0, availablePositions.Count)];
        Instantiate(cubes[Random.Range(0, cubes.Length)], tmpRandomPosition, false);
    }

    private IEnumerator StartGame()
    {
        while (Timer > 0)
        {
            GenerateCube();
            yield return new WaitForSeconds(1f);
        }

        EndGame.Invoke();
        StopAllCoroutines();
    }
}
