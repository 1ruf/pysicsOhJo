using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
public class ExplanationSet : MonoBehaviour
{
    [SerializeField] private FishingSystemMain MainSystem;
    [SerializeField] private TMP_Text ITname, ITrarity, ITexplain;

    private string[] itemInformation = { "", 
    /*1*/    "��ö�� ���� �Ȱ����̴�. ���԰� �� �����°� ����.",                                                 //�Ȱ���
    /*2*/    "���κ��� ��¦ ���η��� Ŭ���̴�. �����ִ� �߰ſ�� �Ǽ��� ����Ʈ�ȴ��� Ŭ�� ������� �ǵ��ư���..? �̰� �ٷ� '�������ձ�'..!",                                                 //Ŭ��
    /*3*/    "�������� �ǰ� ���κ��� �����ִ� �ٴ��̴�..",                  //�ٴ�
    /*4*/    "", 
    /*5*/    "", 
    /*6*/    "", 
    /*7*/    "", 
    /*8*/    "", 
    /*9*/    "", 
    /*10*/    "", 
    /*11*/    "", 
    /*12*/    "", 
    /*13*/    "", 
    /*14*/    "", 
    /*15*/    "", 
    /*16*/    "",
    /*17*/    "", 
    /*18*/    "", 
    /*19*/    "", 
    /*20*/    "", 
    /*21*/    "", 
    /*22*/    "", };

    private string nowRarity = "Unknown";
    public void SetValue(int ItemNum, List<int> inventory) //������ ������ ��Ȧ�� �޾ƿ� , ����Ʈ�� ���� �޾ƿ�(������)
    {
        RarityCheck(ItemNum); //�������� ��͵� üũ
        if (inventory.Contains(ItemNum)) //ȹ�� ����Ʈ�� Ŭ���� ��ư�� �������� �ִ��� Ȯ��
        {
            SetText(MainSystem.itemNames[ItemNum], itemInformation[ItemNum]);
        }
        else
        {
            print("������ ���� ����, ��ȣ:" + ItemNum);
            SetText("???", "???");
        }
    }
    private void SetText(string Name,string Explain)
    {
        ITname.text = "�̸�:"+Name;
        ITrarity.text = "��͵�:"+nowRarity;
        ITexplain.text = Explain;
    }
    private void RarityCheck(int CheckNum)
    {
        if (CheckNum > 0 && CheckNum <= 5)
        {
            nowRarity = "common";
        }
        else if (CheckNum > 5 && CheckNum <= 10)
        {
            nowRarity = "uncommon";
        }
        else if (CheckNum > 10 && CheckNum <= 15)
        {
            nowRarity = "rare";
        }
        else if (CheckNum > 15 && CheckNum <= 18)
        {
            nowRarity = "superRare";
        }
        else if (CheckNum > 18 && CheckNum <= 20)
        {
            nowRarity = "legendary";
        }
        else if(CheckNum > 20 && CheckNum <= 22)
        {
            nowRarity = "mythic";
        }
    }
    public void LibrarySet(List<int> inventory)
    {

    }
    public void CloseBtnClicked()
    {
        gameObject.SetActive(false);
    }
}
