using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderSystem : MonoBehaviour
{
    public GameObject UI_Tomato;
    public GameObject UI_Meat;

    private int orderListSize;
    void Start()
    {
        orderListSize = GlobalVariables.orderList.Length;
        GlobalVariables.actualOrder = 1;
        UpdateUI();
    }

    void Update()
    {
        if (GlobalVariables.validRecipe)
        {
            GlobalVariables.actualOrder = Random.Range(0, orderListSize+1);
            Debug.Log(GlobalVariables.actualOrder);

            if (Input.GetButtonDown("Fire1"))
            {
                UpdateUI();
            }

            GlobalVariables.validRecipe = false;
        }
    }

    void UpdateUI()
    {
        if (UI_Tomato != null)
        {
            UI_Tomato.SetActive(GlobalVariables.actualOrder == 0);
        }
        if (UI_Meat != null)
        {
            UI_Meat.SetActive(GlobalVariables.actualOrder == 1);
        }
    }
}
