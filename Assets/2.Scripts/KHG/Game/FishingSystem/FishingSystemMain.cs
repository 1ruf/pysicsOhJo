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
                print("���� �ڼ� ���� : ������");
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
        //���� ������ �ִϸ��̼�
        SetRandomItem();
    }
    private void SetRandomItem()
    {
        int num = Random.Range(0, 4);//ENUM ����);
        switch (Item.SetItem(num))
        {
            case ItemClass.item.None:
                SetValue("�ƹ��͵� ����ø��� ���ߴ�..", 0);
                break;
            case ItemClass.item.glassess:
                SetValue("������ �Ȱ���" ,5);
                break;
            case ItemClass.item.vault:
                SetValue("���� ����ִ� �ݰ�", -7);
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
        print(OJname + ",����:" + value);
        throwBtn.interactable = true;
    }
    private void SaveToInventory(string ItemName,int ItemPrice)
    {
        inventoryList.Add(ItemName);
        print(inventoryList);
    }
}
