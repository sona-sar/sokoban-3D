using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Sprite buttonNormal;
    [SerializeField] private Sprite buttonHovered;
    
    private Image buttonImage;

    void Start()
    {
        buttonImage = GetComponent<Image>();
        buttonImage.sprite = buttonNormal;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.sprite = buttonHovered;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.sprite = buttonNormal;
    }
}