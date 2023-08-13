using UnityEngine;

// This script defines an InteractableProp class that inherits from MonoBehaviour
public class InteractableProp : MonoBehaviour
{
    public GameObject interactUI;
    public bool isChest;

    // Method for destroying this prop
    public void DestroyProp()
    {
        // Destroy the parent object of this script's GameObject
        Destroy(transform.parent.gameObject);
    }

    // Method called when a Collider2D enters this script's GameObject's Collider2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the Collider2D belongs to the Player...
        if (collision.CompareTag("Player"))
        {
            // ...activate the interact UI
            interactUI.SetActive(true);

            // If this prop is a chest...
            if (isChest)
            {
                // ...get the CharacterController2D component of the player and set its prop to this prop
                CharacterController2D player = collision.GetComponent<CharacterController2D>();
                player.prop = this;
            }
        }
    }

    // Method called when a Collider2D exits this script's GameObject's Collider2D
    private void OnTriggerExit2D(Collider2D collision)
    {
        // If the Collider2D belongs to the Player...
        if (collision.CompareTag("Player"))
        {
            // ...deactivate the interact UI
            interactUI.SetActive(false);

            // If this prop is a chest...
            if (isChest)
            {
                // ...get the CharacterController2D component of the player and set its prop to null
                CharacterController2D player = collision.GetComponent<CharacterController2D>();
                player.prop = null;
            }
        }
    }
}
