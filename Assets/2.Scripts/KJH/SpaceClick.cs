using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceClick : MonoBehaviour
{
    [SerializeField] private float _decreaseRate = 0.05f; // �������� �پ��� �ӵ�
    [SerializeField] private float _decreaseInterval = 1.0f; // ������ ���� ���� (��)
    public Image _slider;

    private float _increaseAmount = 0.2f; // �ʱ� ������
    private float _currentValue = 0f; // ���� �����̴� ��
    private float _maxValue = 1.0f; // �ִ� ������ ��
    private Coroutine _decreaseCoroutine;

    private void Start()
    {
        // �����̴��� �ʱ�ȭ�մϴ�.
        _slider.fillAmount = _currentValue;

        // ���� �ð����� �������� ���ҽ�Ű�� �ڷ�ƾ ����
        _decreaseCoroutine = StartCoroutine(DecreaseOverTime());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Increase();  // �����̽��ٸ� ���� ������ ������ ����
            SliderUpdate(); // �����̴� UI ������Ʈ
        }
    }

    private void Increase()
    {
        // ���� ���� �������� ���մϴ�.
        _currentValue += _increaseAmount;

        if (_currentValue < 0.5f)
        {
            _increaseAmount = 0.2f;
        }
        else
        {
            _increaseAmount = 0.1f ;
        }


        // �ִ�ġ�� ���� �ʵ��� Ŭ����
        _currentValue = Mathf.Clamp(_currentValue, 0f, _maxValue);

        // �ִ�ġ�� �����ϸ� �̺�Ʈ �߻�
        if (_currentValue >= _maxValue)
        {
            OnMaxValueReached();
        }
    }

    private void SliderUpdate()
    {
        // �����̴��� fillAmount�� ���� ������ ����
        _slider.fillAmount = _currentValue;
    }

    private void OnMaxValueReached()
    {
        // �ִ�ġ�� �������� �� �߻��ϴ� �̺�Ʈ
        Debug.Log("Max Value Reached! �̺�Ʈ �߻�!");

        // �ִ�ġ�� �����ϸ� ������ �ʱ�ȭ
        _increaseAmount = 0.2f;
    }

    private IEnumerator DecreaseOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(_decreaseInterval); // ���� �ð� ���

            // ������ ����
            _currentValue -= _decreaseRate;
            _currentValue = Mathf.Clamp(_currentValue, 0f, _maxValue); // 0���� �۾����� �ʵ��� Ŭ����

            SliderUpdate(); // �����̴� UI ������Ʈ

            // �������� 0�� �����ϸ� �̺�Ʈ �߻�
            if (_currentValue <= 0f)
            {
                OnMinValueReached();
            }
        }
    }

    private void OnMinValueReached()
    {
        // �������� 0�� �������� �� �߻��ϴ� �̺�Ʈ
        Debug.Log("��������");
        // ���⿡�� �ʿ��� ������ �߰��� �� �ֽ��ϴ�.
    }

    private void OnDestroy()
    {
        // �ڷ�ƾ�� ������� �ʵ��� OnDestroy���� �ڷ�ƾ�� �����մϴ�.
        if (_decreaseCoroutine != null)
        {
            StopCoroutine(_decreaseCoroutine);
        }
    }
}
