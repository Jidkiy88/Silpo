using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ItemUI : MonoBehaviour
{
    public GoodsParametrs item;
    [SerializeField] public TextMeshPro totalCostText;
    [SerializeField] public Transform contentArea;
    public int totalCost = 0;
    public Action OnNewItemAdd;
    public Action<GoodsParametrs> ItemCheck;
    public bool isExist;
    public GameObject addedGoods;
    private int valueItem = 0;
    public void OnItemClick(GameObject prefab, Transform cartParent)
    {
        if (!isExist)
        {
            isExist = true;
            addedGoods = Instantiate(prefab, cartParent);
            addedGoods.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = item.name;
            
            addedGoods.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = (Convert.ToInt32(addedGoods.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text) * item.costBuy).ToString();
            addedGoods.transform.GetComponent<CartItemUI>().item = item;
            OnNewItemAdd?.Invoke();
        }
        else
        {
            valueItem++;
            
            addedGoods.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = (valueItem).ToString();
            addedGoods.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = (valueItem * item.costBuy).ToString(); 
            OnNewItemAdd?.Invoke();

        }
    } 
}
