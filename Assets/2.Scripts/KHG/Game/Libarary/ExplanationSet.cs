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
        "강철로 만든 안경테이다. 무게가 꽤 나가는것 같다.",                                                 //안경테
        "끝부분이 살짝 구부러진 클립이다. 옆에있는 뜨거운물에 실수로 떨어트렸더니 클립 모양으로 되돌아간다..? 이게 바로 '형상기억합금'..!",                                                 //클립
        "누군가의 피가 끝부분의 묻어있는 바늘이다..",                  //바늘
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
            print("가지고 있지 않음, 번호:" + ItemNum);
            SetText("???", "???");
        }
    }
    private void SetText(string Name,string Explain)
    {
        ITname.text = "이름:"+Name;
        ITrarity.text = "희귀도:"+nowRarity;
        ITexplain.text = "설명:"+Explain;
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
