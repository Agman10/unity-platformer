﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableLogic : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player") {
            Destroy(gameObject);
        }
    }
    protected virtual void OnCollect() {

    }
}
