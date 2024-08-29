using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UIElements.Image;

[CreateAssetMenu(fileName = "SO", menuName = "Item" )]
public class ItemSO : ScriptableObject
{
    public int number;
    public UnityEngine.UI.Image image;
    public string name;
    public string explanation;
    public string magneticMaterialType;
}
