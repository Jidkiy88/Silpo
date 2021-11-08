using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private GameObject _canvasItemClick;
    [SerializeField] private GameObject _canvasCore;
    [SerializeField] private GameObject _canvasShopManagement;
    [SerializeField] private GameObject _cartContent;
    [SerializeField] private ShopManager1 _shopManager;
    [SerializeField] private GameObject _shopCartContent;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject[] _goodsList;

    CartItemUI cartItemUI;
    public Player player;
    public ShopManager1 shopManagerScript;

    public string currentItemName;

    public void CanvasItemClickExit()
    {
        _canvasItemClick.SetActive(false);
        _canvasCore.SetActive(true);
        Time.timeScale = 1;
    }

    public void CanvasShopManagementExit()
    {
        _canvasShopManagement.SetActive(false);
        _canvasCore.SetActive(true);
        Time.timeScale = 1;
    }
    public void ItemBuy()
    {
        if (player.playerMoney >= shopManagerScript.costTotal) 
        {
            player.playerMoney -= shopManagerScript.costTotal;
            for (int i = 0; i < _cartContent.transform.childCount; i++)
            {
                currentItemName = _cartContent.transform.GetChild(i).GetComponent<CartItemUI>().item.name; //_cartContent.transform.GetChild(i).GetComponent<CartItemUI>().item.name
                for (int j = 0; j < shopManagerScript._allGoods.Count; j++)
                {
                    if (shopManagerScript._allGoods[j].name == currentItemName)
                    {
                        shopManagerScript._allGoods[j].value++;
                    }
                }
            }
            for (int h = 0; h < _cartContent.transform.childCount; h++)
            {
                Destroy(_cartContent.transform.GetChild(h).gameObject);
            }
        }
        else
        {
            Debug.LogError("else");
        }
        
    }
    private void Start()
    {
        player = _player.GetComponent<Player>();
        shopManagerScript = _shopManager.GetComponent<ShopManager1>();
        cartItemUI = GetComponent<CartItemUI>();
    }
    public void ClearCart()
    {
        Debug.Log("Start");
        for (int c = 0; c < _cartContent.transform.childCount; c++)
        {
            Destroy(_cartContent.transform.GetChild(c).gameObject);
        }
    }
}
