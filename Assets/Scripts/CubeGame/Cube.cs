using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Cube : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private CubeColor cubeColor;

    private void OnEnable()
    {
        StartCoroutine(DisableCountDown());
    }
    public void OnPointerClick(PointerEventData eventData)
    {

        Counter.Instance.AddCount(cubeColor);
        gameObject.SetActive(false);
        print("Hey");
        StopAllCoroutines();
    }

    private IEnumerator DisableCountDown()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }
}

public enum CubeColor
{
    Yellow,
    Blue,
    Red
}
