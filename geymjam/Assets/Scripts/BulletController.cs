using UnityEngine;
using UnityEngine.UI;

public class ButtonHoverEffect : MonoBehaviour
{
    private Image buttonImage;
    public Sprite normalSprite; // Beyaz sprite
    public Sprite hoverSprite;  // Sarı sprite

    void Start()
    {
        buttonImage = GetComponent<Image>(); // Butonun Image component'ini al
    }

    public void OnPointerEnter()
    {
        buttonImage.sprite = hoverSprite; // Hover olduğunda sarı görseli al
    }

    public void OnPointerExit()
    {
        buttonImage.sprite = normalSprite; // Çıkıldığında beyaz görseli geri al
    }
}
