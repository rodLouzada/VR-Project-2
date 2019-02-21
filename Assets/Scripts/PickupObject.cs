using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public Transform holder;
    Rigidbody rb;
    private Vector3 posOffset;
    private Quaternion rotOffset;
    private float savemaxangvel;
    private bool saveGravity;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(holder != null)
        {
            Vector3 dPos = holder.localToWorldMatrix.MultiplyPoint(posOffset);
            Vector3 cPos = this.transform.position;

            Quaternion dRot = holder.rotation * rotOffset;
            Quaternion cRot = this.transform.rotation;

            Quaternion offsetRot = dRot * Quaternion.Inverse(cRot);
            float angle; Vector3 axis;
            offsetRot.ToAngleAxis(out angle, out axis);
            Vector3 rotDiff = angle * Mathf.Deg2Rad * axis;

            rb.velocity = (dPos - cPos) / Time.fixedDeltaTime;
            rb.angularVelocity = rotDiff / Time.fixedDeltaTime;
        }
    }

    public void pickedUp (Transform t)
    {
        posOffset = t.worldToLocalMatrix.MultiplyPoint(this.transform.position);
        rotOffset =  Quaternion.Inverse(t.rotation) * this.transform.rotation;
        saveGravity = rb.useGravity;
        //rb.useGravity = false;
        savemaxangvel = rb.maxAngularVelocity;
        rb.maxAngularVelocity = Mathf.Infinity;
        holder = t;
    }

    public void released (Transform t, Vector3 vel)
    {
        if (t == holder)
        {
            rb.useGravity = saveGravity;
            rb.maxAngularVelocity = savemaxangvel;
            rb.velocity = vel;
            holder = null;
        }
    }
}
