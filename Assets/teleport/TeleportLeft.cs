using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportLeft : Teleporter{
    protected override void Teleport(Transform objectTransform) {
        objectTransform.position = new Vector2(-8, objectTransform.position.y);
        Debug.Log("left");
    }
}
