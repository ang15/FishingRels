using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIPanel : MonoBehaviour
{

    public Snack snake;
    public bool Left;
    public bool Right;
    public bool Up;
    public bool Down;
    public bool mouse;
    public bool Horizontal = true;
    public bool Vertical = false;


    public void OnButton()
    {
        mouse = true;
    }

    public void Update()
    {
        if (mouse == true)
        {
            if (Horizontal)
            {
                Horizontal = false;
                Vertical = true;
                if (snake.transform.position.x < Camera.main.ScreenToWorldPoint(Input.mousePosition).x)
                {
                    snake.rotation = snake.transform.eulerAngles;
                    snake.rotation.z = -90;
                    snake.transform.eulerAngles = snake.rotation;
                    Left = true;
                    mouse = false;
                }
                else
                {
                    snake.rotation = snake.transform.eulerAngles;
                    snake.rotation.z = 90;
                    snake.transform.eulerAngles = snake.rotation;
                    Right = true;
                    mouse = false;

                }
            }
            else if (Vertical)
            {
                Vertical = false;
                Horizontal = true;
                if (snake.transform.position.y < Camera.main.ScreenToWorldPoint(Input.mousePosition).y)
                {
                    snake.rotation = snake.transform.eulerAngles;
                    snake.rotation.z = 0;
                    snake.transform.eulerAngles = snake.rotation;
                    Up = true;
                    mouse = false;
                }
                else
                {
                    snake.rotation = snake.transform.eulerAngles;
                    snake.rotation.z = 180;
                    snake.transform.eulerAngles = snake.rotation;
                    Down = true;
                    mouse = false;

                }
            }
            for (int i = snake.Bodys.Count - 1; i > 0; i--)
            {
                snake.Bodys[i].Left = snake.Bodys[i - 1].Left;
                snake.Bodys[i].Right = snake.Bodys[i - 1].Right;
                snake.Bodys[i].Up = snake.Bodys[i - 1].Up;
                snake.Bodys[i].Down = snake.Bodys[i - 1].Down;
            }

            snake.Bodys[0].Left = snake.Left;
            snake.Bodys[0].Right = snake.Right;
            snake.Bodys[0].Up = snake.Up;
            snake.Bodys[0].Down = snake.Down;
            
            Console.WriteLine("  snake.Bodys[0].Left " + snake.Bodys[0].Left);
        
            if (Left)
            {
                Left = false;
                snake.Left = true;
                snake.Up = false;
                snake.Down = false;
            }
            else
            if (Right)
            {
                Right = false;
                snake.Right = true;
                snake.Up = false;
                snake.Down = false;
            }
            else
            if (Up)
            {
                
                Up = false;
                snake.Up = true;
                snake.Left = false;
                snake.Right = false;
            }
            else
            if (Down)
            {
                Down = false;
                snake.Down = true;
                snake.Left = false;
                snake.Right = false;
            }
        }

    }
}