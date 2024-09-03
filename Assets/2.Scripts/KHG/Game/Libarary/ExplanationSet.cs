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
    /*1*/    "안경테 따위가 엄청 무겁다. 귓볼 트레이닝이라도 했나보다.",                                                 //안경테
    /*2*/    "끝부분이 살짝 구부러진 클립이다. 문서 정리용으론 부적합한 것 같다...다른곳에 쓸수 있을지도?",                                                 //클립
    /*3*/    "어이쿠, 실수로 훔친거 같다.. 이제 소도둑이 될 차례인가..?",                  //바늘
    /*4*/    "이것만으로는 먹을수 있는게 없다. 굳이 따지자면 마시멜로 정도?", 
    /*5*/    "함몰형 못이다. 아니면 돌출형이 찌그러 진 걸까? 하여튼 엄청 ‘못’ 생겼다.", 
    /*6*/    "친구가 말했던 이어폰이 이거인가?", 
    /*7*/    "앞부분이 부서져 있는 유명 브랜드의 샤프이다. 부서진 부분에는 이빨 자국이 있는것 같다.", 
    /*8*/    "전단지에 흐릿하게 무언가 적혀있다...짜장면...5개 모으면 무료....읽을수 있는것은 여기까지이다.", 
    /*9*/    "끝부분이 녹이 슨 가위이다. 살짝만 베여도 파상풍으로 죽을거같다.", 
    /*10*/    "지퍼 손잡이가 꽤 크다. 손잡이에는 유명 브랜드의 로고가 박혀있다.", 
    /*11*/    "손잡이가 없는 망치 '똘망치'는 무기 박물관의 창고에 버려져 있던 쓸모없는 유물로, 다른 도구들에게 조롱당하며 지냈습니다. 하지만 어느 날, 외계 침략자들이 박물관을 공격해 손잡이가 없는 똘망치만이 그들의 레이저를 튕겨내며 맞서 싸울 수 있다는 것이 밝혀졌습니다. 똘망치는 스스로 날아다니며 외계인들의 함선을 파괴하고, 결국 지구를 구해내면서 모든 도구들에게 영웅으로 추앙받게 되었습니다.", 
    /*12*/    "녹슨 식칼이다. 흐릿하게 핏자국이 보이는거같다..?", 
    /*13*/    "아니 이건!?!? 무선 리모컨 기능과 컴포트 액세스,키리스 스타트,디스플레이 키 기능이 있고 심지어 보안 기능까지 있는 킹자성의 바다 3갓 제네럴 차키 잖아!?!?", 
    /*14*/    "이건 옛날에 내 안경에 끼워지던 자물쇠다…. 기분이 안좋다.", 
    /*15*/    "내가 이 모터에 이름을 어떻게 알고있는진 모르겠지만, 아무튼 획득했다.", 
    /*16*/    "이걸 도대체 어떻게 낚은 건지는 모르겠지만, 이걸 끌어 올린건 대단하긴 하다.",
    /*17*/    "이게 무슨 책이지 어디 보자… 제목이… '이 세계는 이미 내가 구해서 부와 권력을 손에 넣었고, 여기사와 여마왕과 성에서 즐겁게 살고 있으니 나 말고 다른 용자는 더 이상 이세계에 오지 마세요.' 라고 쓰여져 있다…", 
    /*18*/    "바다에서 나왔으니 침수차량의 문짝일 것이다. 악덕 중고차 딜러들은 이런 것도 속여 팔 것이다.", 
    /*19*/    "잠수정이다. 벽면에는 타이탄 이라는 로고가 박혀있고 수압에 의해 찌그러진것같아보인다.", 
    /*20*/    "타이타닉호를 끌어올리다니!! 내 근육은 생각보다 많이 쎈가보다.", 
    /*21*/    "신기하게도 게임기의 재질 때문이 아니라 게임의 이름에 '철' 이 들어가서 자성체이다.", 
    /*22*/    "나노머신이다 애송아! 자석에 의해 자기장이 생기는 반자성체이지. 넌 날 낚을 수 없다, 잭!", };
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
    public void SetValue(int ItemNum, List<int> inventory) //정해진 아이템 번호를 받아옴 , 리스트도 같이 받아옴(감지용)
    {
        RarityCheck(ItemNum); //아이템의 희귀도 체크
        TakeImage(itemImage, color);
        if (inventory.Contains(ItemNum)) //획득 리스트에 클릭한 버튼의 아이템이 있는지 확인 ------------------------------------------------------------------
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
