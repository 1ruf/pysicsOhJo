using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Image background,BlockFrame;
    [SerializeField] private GameObject playBtn, settingBtn, quitBtn, mainTitle,setting;
    private RectTransform title, pBtn, sBtn, qBtn, settingRT;
    private int btnStartY = -800, titleStartY = 1000;
    private void Awake()
    {
        settingRT = setting.GetComponent<RectTransform>();
        title = mainTitle.GetComponent<RectTransform>();
        pBtn = playBtn.GetComponent<RectTransform>();
        sBtn = settingBtn.GetComponent<RectTransform>();
        qBtn = quitBtn.GetComponent<RectTransform>();
    }
    private void Start()
    {
        StartCoroutine(BtnArise());
    }
    private void SetStartPos()
    {
        settingRT.anchoredPosition = new Vector2(2000, 0);
        title.anchoredPosition = new Vector2(0, titleStartY);
        pBtn.anchoredPosition = new Vector2(pBtn.anchoredPosition.x, btnStartY);
        sBtn.anchoredPosition = new Vector2(sBtn.anchoredPosition.x, btnStartY);
        qBtn.anchoredPosition = new Vector2(qBtn.anchoredPosition.x, btnStartY);
        background.DOFade(0, 0);
    }
    private IEnumerator BtnArise()
    {
        SetStartPos();
        title.DOMoveY(750, 2).SetEase(Ease.OutBounce);
        yield return new WaitForSeconds(2f);
        background.DOFade(1, 1);
        yield return new WaitForSeconds(0.7f);
        pBtn.DOMoveY(260, 1).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(0.2f);
        sBtn.DOMoveY(260, 1).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(0.2f);
        qBtn.DOMoveY(260, 1).SetEase(Ease.OutBack);
    }
    private IEnumerator BtnDisapper()
    {
        title.DOMoveY(1500, 1).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.2f);
        pBtn.DOMoveY(btnStartY, 1).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.2f);
        sBtn.DOMoveY(btnStartY, 1).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.2f);
        qBtn.DOMoveY(btnStartY, 1).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.7f);
        settingRT.DOMoveX(960, 1);
    }
    private IEnumerator BtnReArise()
    {
        title.DOMoveY(750, 2);
        yield return new WaitForSeconds(0.7f);
        pBtn.DOMoveY(260, 1).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(0.2f);
        sBtn.DOMoveY(260, 1).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(0.2f);
        qBtn.DOMoveY(260, 1).SetEase(Ease.OutBack);
    }
    private IEnumerator OpenMainScene()
    {
        yield return new WaitForSeconds(0.5f);
        BlockFrame.DOFade(1, 1);
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene("MainScene");
    }
    public void StartBtnClicked()
    {
        StartCoroutine(BtnDisapper());
        StartCoroutine(OpenMainScene());
    }
    public void SettingBtnClicked()
    {
        StartCoroutine(BtnDisapper());
    }
    public void QuitBtnClicked()
    {

    }
}
