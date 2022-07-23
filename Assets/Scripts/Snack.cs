using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Snack : MonoBehaviour
{

    public List<SnackBode> Bodys = new List<SnackBode>();
    public bool segment;
    [SerializeField]
    private SnackBode prefab;
    [SerializeField]
    private GameObject bodys;
    //private bool BoolTrue = true;
    //private bool pause = true;
    public float Rotation;
    [SerializeField]
    private Text monetsText;
    [SerializeField]
    private Text monetsText2;
    [SerializeField]
    private GameObject Theend;
    //[SerializeField]
    //private GameObject greadAre;
    //[SerializeField]
    //private GameObject food;
    public int Monets;
    public bool Left;
    public bool Right;
    public bool Up;
    public bool Down;
    public bool move;
    public Vector3 position;
    public Vector3 rotation;
    private void Start()
    {
        Up = true;
        move = true;
        Rotation = transform.eulerAngles.z;
    }

    private void Update()
    {

        position = transform.position;

        if (move)
        {
            move = false;
            StartCoroutine(OnMove());

            if (transform.localPosition.x < -156)
            {
                TheEnd();
            }
            else
        if (transform.localPosition.x > 156)
            {
                TheEnd();
            }
            else
        if (transform.localPosition.y > 240)
            {
                TheEnd();
            }
            else
        if (transform.localPosition.y < -240)
            {
                TheEnd();
            }

            monetsText.text = "" + Monets;
            monetsText2.text = "" + Monets;

        }
    }

    private IEnumerator OnMove()
    {
        yield return new WaitForSeconds(0.2f);
       

        //Bodys[0].Move();
        if (Left)
        {
            position.x += 2;
        }
        else
        if (Right )
        {
            position.x -= 2;
        }
        else
        if (Up)
        {
            position.y += 2;
        }
        else
        if (Down)
        {
            position.y -= 2;
        } 
        transform.position = position;
        if (segment == true)
        {
            SnackBode bodyNew = Instantiate(prefab, bodys.transform);
            bodyNew.transform.localPosition = new Vector2(Bodys[Bodys.Count - 1].transform.localPosition.x, Bodys[Bodys.Count - 1].transform.localPosition.y);
            Vector3 eulerAngle = bodyNew.transform.eulerAngles;
            eulerAngle.z = Bodys[Bodys.Count - 1].transform.eulerAngles.z;
            bodyNew.transform.eulerAngles = eulerAngle;
           
            for (int i = 0; i < Bodys.Count; i++)
            {
                Bodys[i].Move();
            }
            Bodys.Add(bodyNew);
            segment = false;         
        }
        else
        {
        
            for (int i = 0; i < Bodys.Count; i++)
            {
                Bodys[i].Move();
            }
        }
        for (int i = Bodys.Count-1; i >0; i--)
        {
            Bodys[i].Left = Bodys[i - 1].Left;
            Bodys[i].Right = Bodys[i - 1].Right;
            Bodys[i].Up = Bodys[i - 1].Up;
            Bodys[i].Down = Bodys[i - 1].Down;

        }
         Bodys[0].Left = Left;
        Bodys[0].Right =Right;
        Bodys[0].Up =Up;
        Bodys[0].Down = Down;
        Console.WriteLine("  Bodys[0].Left " + Bodys[0].Left);
        move = true;
     
    }

    private void MoveVertical(int value)
    {
        position.y += value*2;
        rotation.z += value * 90;
    }

    private void MoveHorizontal(int value)
    {
        position.x += value*2;
        rotation.z += value * 90;
    }

    private void TheEnd()
    {
        Theend.SetActive(true);
        bodys.SetActive(false);
        gameObject.SetActive(false);
    }

    public void PlusObject()
    {
        segment = true;
       
    }
}