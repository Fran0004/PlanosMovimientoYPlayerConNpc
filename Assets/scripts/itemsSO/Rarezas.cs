using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RarityData
{
    public string rarityName; // Nombre (Ej: "Común", "Épico")
    public float probability; // Probabilidad (Ej: 0.60 = 60%)
    public Color rarityColor; // Color visual para la rareza
}

[CreateAssetMenu(fileName = "RarityDatabase", menuName = "Game/Rarity Database")]
public class RarityDatabase : ScriptableObject
{
    public List<RarityData> rarities; // Lista de rarezas predefinidas

    public RarityData GetRarityByName(string name)
    {
        return rarities.Find(r => r.rarityName == name);
    }
}