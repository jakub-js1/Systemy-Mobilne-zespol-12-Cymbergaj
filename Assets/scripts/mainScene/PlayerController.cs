using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public List<PlayerMovement> Players = new List<PlayerMovement>();

    public GameObject AiPlayer;

    private void Start()
    {
        if (GameValues.IsMultiplayer)
        {
            AiPlayer.GetComponent<PlayerMovement>().enabled = true;
            AiPlayer.GetComponent<AiScript>().enabled = false;
        }
        else
        {
            AiPlayer.GetComponent<PlayerMovement>().enabled = false;
            AiPlayer.GetComponent<AiScript>().enabled = true;
        }
    }

    // Update one per frame
    void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Vector2 touchWorldPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
            foreach (var player in Players)
            {
                if (player.LockedFingerID == null)
                {
                    if (Input.GetTouch(i).phase == TouchPhase.Began &&
                        player.PlayerCollider.OverlapPoint(touchWorldPos))
                    {
                        player.LockedFingerID = Input.GetTouch(i).fingerId;
                    }
                }
                else if (player.LockedFingerID == Input.GetTouch(i).fingerId)
                {
                    player.MoveToPosition(touchWorldPos);
                    if (Input.GetTouch(i).phase == TouchPhase.Ended ||
                       Input.GetTouch(i).phase == TouchPhase.Canceled)
                        player.LockedFingerID = null;
                }
            }
        }

    }
}
