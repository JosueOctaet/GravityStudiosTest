using UnityEngine;

public class Merchant : MonoBehaviour
{
    public GameObject storeUI;
    public GameObject hpPlayer;

    // Method to destroy the parent object of this script's GameObject
    public void DestroyProp()
    {
        Destroy(transform.parent.gameObject);
    }

    // Method called when a Collider2D enters this script's GameObject's Collider2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the Collider2D belongs to the Player
        if (collision.CompareTag("Player"))
        {
            // Activate the store UI and deactivate the player's health UI
            storeUI.SetActive(true);
            hpPlayer.SetActive(false);
        }
    }

    // Method called when a Collider2D exits this script's GameObject's Collider2D
    private void OnTriggerExit2D(Collider2D collision)
    {
        // If the Collider2D belongs to the Player
        if (collision.CompareTag("Player"))
        {
            // Deactivate the store UI and activate the player's health UI
            storeUI.SetActive(false);
            hpPlayer.SetActive(true);
        }
    }
}
