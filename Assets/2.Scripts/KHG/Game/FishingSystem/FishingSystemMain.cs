using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FishingSystemMain : MonoBehaviour
{
    ItemClass Item = new ItemClass();
    [SerializeField] private Button throwBtn;

    List<int> inventoryList = new List<int>(); // 0 None , 1 안경테 , 2 금고
    private int num;
    private string OJname;
    private string OJprice;
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
                SetValue("아무것도 끌어올리지 못했다..", 0 , 0);
                break;
            case ItemClass.item.glassess:
                SetValue("망가진 안경테" ,5 , 1);
                break;
            case ItemClass.item.vault:
                SetValue("무언가 들어있는 금고", 0 , 2);
                break;
        }
    }
    private void SetValue(string ItemName, int ItemPrice, int ItemNum)
    {
        string value = "0";
        OJname = ItemName;
        OJprice = ItemPrice.ToString();
        if (ItemNum > 0)
        {
            if (ItemNum == 2)
            {
                value = "???";
            }
            else
            {
                value = OJprice.ToString();
            }
        }
        OJprice = value;
        SaveToInventory(ItemName, OJprice, ItemNum);
        print(OJname + ",가격:" + OJprice);
        throwBtn.interactable = true;
    }
    private void SaveToInventory(string ItemName,string ItemPrice,int ItemNum)
    {
        if (!(inventoryList.Contains(ItemNum)))
            inventoryList.Add(ItemNum);
        else
            print("이미있음");
        print(inventoryList.Count);
    }
}
