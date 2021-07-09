using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{

    [Header("Unit Movement Parameters")]

    public float DistanceFromObjectCenterToBorder = 0.5f;

    [SerializeField]
    protected UnitAge UnitCurrentAge;

    protected float CurrentVerticalSpeed = 0;
    protected float CurrentHorizontalSpeed = 0;

    private ContactFilter2D solidsFilter2D;

    private Vector3 pathToWalk;

    private RaycastHit2D[] detectedSolids;

    private const int MAXSOLIDS = 3;

    [SerializeField]
    private PlayerAnimationControl DeathAnimator;

    protected void StartUnitMoviment()
    {
        CreateSolidFilter();
        UseTriggerFilter();
    }

    private void CreateSolidFilter()
    {
        solidsFilter2D = new ContactFilter2D();
        solidsFilter2D.SetLayerMask(LayerMask.GetMask("Wall","Object"));
    }

    private void UseTriggerFilter()
    {
        solidsFilter2D.useTriggers = true;
    }

    protected void MoveUsingSpeed()
    {
        CreatePathFromSpeed();
        TrimPathUsingSolids();
        PushSolidsOnPath();
        MoveAlongPath();
    }

    private void CreatePathFromSpeed()
    {
        pathToWalk = new Vector3(CurrentHorizontalSpeed, CurrentVerticalSpeed) * Time.deltaTime;
    }

    private void TrimPathUsingSolids()
    {
        FindSolidsAlongPath();
        RemoveTangentSolids();
        TrimPathOnSolidHitting();
    }

    private void FindSolidsAlongPath()
    {
        detectedSolids = new RaycastHit2D[MAXSOLIDS];

        Physics2D.CircleCast(origin: transform.position, radius: DistanceFromObjectCenterToBorder, direction: pathToWalk, 
            contactFilter: solidsFilter2D, results: detectedSolids, distance: pathToWalk.magnitude);
    }

    private void RemoveTangentSolids()
    {
        List<RaycastHit2D> solidsHitted = new List<RaycastHit2D>();

        foreach (RaycastHit2D solid in detectedSolids)
        {
            // Case not hitting any solid
            if (solid.collider == null)
                break;

            // Case hitting walls in different directions from movement
            if (Vector3.Angle((Vector3)solid.point - transform.position, pathToWalk) >= 90)
                continue;

            // Case hitting yourself
            if (solid.transform.parent == transform)
                continue;

            solidsHitted.Add(solid);
        }


        detectedSolids = solidsHitted.ToArray();
    }

    private void TrimPathOnSolidHitting()
    {
        foreach (RaycastHit2D solid in detectedSolids)
        {
            Vector3 distanceImpactToUnit = (Vector3)solid.point - transform.position;

            distanceImpactToUnit = Vector3.Project(distanceImpactToUnit, solid.normal);

            Vector3 minimalDistanceImpactToUnit = distanceImpactToUnit.normalized * DistanceFromObjectCenterToBorder;

            minimalDistanceImpactToUnit = distanceImpactToUnit - minimalDistanceImpactToUnit;

            Vector3 excessAlongNormal = Vector3.Project(pathToWalk, solid.normal);

            pathToWalk = pathToWalk - excessAlongNormal + minimalDistanceImpactToUnit;
        }
    }

    private void PushSolidsOnPath()
    {
        if(CannotPush())
        {
            return;
        }

        PushSolids();
        MoveAlongPush();
    }

    private bool CannotPush()
    {
        return UnitCurrentAge != null && UnitCurrentAge.GetStageAge() == UnitAge.AgeStage.Young;
    }

    private void PushSolids()
    {
        foreach (RaycastHit2D solid in detectedSolids)
        {
            if (solid.transform.parent.gameObject.tag.Contains("Pushable"))
            {
                solid.transform.parent.GetComponent<Pushable>().Push(-solid.normal);
            }
        }
    }

    private void MoveAlongPush()
    {
        foreach (RaycastHit2D solid in detectedSolids)
        {
            if (solid.transform.parent.gameObject.tag.Contains("Pushable"))
                pathToWalk += solid.transform.parent.GetComponent<Pushable>().GetSpeed() * Time.deltaTime;
        }
    }

    private void MoveAlongPath()
    {
        transform.position += pathToWalk;
    }

}
