using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class CongratulationsWritings : MonoBehaviour
{
    public List<GameObject> writings; 
    void Start()
    {
        GameEvents.ShowCongratulationsWritings += ShowCongratulationsWritings;
    }

    private void OnDisable()
    {
        GameEvents.ShowCongratulationsWritings -= ShowCongratulationsWritings;

    }

    private void ShowCongratulationsWritings()
    {
        var index =UnityEngine.Random.Range(0, writings.Count);
        writings[index].SetActive(true);
    }
}
