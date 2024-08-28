using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FishingSystemMain : MonoBehaviour
{
    [SerializeField] private Button throwBtn;

    List<int> inventoryList = new List<int>(); // 0 None , 1 �Ȱ��� , 2 �ݰ� , 3 ����� ���� , 4 �ڵ��� ��¦ , 5 ������ , 6 ö�� , 7 "ö" �� (������ �󱼻���) , 8 Ŭ�� , 9 �ݰ� , 10 �ٴ� , 11 �μ��� å�� , 
    private string[] itemNames = { /*common(5)*/"�ƹ��͵� ����", "�Ȱ���", "Ŭ��", "�ٴ�", "������(��¦)", "��",/*uncommon(5)*/"�������� �Ҿ���� �̾���", "�μ��� ����", "������ �߱��� ������", "�콼 ����", "���� ������",/*rare(5)*/"�����̰� ���� ��ġ", "�콼 ��Į", "���� BMW ��Ű", "�ڹ���", "RsW6����",/*����� ����(3)*/"����� ����", "�ݼӲ����� ���� å", "��¦�� ��ܳ��� �ڵ���",/*legendary(2)*/"�ɱ׶�� Ÿ��ź �����", "Ÿ��Ÿ��ȣ",/*Mythic*/"\"ö\"��", "����ӽ��� �θ� �Ͻ�Ʈ�� ����ǿ�" };
    private string OJname;
    private string OJrarity;
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
        throwBtn.gameObject.SetActive(false);
        throwBtn.interactable = false;
        MagnetThrowed();
    }
    private void MagnetThrowed()
    {
        //���� ������ �ִϸ��̼�
        //���� ����ø��� �ൿ?
        if (/*�� �ൿ�� True �̸�*/true)
        {
            SetRandomItem();
        }
        else
        {
            print("���� ����");
        }
    }
    private void SetRandomItem()
    {
        SetValue();
    }
    private void SetValue()
    {
        string ItemName = "null";
        int ItemNum = 0;
        float randomValue = Random.Range(0f, 100f);
        OJname = ItemName;
        if (randomValue <= 35)
        {
            OJrarity = "common";
            ItemNum = UnityEngine.Random.Range(1, 11);
        }
        else if (randomValue <= 65)
        {
            // Uncommon: 6-10 (cumulative 30% range)
            OJrarity = "uncommon";
            ItemNum = UnityEngine.Random.Range(6, 11); // Random number between 6 and 10
        }
        else if (randomValue <= 85)
        {
            // Rare: 11-15 (cumulative 20% range)
            OJrarity = "rare";
            ItemNum = UnityEngine.Random.Range(11, 16); // Random number between 11 and 15
        }
        else if (randomValue <= 95)
        {
            // Epic: 16-18 (cumulative 10% range)
            OJrarity = "super rare";
            ItemNum = UnityEngine.Random.Range(16, 19); // Random number between 16 and 18
        }
        else if (randomValue <= 99)
        {
            // Legendary: 19-20 (cumulative 4% range)
            OJrarity = "mythic";
            ItemNum = UnityEngine.Random.Range(19, 21); // Random number between 19 and 20
        }
        else
        {
            // Mythic: 21 (cumulative 1% range)
            OJrarity = "legend ";
            ItemNum = UnityEngine.Random.Range(21, 23);
        }

        #region ����
        /*if (ItemNum > 0 && ItemNum <= 10)
        {
            OJrarity = "common"; //35%
        }
        else if (ItemNum > 5 && ItemNum <= 10)
        {
            OJrarity = "uncommon"; //30%
        }
        else if (ItemNum > 10 && ItemNum <= 15)
        {
            OJrarity = "rare"; // 20%
        }
        else if (ItemNum > 15 && ItemNum <= 18)
        {
            OJrarity = "epic"; // 10%
        }
        else if (ItemNum > 18 && ItemNum <= 20)
        {
            OJrarity = "Legendary"; //4%
        }
        else if (ItemNum == 21)
        {
            OJrarity = "Mythic"; //1%
        }
        else
        {
            OJrarity = "error";
            OJname = "error";
        }*/
        #endregion

        SaveToInventory(ItemName, ItemNum);
        OJname = itemNames[ItemNum];
        print(OJname + ",��͵�:" + OJrarity);
        throwBtn.gameObject.SetActive(true);
        throwBtn.interactable = true;
    }
    private void SaveToInventory(string ItemName,int ItemNum)
    {
        if (!(inventoryList.Contains(ItemNum)))
            inventoryList.Add(ItemNum);
        else
            print("�̹�����");
        print(inventoryList.Count);
    }
}
