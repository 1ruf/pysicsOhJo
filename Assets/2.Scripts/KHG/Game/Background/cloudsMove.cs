using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudsMove : MonoBehaviour
{
    [SerializeField] private Vector3 _startPos;
    [SerializeField] private Vector3 _endPos;
    [SerializeField] private Vector3 _moveAmount;
    private void Start()
    {
        StartCoroutine(CloudMove());
    }
    private IEnumerator CloudMove()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            transform.position += _moveAmount;
            if(transform.position.x >= _endPos.x)
            {
                transform.position = _startPos;
            }
        }
    }
}
