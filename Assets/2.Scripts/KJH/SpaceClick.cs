using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceClick : MonoBehaviour
{
    [SerializeField] private float _decreaseRate = 0.05f; // 게이지가 줄어드는 속도
    [SerializeField] private float _decreaseInterval = 1.0f; // 게이지 감소 간격 (초)
    public Image _slider;

    private float _increaseAmount = 0.2f; // 초기 증가량
    private float _currentValue = 0f; // 현재 슬라이더 값
    private float _maxValue = 1.0f; // 최대 게이지 값
    private Coroutine _decreaseCoroutine;

    private void Start()
    {
        // 슬라이더를 초기화합니다.
        _slider.fillAmount = _currentValue;

        // 일정 시간마다 게이지를 감소시키는 코루틴 시작
        _decreaseCoroutine = StartCoroutine(DecreaseOverTime());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Increase();  // 스페이스바를 누를 때마다 게이지 증가
            SliderUpdate(); // 슬라이더 UI 업데이트
        }
    }

    private void Increase()
    {
        // 현재 값에 증가량을 더합니다.
        _currentValue += _increaseAmount;

        if (_currentValue < 0.5f)
        {
            _increaseAmount = 0.2f;
        }
        else
        {
            _increaseAmount = 0.1f ;
        }


        // 최대치를 넘지 않도록 클램프
        _currentValue = Mathf.Clamp(_currentValue, 0f, _maxValue);

        // 최대치에 도달하면 이벤트 발생
        if (_currentValue >= _maxValue)
        {
            OnMaxValueReached();
        }
    }

    private void SliderUpdate()
    {
        // 슬라이더의 fillAmount를 현재 값으로 설정
        _slider.fillAmount = _currentValue;
    }

    private void OnMaxValueReached()
    {
        // 최대치에 도달했을 때 발생하는 이벤트
        Debug.Log("Max Value Reached! 이벤트 발생!");

        // 최대치에 도달하면 증가량 초기화
        _increaseAmount = 0.2f;
    }

    private IEnumerator DecreaseOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(_decreaseInterval); // 일정 시간 대기

            // 게이지 감소
            _currentValue -= _decreaseRate;
            _currentValue = Mathf.Clamp(_currentValue, 0f, _maxValue); // 0보다 작아지지 않도록 클램프

            SliderUpdate(); // 슬라이더 UI 업데이트

            // 게이지가 0에 도달하면 이벤트 발생
            if (_currentValue <= 0f)
            {
                OnMinValueReached();
            }
        }
    }

    private void OnMinValueReached()
    {
        // 게이지가 0에 도달했을 때 발생하는 이벤트
        Debug.Log("끝까지감");
        // 여기에서 필요한 로직을 추가할 수 있습니다.
    }

    private void OnDestroy()
    {
        // 코루틴이 종료되지 않도록 OnDestroy에서 코루틴을 정지합니다.
        if (_decreaseCoroutine != null)
        {
            StopCoroutine(_decreaseCoroutine);
        }
    }
}
