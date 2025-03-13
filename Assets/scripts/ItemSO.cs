using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{

    [SerializeField] public string name;
    [SerializeField] public string description;
    [SerializeField] public RarityData rarity;

    public  string Name { get { return name; } }
    public string Description { get { return description; } }
    public RarityData Rarity { get { return rarity; } }

    public void printt() {
        Debug.Log(Name);
    }
}
