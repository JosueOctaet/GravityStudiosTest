using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableProp : MonoBehaviour
{
    public GameObject interactUI;
    public bool isChest;

    public void DestroyProp()
    {
        Destroy(transform.parent.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.SetActive(true);

            if (isChest)
            {
                CharacterController2D player = collision.GetComponent<CharacterController2D>();
                player.prop = this;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.SetActive(false);

            if (isChest)
            {
                CharacterController2D player = collision.GetComponent<CharacterController2D>();
                player.prop = null;
            }
        }
    }
}
