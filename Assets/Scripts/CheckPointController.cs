using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    public Sprite newSprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().sprite = newSprite;
        collision.GetComponent<VidaPlayer>().respawn = transform.position;
    }
}
