using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class GridSquare : MonoBehaviour
{
    public Image hooverImage;
    public Image activeImage;
    public Image normalImage;
    public List<Sprite> normalImages;

    private Config.SquareColor currentSquareColor_ = Config.SquareColor.NotSet;

    public Config.SquareColor GetCurrentColor()
    {
        return currentSquareColor_;
    }

    public bool selected { get; set; }
    public int SquareIndex { get; set; }
    public bool squareOccupied { get; set; }

    void Start()
    {
        selected = false;
        squareOccupied = false;
    }

    public bool CanWeUseThisSquare()
    {
        return hooverImage.gameObject.activeSelf;
    }

    public void PlaceShapeOnBoard(Config.SquareColor color)
    {
        currentSquareColor_ = color;
        ActivateSquare();
    }

    public void ActivateSquare()
    {
        hooverImage.gameObject.SetActive(false);
        activeImage.gameObject.SetActive(true);
        Color c = activeImage.color;
        activeImage.color = new Color(c.r, c.g, c.b, 1f);
        selected = true;
        squareOccupied = true;
    }

    public void Deactivate()
    {
        currentSquareColor_ = Config.SquareColor.NotSet;
        activeImage.DOFade(0f, 0.5f).OnComplete(() => { activeImage.gameObject.SetActive(false); });
    }

    public void ClearOccupied()
    {
        currentSquareColor_ = Config.SquareColor.NotSet;
        selected = false;
        squareOccupied = false;
    }

    public void SetImage(bool setFirsImage)
    {
        normalImage.GetComponent<Image>().sprite = setFirsImage ? normalImages[1] : normalImages[0];
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (squareOccupied == false)
        {
            selected = true;
            hooverImage.gameObject.SetActive(true);
        }
        else if (collision.GetComponent<ShapeSquare>() != null)
        {
            collision.GetComponent<ShapeSquare>().SetOccupied();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        selected = true;

        if (squareOccupied == false)
        {
            hooverImage.gameObject.SetActive(true);
        }
        else if (collision.GetComponent<ShapeSquare>() != null)
        {
            collision.GetComponent<ShapeSquare>().SetOccupied();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (squareOccupied == false)
        {
            selected = false;
            hooverImage.gameObject.SetActive(false);
        }
        else if (collision.GetComponent<ShapeSquare>() != null)
        {
            collision.GetComponent<ShapeSquare>().UnSetOccupied();
        }
    }
}