using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEndPoint : MonoBehaviour
{
    [SerializeField]
    private Vector2 BoxSize;

    private LayerMask playerLayer;

    private RaycastHit2D detected;

    void Start()
    {
        CreatePlayerLayer();
    }

    private void CreatePlayerLayer()
    {
        playerLayer = LayerMask.GetMask("Player");
    }


    private void Update()
    {
        LookForPlayer();

        if (DoesFindPlayer())
        {
            EndLevel();
        }
    }

    private void LookForPlayer()
    {
        detected = Physics2D.BoxCast(transform.position, BoxSize, 0, Vector2.zero, 0, playerLayer);
    }

    private bool DoesFindPlayer()
    {
        return detected.collider != null;
    }

    private void EndLevel()
    {
        LevelTransitioner.ChangeToScene("SampleScene2");
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position, BoxSize);
    }
}
