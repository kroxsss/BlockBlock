using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonEffects : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private Image buttonImage;
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite hoverSprite;
    [SerializeField] private Sprite selectedSprite;
    [SerializeField] private Sprite disabledSprite;

    private bool _isDisabled = false;


    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!_isDisabled)
            buttonImage.sprite = hoverSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPointerExit");

        if (!_isDisabled)
            buttonImage.sprite = normalSprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnPointerClick");

        if (!_isDisabled)
            buttonImage.sprite = selectedSprite;
    }

    public void SetDisabled(bool disabled)
    {
        Debug.Log("SetDisabled");

        _isDisabled = disabled;
        buttonImage.sprite = _isDisabled ? disabledSprite : normalSprite;
    }
}