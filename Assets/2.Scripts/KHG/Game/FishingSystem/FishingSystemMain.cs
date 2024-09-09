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

    private int nowItemNum;

    private Color nowColor;
    private ExplanationSet _explainSet;
    private List<int> inventoryList = new List<int>(); 
    public string[] itemNames = 
        { 
        /*common(5)*/"�ƹ��͵� ����", "�Ȱ���", "Ŭ��", "�ٴ�", "������(��¦)", "��",

        /*uncommon(5)*/"�������� �Ҿ���� �̾���", "�μ��� ����", "�߱��� ����", "�콼 ����", "���� ������",

        /*rare(5)*/"�����̰� ���� ��ġ", "�콼 ��Į", "���� BMW ��Ű", "�ڹ���", "RsW6����",

        /*superRare(3)*/"����� ����", "�ݼӲ����� ���� å", "�ڵ������� ��ܳ��� ��¦",

        /*legendary(2)*/"�ɱ׶�� Ÿ��ź �����", "Ÿ��Ÿ��ȣ",

        /*Mythic*/"\"ö\"��", "����ӽ��� �θ� �Ͻ�Ʈ�� ����ǿ�"
    };
    private string OJname;
    private string OJrarity = "�˼� ����";
    private bool IsThrowed, IsLibOpend, LibBtnCool;
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
        //MagnetThrowed();//�Ϸ�
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
            OJrarity = "legendary";                                                             //2
            ItemNum = UnityEngine.Random.Range(19, 21); // Random number between 19 and 20
        }
        else 
        {
            // Mythic: 21 (cumulative 1% range)
            OJrarity = "mythic";                                                            //0.5
            ItemNum = UnityEngine.Random.Range(21, 23);
        }

        #region ����
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

        OJname = itemNames[ItemNum]; //������ �̸��� ��ȣ�� �°� ����
        SaveToInventory(ItemNum);
    }
    private void SaveToInventory(int ItemNum)
    {
        if (!(inventoryList.Contains(ItemNum)))
        {
            print(OJname + ",��͵�:" + OJrarity);
            inventoryList.Add(ItemNum);
            _explainSet.LibrarySet(inventoryList);
            SaveItemImage();
        }
        else
            print("�̹�����");
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
        print("Ŭ����");
        nowColor = image.color;
        _explainSet.TakeImage(image, nowColor);
    }

    private void OpenQuest()
    {
        SetQuestion();
        questionUI.DOAnchorPosY(0, 0.5f);
    }
    public void answerCompleted()
    {
        questionUI.DOAnchorPosY(1500, 0.5f);
        if (answer.text == "ö�̶�")
        {
            pullingUI.SetActive(true);
        }
        else
        {
            subTitle.text = "����!";
            failed();
        }
    }
    private IEnumerator failed()
    {
        yield return new WaitForSeconds(0.7f);
        subTitle.text = "";
        throwBtn.gameObject.SetActive(true);
        throwBtn.interactable = true;
    }
    private void SetQuestion()//���� ����
    {
        questTxt.text = "ö�� ����";
    }
}
