using UnityEngine;

public class TriggerPlayer : MonoBehaviour
{
    public GameObject door;
    public Sprite spriteOpenDoor;
    public void OpenDoor(GameObject obj)
    {
        if (obj.CompareTag("Player"))
        {
            door.GetComponentInChildren<SpriteRenderer>().sprite = spriteOpenDoor;
            door.GetComponent<BoxCollider2D>().enabled = false;

            gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color(149f / 255f, 217f / 255f, 157f / 255f);
        }
    }
}
