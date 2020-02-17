using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportUp : Teleporter {
    protected override void Teleport(Transform objectTransform) {
        objectTransform.position = new Vector2(objectTransform.position.x, 8);
        Debug.Log("up");
    }
}