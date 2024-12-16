using System;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Класс, содержащий информацию о всех цветах в игре.
/// </summary>
[Serializable]
public class ColorsProvider
{
    [SerializeField] public Color[] _colors;

    public Color GetColor()
    {
        // Генерируем случайный индекс.
        var index = Random.Range(0, _colors.Length);

        return _colors[index];
    }
}