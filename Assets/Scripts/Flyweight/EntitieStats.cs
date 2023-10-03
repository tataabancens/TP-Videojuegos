using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EntityStats", menuName = "Stats/EntityStats", order = 0)]
public class EntitieStats : ScriptableObject
{
    [SerializeField] private EntityStatValues _stats;

    public int MaxLife => _stats.MaxLife;    

}

[System.Serializable]
public struct EntityStatValues
{
    public int MaxLife;
}
