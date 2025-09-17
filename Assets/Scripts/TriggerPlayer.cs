using UnityEngine;

public class TriggerPlayer : MonoBehaviour
{
    public GameObject door;
    public Sprite spriteOpenDoor;
    public Sprite spriteButtonPressed;
    public void OpenDoor(GameObject obj)
    {
        if (obj.CompareTag("Player"))
        {
            door.GetComponentInChildren<SpriteRenderer>().sprite = spriteOpenDoor;
            door.GetComponent<BoxCollider2D>().enabled = false;

            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = spriteButtonPressed;
        }
    }
}
