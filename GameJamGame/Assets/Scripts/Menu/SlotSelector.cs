using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class SlotSelector : MonoBehaviour
{
    public PlayerSelect selector;
    [HideInInspector]
    public int navPos = 0;
    public int startPos = 0;


    public Transform[] slots = new Transform[3];

    public int Player;

    //to extract to key configure
    private KeyCode p1l = KeyCode.A;
    private KeyCode p1r = KeyCode.D;
    private KeyCode p1u = KeyCode.W;
    private KeyCode p1d = KeyCode.S;


    private KeyCode p1go = KeyCode.Space;

    private KeyCode p2l = KeyCode.LeftArrow;
    private KeyCode p2r = KeyCode.RightArrow;
    private KeyCode p2u = KeyCode.UpArrow;
    private KeyCode p2d = KeyCode.DownArrow;
    private KeyCode p2go = KeyCode.Return;

    private KeyCode left;
    private KeyCode right;
    private KeyCode up;
    private KeyCode down;
    private KeyCode go;

    void Start()
    {
        MoveNav(startPos);
        if (Player == 1) {
            left = p1l;
            right = p1r;
            up = p1u;
            down = p1d;
            go = p1go;
        }

        if (Player == 2) {
            left = p2l;
            right = p2r;
            up = p2u;
            down = p2d;
            go = p2go;
        }

    }
    void Update()
    {
        // move up
        if (Input.GetKeyDown(go))
        {
            SelectCharacter(navPos);

        }

        if (Input.GetKeyDown(left) || Input.GetKeyDown(up))
        {
            MoveNav(-1);
        }


        if (Input.GetKeyDown(right) || Input.GetKeyDown(down))
        {
            MoveNav(1);
        }

    }

    private void SelectCharacter(int navPos)
    {

    }

    public void setNavPosition(int pos) {
        if (0 <= pos && pos < slots.Length) {
            navPos = pos;
        }
    }

    void MoveNav(int change)
    {
        if (change > 0)
        {
            if (navPos + change < slots.Length - 1)
            {
                navPos += change;
            }
            else
            {
                navPos = slots.Length - 1;
            }
        }
        else
        {
            if (navPos + change >= 0)
            {
                navPos += change;
            }
            else
            {
                navPos = 0;
            }
        }
        selector.moveTo(slots[navPos].position.x, slots[navPos].position.y);
    }

 
}
