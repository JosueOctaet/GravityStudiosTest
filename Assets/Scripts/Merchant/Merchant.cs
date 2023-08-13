using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    public GameObject storeUI;
    public GameObject hpPlayer;

    public void DestroyProp()
    {
        Destroy(transform.parent.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            storeUI.SetActive(true);
            hpPlayer.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            storeUI.SetActive(false);
            hpPlayer.SetActive(true);
        }
    }
}
