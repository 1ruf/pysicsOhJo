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
    [SerializeField] private Image itemImage;

    private string[] itemInformation = { "", 
    /*1*/    "�Ȱ��� ������ ��û ���̴�. �Ӻ� Ʈ���̴��̶� �߳�����.",                                                 //�Ȱ���
    /*2*/    "���κ��� ��¦ ���η��� Ŭ���̴�. ���� ���������� �������� �� ����...�ٸ����� ���� ��������?",                                                 //Ŭ��
    /*3*/    "������, �Ǽ��� ��ģ�� ����.. ���� �ҵ����� �� �����ΰ�..?",                  //�ٴ�
    /*4*/    "�̰͸����δ� ������ �ִ°� ����. ���� �����ڸ� ���ø�� ����?", 
    /*5*/    "�Ը��� ���̴�. �ƴϸ� �������� ��׷� �� �ɱ�? �Ͽ�ư ��û ������ �����.", 
    /*6*/    "ģ���� ���ߴ� �̾����� �̰��ΰ�?", 
    /*7*/    "�պκ��� �μ��� �ִ� ���� �귣���� �����̴�. �μ��� �κп��� �̻� �ڱ��� �ִ°� ����.", 
    /*8*/    "�������� �帴�ϰ� ���� �����ִ�...¥���...5�� ������ ����....������ �ִ°��� ��������̴�.", 
    /*9*/    "���κ��� ���� �� �����̴�. ��¦�� ������ �Ļ�ǳ���� �����Ű���.", 
    /*10*/    "���� �����̰� �� ũ��. �����̿��� ���� �귣���� �ΰ� �����ִ�.", 
    /*11*/    "", 
    /*12*/    "", 
    /*13*/    "", 
    /*14*/    "", 
    /*15*/    "", 
    /*16*/    "",
    /*17*/    "�̰� ���� å���� ��� ���ڡ� �����̡� '�� ����� �̹� ���� ���ؼ� �ο� �Ƿ��� �տ� �־���, ������ �����հ� ������ ��̰� ��� ������ �� ���� �ٸ� ���ڴ� �� �̻� �̼��迡 ���� ������.' ��� ������ �ִ١�", 
    /*18*/    "", 
    /*19*/    "", 
    /*20*/    "", 
    /*21*/    "", 
    /*22*/    "����ӽ��̴� �ּ۾�! �ڼ��� ���� �ڱ����� ����� ���ڼ�ü����. �� �� ���� �� ����, ��!", };
    public void TakeImage(Image image)
    {
        if (image)
        {
            itemImage.sprite = image.sprite;
        }
        else
        {
            itemImage.sprite = null;
        }
    }
    private string nowRarity = "Unknown";
    public void SetValue(int ItemNum, List<int> inventory) //������ ������ ��Ȧ�� �޾ƿ� , ����Ʈ�� ���� �޾ƿ�(������)
    {
        RarityCheck(ItemNum); //�������� ��͵� üũ
        TakeImage(itemImage);
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
