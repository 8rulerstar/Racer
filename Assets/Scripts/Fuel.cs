using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    private float moveSpeed = 5f;

    void Update()
    {
        transform.Translate(Vector2.down * (moveSpeed * BackgroundScroll.gameSpeed * Time.deltaTime));

    }
}
