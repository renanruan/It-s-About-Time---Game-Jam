using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSideChecker : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer PlayerUnit;
    [SerializeField]
    private SpriteRenderer PlayerGun;
    [SerializeField]
    private SpriteRenderer PlayerAim;

    [SerializeField]
    private PlayerAimCursor AimCursor;


    private Vector3 RIGHT_PLAYER_SCALE = new Vector3(1, 1, 1);
    private Vector3 LEFT_PLAYER_SCALE = new Vector3(-1, 1, 1);

    private Vector3 RIGHT_GUN_SCALE = new Vector3(1, 1, 1);
    private Vector3 LEFT_GUN_SCALE = new Vector3(1, -1, 1);

    private int UP_GUN_ORDER = -1;
    private int DOWN_GUN_ORDER = 1;

    private void Start()
    {
        RegisterCursorMoveEvent();
    }

    private void RegisterCursorMoveEvent()
    {
        AimCursor.MouseMoved += OnCursorMove;
    }

    private void OnCursorMove()
    {
        if (IsMouseOnRightSide())
        {
            LookToRight();
        }
        else
        {
            LookToLeft();
        }

        if (IsMouseOnUpSide())
        {
            GunPointUp();
        }
        else
        {
            GunPointDown();
        }
    }

    private bool IsMouseOnRightSide()
    {
        return PlayerAim.transform.position.x > PlayerUnit.transform.position.x;
    }

    private void LookToRight()
    {
        PlayerLookRight();
        GunPointRight();
    }

    private void PlayerLookRight()
    {
        PlayerUnit.transform.localScale = RIGHT_PLAYER_SCALE;
    }

    private void GunPointRight()
    {
        PlayerGun.transform.localScale = RIGHT_GUN_SCALE;
    }

    private void LookToLeft()
    {
        PlayerLookLeft();
        GunPointLeft();
    }

    private void PlayerLookLeft()
    {
        PlayerUnit.transform.localScale = LEFT_PLAYER_SCALE;
    }

    private void GunPointLeft()
    {
        PlayerGun.transform.localScale = LEFT_GUN_SCALE;
    }

    private bool IsMouseOnUpSide()
    {
        return PlayerAim.transform.position.y > PlayerUnit.transform.position.y;
    }

    private void GunPointUp()
    {
        PlayerGun.sortingOrder = UP_GUN_ORDER;
    }

    private void GunPointDown()
    {
        PlayerGun.sortingOrder = DOWN_GUN_ORDER;
    }
}
