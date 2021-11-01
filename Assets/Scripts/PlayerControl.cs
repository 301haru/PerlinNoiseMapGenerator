using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    void Update()
    {
        GameManager.Instance.Movement(transform);
    }
}
