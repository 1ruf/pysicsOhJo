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

    private bool IsThrowed;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsThrowed)
            {
                print("���� �ڼ� ���� : ������");
            }
            else
            {
                ThrowBtnClicked();
            }
        }
    }
    public void ThrowBtnClicked()
    {
        throwBtn.interactable = false;
        MagnetThrowed();
    }
    private void MagnetThrowed()
    {

        
    }
    private void SetRandomItem()
    {
        int num = Random.Range(0, (magObject.Length - 1));
        Item.SetItem(num);
    }
}
