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
    /*1*/    "강철로 만든 안경테이다. 무게가 꽤 나가는것 같다.",                                                 //안경테
    /*2*/    "끝부분이 살짝 구부러진 클립이다. 옆에있는 뜨거운물에 실수로 떨어트렸더니 클립 모양으로 되돌아간다..? 이게 바로 '형상기억합금'..!",                                                 //클립
    /*3*/    "누군가의 피가 끝부분의 묻어있는 바늘이다..",                  //바늘
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
    public void SetValue(int ItemNum, List<int> inventory) //정해진 아이템 번홀ㄹ 받아옴 , 리스트도 같이 받아옴(감지용)
    {
        RarityCheck(ItemNum); //아이템의 희귀도 체크
        if (inventory.Contains(ItemNum)) //획득 리스트에 클릭한 버튼의 아이템이 있는지 확인
        {
            SetText(MainSystem.itemNames[ItemNum], itemInformation[ItemNum]);
        }
        else
        {
            print("가지고 있지 않음, 번호:" + ItemNum);
            SetText("???", "???");
        }
    }
    private void SetText(string Name,string Explain)
    {
        ITname.text = "이름:"+Name;
        ITrarity.text = "희귀도:"+nowRarity;
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
