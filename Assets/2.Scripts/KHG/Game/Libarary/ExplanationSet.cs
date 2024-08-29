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
        "��ö�� ���� �Ȱ����̴�. ���԰� �� �����°� ����.",                                                 //�Ȱ���
        "���κ��� ��¦ ���η��� Ŭ���̴�. �����ִ� �߰ſ�� �Ǽ��� ����Ʈ�ȴ��� Ŭ�� ������� �ǵ��ư���..? �̰� �ٷ� '�������ձ�'..!",                                                 //Ŭ��
        "�������� �ǰ� ���κ��� �����ִ� �ٴ��̴�..",                  //�ٴ�
        "", 
        "", 
        "", 
        "", 
        "", 
        "", 
        "", 
        "", 
        "", 
        "", 
        "", 
        "", 
        "",
        "", 
        "", 
        "", 
        "", 
        "", 
        "", 
        "", 
        "", 
        "", 
        "", 
        "", 
        "", 
        "", 
        "", 
        "", 
        "", 
        "", 
        "", 
        "", };

    private string nowRarity = "Unknown";
    public void SetValue(int ItemNum, List<int> inventory)
    {
        RarityCheck(ItemNum);
        if (inventory.Contains(ItemNum))
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
        ITexplain.text = "����:"+Explain;
    }
    private void RarityCheck(int CheckNum)
    {
        if (CheckNum > 0 && CheckNum <= 5)
        {
            nowRarity = "common";
        }
        else if (CheckNum <= 10)
        {
            nowRarity = "uncommon";
        }
        else if (CheckNum <= 15)
        {
            nowRarity = "rare";
        }
        else if (CheckNum <= 18)
        {
            nowRarity = "superRare";
        }
        else if (CheckNum <= 20)
        {
            nowRarity = "legendary";
        }
        else
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
