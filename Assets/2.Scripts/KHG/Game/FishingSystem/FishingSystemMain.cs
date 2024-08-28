using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FishingSystemMain : MonoBehaviour
{
    [SerializeField] private Button throwBtn, LibBtn;
    [SerializeField] private RectTransform LibMain;

    List<int> inventoryList = new List<int>(); // 0 None , 1 �Ȱ��� , 2 �ݰ� , 3 ����� ���� , 4 �ڵ��� ��¦ , 5 ������ , 6 ö�� , 7 "ö" �� (������ �󱼻���) , 8 Ŭ�� , 9 �ݰ� , 10 �ٴ� , 11 �μ��� å�� , 
    private string[] itemNames = { /*common(5)*/"�ƹ��͵� ����", "�Ȱ���", "Ŭ��", "�ٴ�", "������(��¦)", "��",/*uncommon(5)*/"�������� �Ҿ���� �̾���", "�μ��� ����", "������ �߱��� ������", "�콼 ����", "���� ������",/*rare(5)*/"�����̰� ���� ��ġ", "�콼 ��Į", "���� BMW ��Ű", "�ڹ���", "RsW6����",/*����� ����(3)*/"����� ����", "�ݼӲ����� ���� å", "��¦�� ��ܳ��� �ڵ���",/*legendary(2)*/"�ɱ׶�� Ÿ��ź �����", "Ÿ��Ÿ��ȣ",/*Mythic*/"\"ö\"��", "����ӽ��� �θ� �Ͻ�Ʈ�� ����ǿ�" };
    private string OJname;
    private string OJrarity;
    private bool IsThrowed, IsLibOpend, LibBtnCool;
    private void Start()
    {
        LibMain.anchoredPosition = new Vector2(1700, 0);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsLibOpend == false)
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
        else if (Input.GetKeyDown(KeyCode.E))
        {
            LibraryBtnClicked();
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
        float randomValue = Random.Range(0f, 100.0f);
        OJname = ItemName;
        if (randomValue <= 40)
        {
            OJrarity = "common";                                                             //40
            ItemNum = UnityEngine.Random.Range(1, 6);
        }
        else if (randomValue <= 75)
        {
            OJrarity = "uncommon";                                                           //35
            ItemNum = UnityEngine.Random.Range(6, 11); // Random number between 6 and 10
        }
        else if (randomValue <= 90)
        {
            OJrarity = "rare";                                                               //15
            ItemNum = UnityEngine.Random.Range(11, 16); // Random number between 11 and 15
        }
        else if (randomValue <= 97.9)
        {
            // Epic: 16-18 (cumulative 10% range)
            OJrarity = "super rare";                                                         //7.9
            ItemNum = UnityEngine.Random.Range(16, 19); // Random number between 16 and 18
        }
        else if (randomValue <= 99.9)
        {
            // Legendary: 19-20 (cumulative 4% range)
            OJrarity = "legend";                                                             //2
            ItemNum = UnityEngine.Random.Range(19, 21); // Random number between 19 and 20
        }
        else 
        {
            // Mythic: 21 (cumulative 1% range)
            OJrarity = "mythic";                                                            //0.1
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
    public void LibraryBtnClicked()
    {
        if (LibBtnCool == false)
        {
            if (IsLibOpend)
            {
                LibDisappear();
                IsLibOpend = false;
            }
            else
            {
                LibAppear();
                throwBtn.interactable = false;
                IsLibOpend = true;
            }
        }
    }
    private void LibAppear()
    {
        StartCoroutine(LibBtnCooltimeChecker(1f));
        LibMain.DOAnchorPosX(420, 1).SetEase(Ease.OutBack);
    }
    private void LibDisappear()
    {
        StartCoroutine(LibBtnCooltimeChecker(1f));
        LibMain.DOAnchorPosX(1700, 1).SetEase(Ease.InBack).OnComplete(() => throwBtn.interactable = true);
    }
    private IEnumerator LibBtnCooltimeChecker(float t)
    {
        LibBtnCool = true;
        LibBtn.interactable = false;
        yield return new WaitForSeconds(t);
        LibBtnCool = false;
        LibBtn.interactable = true;
    }
}
