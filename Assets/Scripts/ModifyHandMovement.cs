using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;

public class ModifyHandMovement: PostProcessProvider
{
    [SerializeField]
    private Transform headTransform;

    [SerializeField]
    private float projectionScale = 10f;

    [SerializeField]
    private float handMergeDistance = 0.35f;

    [SerializeField]
    private float polyCoefA = 2f;

    [SerializeField]
    private float polyCoefB = 2f;

    [SerializeField]
    private float polyCoefC = 2f;

    [SerializeField]
    private float polyCoefD = 2f;

    [SerializeField]
    private float polyCoefE = 2f;

    public override void ProcessFrame(ref Frame inputFrame)
    {
        // Calculate the position of the head and the basis to calculate shoulder position.
        if (headTransform == null)
        {
            headTransform = Camera.main.transform;
        }

        Vector3 headPos = headTransform.position;

        var shoulderBasis = Quaternion.LookRotation(
        Vector3.ProjectOnPlane(headTransform.forward, Vector3.up),
        Vector3.up);

        foreach (var hand in inputFrame.Hands)
        {
            // Approximate shoulder position with magic values.
            Vector3 shoulderPos = headPos
                                + (shoulderBasis * (new Vector3(0f, -0.13f, -0.1f)
                                + Vector3.left * 0.15f * (hand.IsLeft ? 1f : -1f)));

            // Calculate the projection of the hand if it extends beyond the
            // handMergeDistance.
            Vector3 shoulderToHand = hand.PalmPosition - shoulderPos;
            float handShoulderDist = shoulderToHand.magnitude;
            float projectionDistance = Mathf.Max(0f, handShoulderDist - handMergeDistance);

            float polynomialProjection = polyCoefA * Mathf.Pow(projectionDistance, 4) + polyCoefB * Mathf.Pow(projectionDistance, 3) + polyCoefC * Mathf.Pow(projectionDistance, 2) + polyCoefD * projectionDistance + polyCoefE;

            float projectionAmount = 1f + (polynomialProjection * projectionScale);

            hand.SetTransform(shoulderPos + shoulderToHand * projectionAmount,
                            hand.Rotation);
        }
    }
}