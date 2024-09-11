using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class FishingSystemMain : MonoBehaviour
{
    [SerializeField] private TMP_InputField answer;
    [SerializeField] private GameObject explainUI;
    [SerializeField] private GameObject pullingUI;
    [SerializeField] private Button throwBtn, LibBtn;
    [SerializeField] private Image blocker, popUpitemImage;
    [SerializeField] private Image[] itemImages = { };
    [SerializeField] private RectTransform LibMain, ItemPopupScreen, questionUI;
    [SerializeField] private TMP_Text popUpTxt, questTxt,subTitle;

    private List<int> visibledQ = new List<int>();
    private int nowItemNum;
    private string nowAnswer;

    private Color nowColor;
    private ExplanationSet _explainSet;
    private List<int> inventoryList = new List<int>(); 
    public string[] itemNames = 
        { 
        /*common(5)*/"焼巷依亀 蒸澗", "照井砺", "適験", "郊潅", "腺亜喰(廃側)", "公",

        /*uncommon(5)*/"刊浦亜税 籍嬢獄鍵 戚嬢肉", "採辞遭 時覗", "掻厩増 庭肉", "褐充 亜是", "走遁 謝説戚",

        /*rare(5)*/"謝説戚亜 蒸澗 諺帖", "褐充 縦町", "蒋増 BMW 託徹", "切弘取", "RsW6乞斗",

        /*superRare(3)*/"搾楳奄 督畷", "榎紗廻生稽 広昔 奪", "切疑託拭辞 金移蟹紳 庚側",

        /*legendary(2)*/"舵益虞窮 展戚添 節呪舛", "展戚展莞硲",

        /*Mythic*/"\"旦\"映", "蟹葛袴重聖 砧献 章什闘荊 雌据税据"
    };
    private string OJname;
    private string OJrarity = "硝呪 蒸製";
    private bool IsThrowed, IsLibOpend, LibBtnCool;

    private string[] Q = { 
        "須採 切奄舌戚 紫虞閃亀 切奄舌聖 神掘 政走拝呪 赤澗 切失端澗?",
        "雌切失端澗 雌切失聖 亜走澗 弘端稽, 悪切失端人 含軒 鎧採拭 けけけけ戚 蒸陥. けけけけ拭 級嬢哀 源精?",
        "弘霜戚 切汐拭 鋼誓馬澗 失霜聖 更虞壱 馬澗亜?", 
        "切失聖 句澗 弘端研 巷譲戚虞壱 馬澗亜?",
        "鋼切失端澗 須採 切奄舌引 鋼企 号狽生稽 切奄鉢鞠醸陥亜 須採 切奄舌聖 薦暗馬檎 切奄鉢 雌殿亜 郊稽 紫虞遭陥.(O,X)",
        "悪切失端澗 須採 切奄舌聖 薦暗背亀 切奄鉢吉 雌殿亜 神掘 政走吉陥.(O,X)",
        "鋼切失端澗 鋼切失聖 亜走澗 弘端稽, 鎧採拭 けけけ聖 亜走澗 据切亜 蒸陥. けけけ 拭 級嬢哀 源精?" };
    private string[] A = { "悪切失端"  , "切奄姥蝕", "切失", "切失端", "O", "O", "切奄舌" };

    private void Awake()
    {
        _explainSet = explainUI.GetComponent<ExplanationSet>();
    }
    private void Start()
    {
        subTitle.text = "";
        //GetInventoryInform();
        questionUI.anchoredPosition = new Vector2(0, 1500);
        ItemPopupScreen.DOAnchorPosY(-1000, 0);
        blocker.DOFade(0, 1).OnComplete(() => blocker.gameObject.SetActive(false));
        LibMain.anchoredPosition = new Vector2(1700, 0);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            LibraryBtnClicked();
        }
        if (Input.GetKey(KeyCode.RightShift))
        {
            PullSuccess();
        }
    }
    private void FixedUpdate()
    {
       // SaveItemImage();
    }


    private void GetInventoryInform()
    {
        for (int i = 0; i <= 22; i++)
        {
            int value = PlayerPrefs.GetInt(("ItemNum" + i), 0);
            if (value == 0)
            {
                inventoryList[i] = 0;
            }
            else
            {
                inventoryList[i] = value;
            }
        }
        
    }
    private void SetInventoryInform()
    {
        for (int i = 0; i <= inventoryList.Count; i++)
        {
            PlayerPrefs.SetInt(("ItemNum" + i), i);
        }
    }


    public void ThrowBtnClicked()
    {
        throwBtn.gameObject.SetActive(false);
        throwBtn.interactable = false;
        OpenQuest();
        //MagnetThrowed();//刃戟
    }
    public void PullSuccess()
    {
        
        SetRandomItem();
    }
    private void SetRandomItem()
    {
        SetValue();
        StartCoroutine(PopUpItem(nowItemNum));
    }
    private IEnumerator PopUpItem(int ItemNum)
    {
        popUpitemImage.sprite = itemImages[ItemNum].sprite;
        popUpTxt.text = OJrarity;

        ItemPopupScreen.DOAnchorPosY(0, 1.2f);
        yield return new WaitForSeconds(1.5f);
        ItemPopupScreen.DOAnchorPosY(-1000, 1.2f); //2.4f
        yield return new WaitForSeconds(1.2f);
        throwBtn.gameObject.SetActive(true);
        throwBtn.interactable = true;
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
        else if (randomValue <= 99.5)
        {
            // Legendary: 19-20 (cumulative 4% range)
            OJrarity = "legendary";                                                             //1.6
            ItemNum = UnityEngine.Random.Range(19, 21); // Random number between 19 and 20
        }
        else 
        {
            // Mythic: 21 (cumulative 1% range)
            OJrarity = "mythic";                                                            //0.5
            ItemNum = UnityEngine.Random.Range(21, 23);
        }

        #region 森搾
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
        nowItemNum = ItemNum;

        OJname = itemNames[ItemNum]; //焼戚奴 戚硯聖 腰硲拭 限惟 走舛
        SaveToInventory(ItemNum);
    }
    private void SaveToInventory(int ItemNum)
    {
        if (!(inventoryList.Contains(ItemNum)))
        {
            print(OJname + ",費瑛亀:" + OJrarity);
            inventoryList.Add(ItemNum);
            _explainSet.LibrarySet(inventoryList);
            SaveItemImage();
        }
        else
            print("戚耕赤製");
        SaveItemImage();
        print(inventoryList.Count);
    }
    public void LibraryBtnClicked()
    {
        SaveItemImage();

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
    private void SaveItemImage()
    {
        print("Blocked1");
        for (int i = 0; i <= 23; i++)
        {
            if (inventoryList.Contains(i))
            {
                print(i);
                /*nowColor = new Color(255, 255, 255);
                itemImages[i].color = nowColor;*/
                Color color = new Color(255, 255, 255);
                itemImages[i].color = color;
                print(itemImages[i].color);
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

    public void InformBtnClicked(int ItemNum)
    {
        IsLibOpend = false;
        nowItemNum = ItemNum;
        explainUI.SetActive(true);
        _explainSet.SetValue(ItemNum, inventoryList);
    }
    public void InformBtnClickedForImage(Image image)
    {
        print("適遣喫");
        nowColor = image.color;
        _explainSet.TakeImage(image, nowColor);
    }

    private void OpenQuest()
    {
        questionUI.gameObject.SetActive(true);
        questTxt.text = "";
        int randNum = SetQuestion();
        SetQAText(randNum);
        questionUI.DOAnchorPosY(0, 0.5f);
    }
    public void answerCompleted()
    {
        questionUI.DOAnchorPosY(1500, 0.5f);
        if (answer.text == nowAnswer)
        {
            questionUI.gameObject.SetActive(false);
            StartCoroutine(success());
            pullingUI.SetActive(true);
        }
        else
        {
            questTxt.text = "";
            subTitle.text = "叔鳶!";
            subTitle.color = new Color(255,0,0);
            StartCoroutine(failed());
        }
    }
    private IEnumerator success()
    {
        subTitle.text = "舛岩!";
        subTitle.color = new Color(0, 125, 255);
        yield return new WaitForSeconds(0.7f);    
        subTitle.text = "";
        
    }
    private IEnumerator failed()
    {
        yield return new WaitForSeconds(0.7f);
        subTitle.text = "";
        throwBtn.gameObject.SetActive(true);
        throwBtn.interactable = true;
        questionUI.gameObject.SetActive(false);
    }
    private int SetQuestion()//庚薦 竺舛
    {
        int randNum = Random.Range(1, (Q.Length));
        /*while (true)
        {
            if (visibledQ.Contains(randNum))
            {
                randNum = Random.Range(1, (Q.Length));
                SetQuestion();
            }
            else if (visibledQ.Contains(randNum) == false)
                break;
            else
            {

                for (int i = 0; i <= visibledQ.Count; i++)
                {
                    visibledQ.Remove(i);
                }
                break;
            }
        }
        visibledQ.Add(randNum);*/
        print(randNum);
        return randNum;
    }
    private void SetQAText(int num)
    {
        questTxt.text = Q[num];
        nowAnswer = A[num];
    }
}
