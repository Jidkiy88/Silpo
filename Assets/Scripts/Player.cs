using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] public int playerMoney = 50;
    [SerializeField] private TextMeshProUGUI moneyText;

    private void FixedUpdate()
    {
        moneyText.text = playerMoney.ToString();
    }
}
