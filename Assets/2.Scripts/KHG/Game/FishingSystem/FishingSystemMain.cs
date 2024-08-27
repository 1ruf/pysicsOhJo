using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FishingSystemMain : MonoBehaviour
{
    ItemClass Item = new ItemClass();
    [SerializeField] private Button throwBtn;

    List<string> inventoryList = new List<string>();
    private int num;
    private string OJname;
    private float OJprice;
    private bool IsThrowed;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsThrowed)
            {
                print("현재 자석 상태 : 던져짐");
            }
            else
            {
                ThrowBtnClicked();
            }
        }
    }
    public void ThrowBtnClicked()
    {
        throwBtn.interactable = false;
        MagnetThrowed();
    }
    private void MagnetThrowed()
    {
        //대충 전지는 애니메이션
        SetRandomItem();
    }
    private void SetRandomItem()
    {
        int num = Random.Range(0, 4);//ENUM 길이);
        switch (Item.SetItem(num))
        {
            case ItemClass.item.None:
                SetValue("아무것도 끌어올리지 못했다..", 0);
                break;
            case ItemClass.item.glassess:
                SetValue("망가진 안경테" ,5);
                break;
            case ItemClass.item.vault:
                SetValue("무언가 들어있는 금고", -7);
                break;
        }
    }
    private void SetValue(string ItemName, int ItemPrice)
    {
        string value = "Unknown";
        OJname = ItemName;
        OJprice = ItemPrice;
        if (OJprice >= 0)
        {
            value = OJprice.ToString();
        }
        else if (OJprice == -7)
        {
            value = "???";
        }
        else if(OJprice < 0)
        {
            print(ItemName + ItemPrice);
            OJname = "ERROR";
            value = "ERROR";
        }
        SaveToInventory(ItemName, ItemPrice);
        print(OJname + ",가격:" + value);
        throwBtn.interactable = true;
    }
    private void SaveToInventory(string ItemName,int ItemPrice)
    {
        inventoryList.Add(ItemName);
        print(inventoryList);
    }
}
