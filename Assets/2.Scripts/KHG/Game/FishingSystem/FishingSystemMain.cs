using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FishingSystemMain : MonoBehaviour
{
    ItemClass Item = new ItemClass();
    [SerializeField] private Button throwBtn;

    private int[] magObject = { 0, 1, 2, 3, 4, 5 };
    private int num;
    private string OJname;
    private float OJprice;
    private bool IsThrowed;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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
    }
    public void ThrowBtnClicked()
    {
        //throwBtn.interactable = false;
        MagnetThrowed();
    }
    private void MagnetThrowed()
    {
        SetRandomItem();
        
    }
    private void SetRandomItem()
    {
        int num = Random.Range(0, 4);//ENUM 길이);
        switch (Item.SetItem(num))
        {
            case ItemClass.item.None:
                SetValue("None", 0);
                break;
            case ItemClass.item.glassess:
                SetValue("망가진 안경테" ,5);
                break;
            case ItemClass.item.vault:
                SetValue("무언가 들어있는 금고", 5);
                break;
        }
    }
    private void SetValue(string ItemName, int ItemPrice)
    {
        OJname = ItemName;
        OJprice = ItemPrice;
        print(OJname);
    }
}
