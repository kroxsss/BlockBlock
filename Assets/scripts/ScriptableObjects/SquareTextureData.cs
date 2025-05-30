using System;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class SquareTextureData : ScriptableObject
{
    [System.Serializable]
    public class TextureData
    {
     public Sprite texture;
     public Config.SquareColor squareColor;
    }
    public int tresholdVal=10;
    private const int StartTresholdVal=100;
    public List<TextureData> activeSquareTextures;
    
    public Config.SquareColor currentColor;
    private Config.SquareColor _nextColor;

    public int GetCurrentColorIndex()
    {
        var currentIndex = 0;

        for (int index = 0; index <activeSquareTextures.Count; index++)
        {
            if (activeSquareTextures[index].squareColor == currentColor)
            {
                currentIndex = index;
            }
        }
        return currentIndex;
    }

    public void UpdateColors(int current_score)
    {
        currentColor = _nextColor;
        var curentColorIndex = GetCurrentColorIndex();

        if (curentColorIndex==activeSquareTextures.Count-1)
        {
            _nextColor = activeSquareTextures[0].squareColor;
        }
        else
        {
            _nextColor = activeSquareTextures[curentColorIndex+1].squareColor;
        }
        tresholdVal = StartTresholdVal+current_score;
    }

    public void SetStartColor()
    {
        tresholdVal = StartTresholdVal;
        currentColor = activeSquareTextures[0].squareColor;
        _nextColor = activeSquareTextures[1].squareColor;
    }

    private void Awake()
    {
        SetStartColor();
    }

    private void OnEnable()
    {
        SetStartColor();
    }
}
