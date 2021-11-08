using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager1 : MonoBehaviour
{
    [SerializeField] private GameObject _itemPrefab;
    [SerializeField] public List<GoodsParametrs> _allGoods;
    [SerializeField] private Transform _parent;
    [SerializeField] GameObject cartPrefab;
    [SerializeField] Transform cartParent;
    [SerializeField] public TextMeshProUGUI totalCostText;
    [SerializeField] public GameObject contentArea;

    public int costTotal;

    

    private void FillShop()
    {
        for (int i = 0; i < _allGoods.Count; i++)
        {
            GameObject currentItem = Instantiate(_itemPrefab, _parent);
            GoodsParametrs currentGoods = _allGoods[i];
            currentItem.transform.GetChild(1).GetComponent<Image>().sprite = currentGoods.ItemImage;
            currentItem.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = currentGoods.name;
            currentItem.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = currentGoods.costBuy.ToString();
            currentItem.transform.GetChild(4).GetComponent<Button>().onClick.AddListener(() => { currentItem.GetComponent<ItemUI>().OnItemClick(cartPrefab, cartParent);}) ;
            currentItem.transform.GetComponent<ItemUI>().item = currentGoods;
            currentItem.transform.GetComponent<ItemUI>().OnNewItemAdd += SetTotalCostText;
        }
    }

    public void SetTotalCostText()
    {
        totalCostText.text = string.Format("Total: {0}",TotalCost());
    }


    private void Start()
    {
        FillShop();
    }

    public int TotalCost()
    {
        int totalCost = 0;
        for (int i = 0; i < contentArea.transform.childCount; i++)
        {
            //contentArea.
            totalCost += contentArea.transform.GetChild(i).GetComponent<CartItemUI>().item.costBuy * Convert.ToInt32(contentArea.transform.GetChild(i).GetChild(1).GetComponent<TextMeshProUGUI>().text);
        }
        costTotal = totalCost;
        return totalCost;
    }

    public List<GoodsParametrs> GetList()
    {
        return _allGoods;
    }
    public void SetList(List<GoodsParametrs> currentList)
    {
        _allGoods.Clear();
        for (int i=0; i<currentList.Count; i++)
        {
            _allGoods.Add(currentList[i]);
        }
    }
}
