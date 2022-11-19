using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class PlayerSnake : MonoBehaviour
{
    public Player Player;    
    public Game Game;
    public Text amountText;
    private int amount;
    private AudioSource _audioFood;


    public GameObject BodyPrefab;
    private List<GameObject> BodyParts = new List<GameObject>();
    private List<Vector3> PositionsHistory = new List<Vector3>();
    public int Gap = 10;

    void Start()
    {
        _audioFood = GetComponent<AudioSource>();
        gameObject.SetActive(true);
        amount = 1;
        if (amount <= 0)
        {
            gameObject.SetActive(false);
        }
        SetAmountText();
    }
    public void SetAmountText()
    {
        amountText.text = amount.ToString();
    }

    public void Update()
    {
        PositionsHistory.Insert(0, transform.position);
        int index = 1;
        foreach (var body in BodyParts)
        {
            Vector3 point = PositionsHistory[Mathf.Min(index * Gap, PositionsHistory.Count - 1)];
            body.transform.position = point;
            index++;
        }
    }

    private void GrowSnake()
    {
        GameObject body = Instantiate(BodyPrefab);
        BodyParts.Add(body);        
    }

    private void ReductSnake()
    { 
        //Понятия не имею и устала пытаться
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Food")
        {
            _audioFood.Play();
            Destroy(other.gameObject);
            GrowSnake();
            amount++;
            SetAmountText();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Block1")
        {
            amount--;
            SetAmountText();
            if (amount <= 0)
            {
                Player.Die();
            }
        }
    }
}
