using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckObjectInArea : CheckingForGate
{
    [SerializeField]
    private string TargetTag;

    private List<Collider2D> CollidersOnArea = new List<Collider2D>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == TargetTag)
        {
            AddCollider(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == TargetTag)
        {
            RemoveCollider(collision);
        }
    }

    private void AddCollider(Collider2D col)
    {
        if(CollidersOnArea.Count == 0)
        {
            SetOkTo(true);
        }

        CollidersOnArea.Add(col);
    }

    private void RemoveCollider(Collider2D col)
    {
        CollidersOnArea.Remove(col);

        if (CollidersOnArea.Count == 0)
        {
            SetOkTo(false);
        }
    }


}
