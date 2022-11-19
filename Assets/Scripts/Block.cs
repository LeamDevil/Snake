using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    public Text amountText;
    private int amount;
    public Material EasyMaterial;
    public Material HardMaterial;   


    void Start()
    {
        SetAmount();
    }

 
    void Update()
    {
        
    }

    public void SetAmount()
    {
        gameObject.SetActive(true);
        amount = Random.Range(1, 10);
        if (amount <= 0)
        {
            gameObject.SetActive(false);
        }
        SetAmountText();
        UpdateMaterial();
    }

    public void SetAmountText()
    {
        amountText.text = amount.ToString();
    }

    private void UpdateMaterial()
    {
        Renderer sectorRenderer = GetComponent<Renderer>();
        if (amount <= 5)
        {
            sectorRenderer.material = EasyMaterial;
        }
        if (amount > 5)
        {
            sectorRenderer.material = HardMaterial;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (amount > 0)
            {
                amount--;
                SetAmountText();
                if (amount <= 0)
                {
                    Destroy(this.gameObject);
                }
            }

        }
    }
}
