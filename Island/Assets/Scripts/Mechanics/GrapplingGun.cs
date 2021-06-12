using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
    private LineRenderer lr;
    private Vector3 grapplePosition;
    public LayerMask grappleableObject;

    public Transform objTip;
    public Transform cam;
    public Transform player;

    private float maxGrappleDistance = 100f;
    private SpringJoint joint;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            StartGrapple();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopGrapple();
        }
    }

    private void LateUpdate()
    {
        DrawRope();
    }

    /// <summary>
    /// 
    /// </summary>
    void StartGrapple()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.position,cam.forward,out hit, maxGrappleDistance,grappleableObject))
        {
            grapplePosition = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePosition;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePosition);

            //distance we try to keep from grap point
            joint.maxDistance = distanceFromPoint * 0.7f;
            joint.minDistance = distanceFromPoint * 0.2f;

            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;

            lr.positionCount = 2;
        }

    }

    void DrawRope()
    {
        if (!joint) return;
        lr.SetPosition(0, objTip.position);
        lr.SetPosition(1, grapplePosition);
    }

    void StopGrapple()
    {
        lr.positionCount = 0;
        Destroy(joint);
    }

    public bool IsGrappling()
    {
        return joint != null;
    }

    public Vector3 GetGrapplePoint()
    {
        return grapplePosition;
    }
}
