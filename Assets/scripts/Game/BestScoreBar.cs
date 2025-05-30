using System;
using UnityEngine;
using UnityEngine.UI;

public class BestScoreBar : MonoBehaviour
{
   public Image FillInImage;
   public Text bestScoreText;

   private void OnEnable()
   {
      GameEvents.UpdateBestScoreBar += UpdateBestScoreBar;
   }

   private void OnDisable()
   {
      GameEvents.UpdateBestScoreBar -= UpdateBestScoreBar;
      
   }

   private void UpdateBestScoreBar(int currentScore, int bestScore)
   {
      float currentPercentage = (float)currentScore / (float)bestScore;
      FillInImage.fillAmount = currentPercentage;
      bestScoreText.text = bestScore.ToString();
   }
   
}
