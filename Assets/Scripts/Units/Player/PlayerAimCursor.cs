using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void MouveEvent();

public class PlayerAimCursor : MonoBehaviour
{
    [SerializeField]
    private GameObject AimCursor;

    [SerializeField]
    private GameObject PlayerUnit;

    private Vector3 LastPlayerPosition = Vector3.zero;

    private Vector3 LastMousePosition = Vector3.zero;

    private Vector3 WorldMousePosition = Vector3.zero;

    public event MouveEvent MouseMoved;

    void Update()
    {
        if (MouseHasMoved() || PlayerHasMoved())
        {
            MoveCursorWithMouse();
            SavePlayerPositionReference();
            CallMouseMoveEvent();
        }
    }

    private bool MouseHasMoved()
    {
        return Input.mousePosition != LastMousePosition;
    }

    private bool PlayerHasMoved()
    {
        return PlayerUnit.transform.position != LastPlayerPosition;
    }

    private void MoveCursorWithMouse()
    {
        FindMousePositionInWorld();
        MoveCursorToMousePositionInWorld();
    }

    private void SavePlayerPositionReference()
    {
        LastPlayerPosition = PlayerUnit.transform.position;
    }

    private void FindMousePositionInWorld()
    {
        LastMousePosition = Input.mousePosition;

        WorldMousePosition = Camera.main.ScreenToWorldPoint(LastMousePosition);

        WorldMousePosition.z = 0;
    }

    private void MoveCursorToMousePositionInWorld()
    {
        AimCursor.transform.position = WorldMousePosition;
    }

    private void CallMouseMoveEvent()
    {
        MouseMoved.Invoke();
    }

    public Vector3 GetAimDirectionFromPlayer()
    {
        return (AimCursor.transform.position - PlayerUnit.transform.position).normalized;
    }
}
