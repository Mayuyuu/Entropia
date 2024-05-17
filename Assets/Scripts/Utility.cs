using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class Utility
{
    public static void HandleSlopes(Transform transform, LayerMask GroundLayerMask, float RayLength)
    {
        Quaternion rotateTarget;
        Vector2 originRayCast = new Vector2(transform.position.x, transform.position.y + 1);
        RaycastHit2D hit = Physics2D.Raycast(originRayCast, Vector2.down, RayLength, GroundLayerMask);
        if (hit.transform == transform)
        {
            return;
        }

        if (hit)
        {

            float slopeAngle = Vector2.Angle(hit.normal, Vector2.up);
            float direction = Mathf.Sign(hit.normal.x);
            if ((slopeAngle > 0 && slopeAngle < 50))
            {

                rotateTarget = Quaternion.Euler(0, 0, direction * (-slopeAngle));
            }
            else
            {
                rotateTarget = Quaternion.identity;
            }
        }
        else
        {
            rotateTarget = Quaternion.identity;
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, rotateTarget, 0.1f);
        Debug.DrawRay(originRayCast, Vector2.down * 2, Color.green);
    }
}