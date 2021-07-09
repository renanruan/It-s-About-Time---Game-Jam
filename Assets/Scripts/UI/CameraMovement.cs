using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Vector2 MiddlePosition;


    [SerializeField]
    private GameObject TargetToFollow;


    [SerializeField]
    private Vector2 TargetBondarys;


    [SerializeField]
    private float Speed;

    [SerializeField]
    private Vector3 TargetPosition;


    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CalculateTargetRelativePosition();

        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, Speed * Time.deltaTime);

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            LevelTransitioner.RestartScene();
        }
    }

    private void CalculateTargetRelativePosition()
    {
        TargetPosition = new Vector3( TargetToFollow.transform.position.x / 4.5f, TargetToFollow.transform.position.y / 2.5f, -10f);
    }
}
