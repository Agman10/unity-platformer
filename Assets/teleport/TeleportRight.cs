using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportRight : Teleporter{
    protected override void Teleport(Transform objectTransform) {
        objectTransform.position = new Vector2(9, objectTransform.position.y);
        Debug.Log("right");
    }
}