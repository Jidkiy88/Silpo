using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemBuy : MonoBehaviour
{
    [SerializeField] ShopManager1 manager;
    [SerializeField] private GameObject _player;
    public Player player;
    private void OnTriggerEnter(Collider other)
    {
        List<GoodsParametrs> currentList = manager.GetList(); //�������� ����� (currentList) � ���������� ��� ������ �� ������� �������(SM1)
        manager.SetList(BuyRandomItem(currentList)); // ���������� ������ SetList �� ������� �������(SM1) (���������� ������) � ����� ���������� ���������� ������
    }
    private List<GoodsParametrs> BuyRandomItem(List<GoodsParametrs> currentList)
    {
        for (int i = 0; i < currentList.Count; i++)
        {
            int randomIndex = Random.Range(0, currentList.Count);
            if (currentList[randomIndex].value > 0 )
            {
                currentList[randomIndex].value--;
                player.playerMoney += currentList[randomIndex].costSell;
                return currentList;
            }
            else
            {
                continue;
                
            }
        }
        return currentList;
    }
    private void Start()
    {
        player = _player.GetComponent<Player>();
    }
}
