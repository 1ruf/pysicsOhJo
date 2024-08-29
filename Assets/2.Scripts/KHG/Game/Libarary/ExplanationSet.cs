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
    /*1*/    "안경테 따위가 엄청 무겁다. 귓볼 트레이닝이라도 했나보다.",                                                 //안경테
    /*2*/    "끝부분이 살짝 구부러진 클립이다. 문서 정리용으론 부적합한 것 같다...다른곳에 쓸수 있을지도?",                                                 //클립
    /*3*/    "어이쿠, 실수로 훔친거 같다.. 이제 소도둑이 될 차례인가..?",                  //바늘
    /*4*/    "이것만으로는 먹을수 있는게 없다. 굳이 따지자면 마시멜로 정도?", 
    /*5*/    "함몰형 못이다. 아니면 돌출형이 찌그러 진 걸까? 하여튼 엄청 ‘못’ 생겼다.", 
    /*6*/    "친구가 말했던 이어폰이 이거인가?", 
    /*7*/    "", 
    /*8*/    "전단지에 흐릿하게 무언가 적혀있다...짜장면...15000원....읽을수 있는것은 여기까지이다.", 
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
