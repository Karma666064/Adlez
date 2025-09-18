using System.Collections;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    public GameObject door;
    public Sprite spriteCloseDoor;

    private void Start()
    {
        Close();
    }

    public void Close()
    {
        if (!GameData.Instance.isGameStarted)
        {
            GameData.Instance.isGameStarted = true;
            StartCoroutine(CloseD());
        }
    }

    public IEnumerator CloseD()
    {
        yield return new WaitForSeconds(1.5f);
        door.GetComponentInChildren<SpriteRenderer>().sprite = spriteCloseDoor;
        door.GetComponent<BoxCollider2D>().enabled = true;
    }
}
