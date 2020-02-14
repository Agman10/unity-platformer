using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportUp : Teleporter
{
    protected override void Teleport(Transform playerTransform) {
        playerTransform.position = new Vector2(4, 4);
        //if (player != null) {
            //player.Teleport();
            Debug.Log("up");
            
            //Destroy(gameObject);
        //}
    }
}
