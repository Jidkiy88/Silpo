using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickManager : MonoBehaviour, IPointerClickHandler {

    [SerializeField] private GameObject _canvasItemClick;
    [SerializeField] private Text _canvasItemClickName;
    [SerializeField] private Text _canvasItemClickCostSell;
    [SerializeField] private Text _canvasItemClickValue;
    [SerializeField] private Image _canvasItemClickImageSpace;
    [SerializeField] private GameObject _canvasCore;

    private GoodsParametrs _goodParametrs;

public void OnPointerClick(PointerEventData eventData)
    {
        _canvasItemClick.SetActive(true);
        _canvasCore.SetActive(false);
        Time.timeScale = 0;
        CanvasClickInfo();

    }
    private void CanvasClickInfo()
    {  
        _canvasItemClickName.text = _goodParametrs.name;
        _canvasItemClickImageSpace.sprite = _goodParametrs.ItemImage;
        _canvasItemClickValue.text = string.Format("In stock {0}", _goodParametrs.value);
    }
    private void Start()
    {
        _goodParametrs = GetComponent<GoodsParametrs>();
        
    }

}
