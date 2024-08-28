using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FishingSystemMain : MonoBehaviour
{
    [SerializeField] private Button throwBtn, LibBtn;
    [SerializeField] private RectTransform LibMain;

    List<int> inventoryList = new List<int>(); // 0 None , 1 안경테 , 2 금고 , 3 비행기 파편 , 4 자동차 문짝 , 5 오락기 , 6 철근 , 7 "철" 권 (예준이 얼굴사진) , 8 클립 , 9 금고 , 10 바늘 , 11 부서진 책상 , 
    private string[] itemNames = { /*common(5)*/"아무것도 없는", "안경테", "클립", "바늘", "젓가락(한짝)", "못",/*uncommon(5)*/"누군가의 잃어버린 이어폰", "부서진 샤프", "찢어진 중국집 전단지", "녹슨 가위", "지퍼 손잡이",/*rare(5)*/"손잡이가 없는 망치", "녹슨 식칼", "앞집 BMW 차키", "자물쇠", "RsW6모터",/*비행기 파편(3)*/"비행기 파편", "금속끈으로 묶인 책", "문짝이 뜯겨나간 자동차",/*legendary(2)*/"쪼그라든 타이탄 잠수정", "타이타닉호",/*Mythic*/"\"철\"권", "나노머신을 두른 암스트롱 상원의원" };
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
                print("현재 자석 상태 : 던져짐");
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
        //대충 전지는 애니메이션
        //대충 끌어올리는 행동?
        if (/*그 행동이 True 이면*/true)
        {
            SetRandomItem();
        }
        else
        {
            print("낚시 실패");
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

        #region 예비
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
        print(OJname + ",희귀도:" + OJrarity);
        throwBtn.gameObject.SetActive(true);
        throwBtn.interactable = true;
    }
    private void SaveToInventory(string ItemName,int ItemNum)
    {
        if (!(inventoryList.Contains(ItemNum)))
            inventoryList.Add(ItemNum);
        else
            print("이미있음");
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
