using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    [SerializeField] private GameObject ringRed;

    private void Start()
    {
        StartCoroutine(ChangeColor());
    }

    private IEnumerator ChangeColor()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            ringRed.SetActive(false);
            yield return new WaitForSeconds(2f);
            ringRed.SetActive(true);
        }
    }
}
