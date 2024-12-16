using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GiftsManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _redGiftText;  
    [SerializeField] private TextMeshProUGUI _greenGiftText;
    [SerializeField] private TextMeshProUGUI _blueGiftText;
    
    private int _redGiftCount = 0;
    private int _blueGiftCount = 0;
    private int _greenGiftCount = 0;

    private void Start()
    {
        // Подсчитываем подарки при старте игры
        CountGiftsOnField();
        UpdateGiftUI();
    }

    private void CountGiftsOnField()
    {
        // Подсчитываем количество подарков по тегам
        _redGiftCount = GameObject.FindGameObjectsWithTag("RedGift").Length;
        _blueGiftCount = GameObject.FindGameObjectsWithTag("BlueGift").Length;
        _greenGiftCount = GameObject.FindGameObjectsWithTag("GreenGift").Length;
    }

    public void GiftCollected(string giftColor)
    {
        // Уменьшаем счетчик при сборе подарка
        if (giftColor == "Red") _redGiftCount--;
        else if (giftColor == "Blue") _blueGiftCount--;
        else if (giftColor == "Green") _greenGiftCount--;

        UpdateGiftUI();
    }

    private void UpdateGiftUI()
    {
        // Обновляем текст интерфейса
        _redGiftText.text = _redGiftCount.ToString();
        _blueGiftText.text = _blueGiftCount.ToString();
        _greenGiftText.text = _greenGiftCount.ToString();
    }
}
