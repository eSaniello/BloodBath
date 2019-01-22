using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform player;
    public Transform respawnPoint;

    private void Update()
    {
        if(player.transform.position.y < transform.position.y)
        {
            player.position = respawnPoint.position;
        }
    }
}
