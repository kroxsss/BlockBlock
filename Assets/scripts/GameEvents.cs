using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static Action<bool> GameOver;
    public static Action<int> AddScores;
    public static Action CheckIfShapeCanBePlaced;

    public static Action MoveShapeToStartPosition;

    public static Action RequestNewShape;

    public static Action SetShapeInactive;
    
    public static Action<int, int> UpdateBestScoreBar;

    public static Action<Config.SquareColor> UpdateSquareColor;
    
    public static Action ShowCongratulationsWritings;

    public static Action<Config.SquareColor> ShowBonusScreen;
}
