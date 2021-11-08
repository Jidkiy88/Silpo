using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject _canvasShopManagement;

    public void OnPointerClick(PointerEventData eventData)
    {
        _canvasShopManagement.SetActive(true);
        Time.timeScale = 0;
    }
}
