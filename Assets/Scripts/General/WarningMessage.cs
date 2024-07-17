using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WarningMessage : MonoBehaviour
{
    public static WarningMessage Instance
    {
        get; private set;
    }

    [SerializeField]
    private TextMeshProUGUI textMessage;

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
        StartCoroutine(DisableCountdown());
    }

    private IEnumerator DisableCountdown()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }

    public void SetWarningMessage(string message)
    {
        textMessage.text = $"ADVERTENCIA\n{message}";
        gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        textMessage.text = string.Empty;
    }
}
