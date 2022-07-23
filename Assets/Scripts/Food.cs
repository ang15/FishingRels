﻿using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField]
    private Snack snake;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            float x = Random.Range(-120, 120);
            float y = Random.Range(-300, 240);
            transform.localPosition = new Vector2(x, y);
            snake.PlusObject();
            snake.Monets++;
        }
    }

}
