using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColorBase : MonoBehaviour
{
    public Color color;
    public Player myPlayer;

    [Header("References")]
    public Image uiImage;
    
    private void OnValidate()
    {
        uiImage = GetComponent<Image>();
    }
    
    void Start()
    {
        uiImage.color = color; 
    }

    void Update()
    {
        
    }

    public void OnClick() 
    {
        myPlayer.ChangeColor(color);
    }
}
