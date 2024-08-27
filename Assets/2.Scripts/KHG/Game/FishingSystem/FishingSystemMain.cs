using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FishingSystemMain : MonoBehaviour
{
    ItemClass Item = new ItemClass();
    [SerializeField] private Button throwBtn;

    List<int> inventoryList = new List<int>(); // 0 None , 1 �Ȱ��� , 2 �ݰ�
    private int num;
    private string OJname;
    private string Rarity;
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
                SetValue("�ƹ��͵� ����ø��� ���ߴ�..", 0 , 0); //�̸�,��͵�,������ ��ȣ
                break;
            case ItemClass.item.glassess:
                SetValue("������ �Ȱ���" ,1 , 1);
                break;
            case ItemClass.item.vault:
                SetValue("���� ����ִ� �ݰ�", 3 , 2);
                break;
        }
    }
    private void SetValue(string ItemName, int ItemPrice, int ItemNum)
    {
        string value = "0";
        OJname = ItemName;
        Rarity = ItemPrice.ToString();
        if (ItemNum > 0)
        {
            if (ItemNum == 2)
            {
                value = "???";
            }
            else
            {
                value = Rarity.ToString();
            }
        }
        Rarity = value;
        SaveToInventory(ItemName, Rarity, ItemNum);
        print(OJname + ",��͵�:" + Rarity);
        throwBtn.interactable = true;
    }
    private void SaveToInventory(string ItemName,string ItemPrice,int ItemNum)
    {
        if (!(inventoryList.Contains(ItemNum)))
            inventoryList.Add(ItemNum);
        else
            print("�̹�����");
        print(inventoryList.Count);
    }
}
