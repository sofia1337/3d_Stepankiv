using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollect : MonoBehaviour
{
    int coins = 0;

    [SerializeField] TextMeshProUGUI coinsText;
    [SerializeField] AudioSource collectS;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coins++;
            coinsText.text = "Coins: " + coins;
            collectS.Play();
        }
    }
} 