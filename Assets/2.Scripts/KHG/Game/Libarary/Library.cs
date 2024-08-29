using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Library : MonoBehaviour
{
    [SerializeField] private Transform library;
    private Transform common;
    private Transform uncommon;
    private Transform rare;
    private Transform superRare;
    private Transform legendary;
    private Transform mythic;
    private void Awake()
    {
        common = library.Find("ItemGroup_common3").transform;
        uncommon = GameObject.FindWithTag("uncommon").transform;
        rare = GameObject.FindWithTag("rare").transform;
        superRare = GameObject.FindWithTag("superRare").transform;
        legendary = GameObject.FindWithTag("legendary").transform;
        mythic = GameObject.FindWithTag("mythic").transform;
}
    private void Start()
    {
        print(common.name);
    }
}
