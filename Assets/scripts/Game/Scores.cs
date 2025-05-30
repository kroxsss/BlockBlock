using System;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class BestScoreData
{
    public int score = 0;
}
public class Scores : MonoBehaviour
{
    public SquareTextureData squareTextureData;
    public Text scoreText;
    public Text popScoreText;
    
    public bool newBestScores = false;
    public BestScoreData bestScores_ = new BestScoreData();
    public int currentScores_;

    private string bestScoreKey_ = "bsdat";
    

    private void Awake()
    {
        if (BinaryDataStream.Exists(bestScoreKey_))
        {
            StartCoroutine(ReadDataFile());
        }
    }

    private IEnumerator ReadDataFile()
    {
        bestScores_ = BinaryDataStream.Read<BestScoreData>(bestScoreKey_);
        yield return new WaitForEndOfFrame();
        GameEvents.UpdateBestScoreBar(currentScores_,bestScores_.score);

    }

    void Start()
    {
        currentScores_ = 0;
        newBestScores = false;
        squareTextureData.SetStartColor();
        UpdateScoreText();
    }

    private void OnEnable()
    {
        GameEvents.AddScores += AddScores;
        GameEvents.GameOver += SaveBestScores;
    }

    private void OnDisable()
    {
        GameEvents.AddScores -= AddScores;
        GameEvents.GameOver -= SaveBestScores;

    }

    public void SaveBestScores(bool newBestScores)
    {
        BinaryDataStream.Save<BestScoreData>(bestScores_,bestScoreKey_);
    }

    private void AddScores(int score)
    {
        currentScores_ += score;
        if (currentScores_>bestScores_.score)
        {
            newBestScores = true;
            bestScores_.score = currentScores_;
            SaveBestScores(true);
        }
        UpdateSquareColor();
        GameEvents.UpdateBestScoreBar(currentScores_,bestScores_.score);
        UpdateScoreText();
    }

    private void UpdateSquareColor()
    {
        if (GameEvents.UpdateSquareColor!=null && currentScores_>=squareTextureData.tresholdVal)
        {
            squareTextureData.UpdateColors(currentScores_);
            GameEvents.UpdateSquareColor(squareTextureData.currentColor);
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = currentScores_.ToString();
        popScoreText.text = currentScores_.ToString();
        
    }
}