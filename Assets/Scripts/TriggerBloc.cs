using UnityEngine;

public class TriggerBloc : MonoBehaviour
{
    public GameObject door;
    public Sprite spriteOpenDoor;
    public void OpenRoom(GameObject obj)
    {
        if (obj.CompareTag("Bloc"))
        {
            obj.transform.position = new Vector2(11f, 6f);
            obj.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

            OpenDoor();
        }
    }

    void OpenDoor()
    {
        door.GetComponentInChildren<SpriteRenderer>().sprite = spriteOpenDoor;
        door.GetComponent<BoxCollider2D>().enabled = false;
    }
}
