﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lines : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Wheelerman>() != null)
        {
            GameControl.instance.WheelerDie();
        }
    }
}
