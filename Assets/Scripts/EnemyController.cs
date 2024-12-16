using System;
using System.Linq;
using UnityEngine;

/// <summary>
/// Класс врага - цилиндра.
/// </summary>
public class EnemyController : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    private GiftsManager _giftsManager;
   
    private Material _material;
    private Color _color;

    private void Awake()
    {
        _giftsManager = FindObjectOfType<GiftsManager>();
    }

    public void Initialize(Color color)
    {
        // Сохраняем colored материал
        var materials = _renderer.materials;
        _material = materials.First(material => material.name.Contains(GlobalConstants.COLORED_MATERIAL));
        
        _material.color = color;
        _color = color;
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        // Если столкнувшийся с врагом объект - это Player
        if (collision.gameObject.TryGetComponent<Player>(out var player))
        {
            if (gameObject.CompareTag("RedGift") && _material.color == collision.gameObject.GetComponent<Renderer>().material.color)
            {
                _giftsManager.GiftCollected("Red");
            }
            else if (gameObject.CompareTag("BlueGift") && _material.color == collision.gameObject.gameObject.GetComponent<Renderer>().material.color)
            {
                _giftsManager.GiftCollected("Blue");
            }
            else if (gameObject.CompareTag("GreenGift")&& _material.color == collision.gameObject.GetComponent<Renderer>().material.color)
            {
                _giftsManager.GiftCollected("Green");
            }
            // Если цвет врага совпадает с цветом игрока
            if (player.Color == _color)
            {
                // Разрушаем врага
                Destroy(gameObject);
            }

            
        }
    }
}