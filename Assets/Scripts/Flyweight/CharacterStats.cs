using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CharacterStats", menuName = "Stats/CharacterStats", order = 0)]
public class CharacterStats : EntitieStats
{
    [SerializeField] private CharacterStatsValues _characterStats;

    public float MovementSpeed => _characterStats.MovementSpeed;
    public float RotationSpeed => _characterStats.RotationSpeed;
}

[System.Serializable]
public struct CharacterStatsValues
{
    public float MovementSpeed;
    public float RotationSpeed;

}
