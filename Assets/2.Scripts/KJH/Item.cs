using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemSO _itemSo;

    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _itemNameText;
    [SerializeField] private TMP_Text _itemInformationText;
                                
    private void Awake()
    {
        if (_itemSo != null)
        {
            _image = _itemSo.image;
            _itemNameText.text = $"{_itemSo.number}. {_itemSo.name}";
            _itemInformationText.text = _itemSo.magneticMaterialType;
        }
    }
}
