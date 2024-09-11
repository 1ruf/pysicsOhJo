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

    private Color color = new Color(0,0,0);
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
    /*11*/    "�����̰� ���� ��ġ '�ʸ�ġ'�� ���� �ڹ����� â�� ������ �ִ� ������� ������, �ٸ� �����鿡�� ���մ��ϸ� ���½��ϴ�. ������ ��� ��, �ܰ� ħ���ڵ��� �ڹ����� ������ �����̰� ���� �ʸ�ġ���� �׵��� �������� ƨ�ܳ��� �¼� �ο� �� �ִٴ� ���� ���������ϴ�. �ʸ�ġ�� ������ ���ƴٴϸ� �ܰ��ε��� �Լ��� �ı��ϰ�, �ᱹ ������ ���س��鼭 ��� �����鿡�� �������� �߾ӹް� �Ǿ����ϴ�.", 
    /*12*/    "�콼 ��Į�̴�. �帴�ϰ� ���ڱ��� ���̴°Ű���..?", 
    /*13*/    "�ƴ� �̰�!?!? ���� ������ ��ɰ� ����Ʈ �׼���,Ű���� ��ŸƮ,���÷��� Ű ����� �ְ� ������ ���� ��ɱ��� �ִ� ŷ�ڼ��� �ٴ� 3�� ���׷� ��Ű �ݾ�!?!?", 
    /*14*/    "�̰� ������ �� �Ȱ濡 �������� �ڹ���١�. ����� ������.", 
    /*15*/    "���� �� ���Ϳ� �̸��� ��� �˰��ִ��� �𸣰�����, �ƹ�ư ȹ���ߴ�.", 
    /*16*/    "�̰� ����ü ��� ���� ������ �𸣰�����, �̰� ���� �ø��� ����ϱ� �ϴ�.",
    /*17*/    "�̰� ���� å���� ��� ���ڡ� �����̡� '�� ����� �̹� ���� ���ؼ� �ο� �Ƿ��� �տ� �־���, ������ �����հ� ������ ��̰� ��� ������ �� ���� �ٸ� ���ڴ� �� �̻� �̼��迡 ���� ������.' ��� ������ �ִ١�", 
    /*18*/    "�ٴٿ��� �������� ħ�������� ��¦�� ���̴�. �Ǵ� �߰��� �������� �̷� �͵� �ӿ� �� ���̴�.", 
    /*19*/    "������̴�. ���鿡�� Ÿ��ź �̶�� �ΰ� �����ְ� ���п� ���� ��׷����Ͱ��ƺ��δ�.", 
    /*20*/    "Ÿ��Ÿ��ȣ�� ����ø��ٴ�!! �� ������ �������� ���� �밡����.", 
    /*21*/    "�ű��ϰԵ� ���ӱ��� ���� ������ �ƴ϶� ������ �̸��� 'ö' �� ���� �ڼ�ü�̴�.", 
    /*22*/    "����ӽ��̴� �ּ۾�! �ڼ��� ���� �ڱ����� ����� ���ڼ�ü����. �� �� ���� �� ����, ��!", };
    public void TakeImage(Image image, Color nowColor)
    {
        color = nowColor;
        if (image)
        {
            itemImage.sprite = image.sprite;
            itemImage.color = nowColor;
            print(itemImage.color + "aa" + nowColor);
        }
        else
        {
            itemImage.sprite = null;
        }
    }
    private string nowRarity = "Unknown";
    public void SetValue(int ItemNum, List<int> inventory) //������ ������ ��ȣ�� �޾ƿ� , ����Ʈ�� ���� �޾ƿ�(������)
    {
        RarityCheck(ItemNum); //�������� ��͵� üũ
        TakeImage(itemImage, color);
        if (inventory.Contains(ItemNum)) //ȹ�� ����Ʈ�� Ŭ���� ��ư�� �������� �ִ��� Ȯ�� ------------------------------------------------------------------
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
