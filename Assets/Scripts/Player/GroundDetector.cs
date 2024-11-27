using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    // Variables publicas
    public float radius;
    public LayerMask detectedLayers;

    // Variables privadas
    private bool isGrounded;

    private void Update()
    {
        ChechGround();
    }

    public void ChechGround()
    {
        isGrounded = Physics.CheckSphere(transform.position, radius, detectedLayers);
    }

    public bool GetIsGrounded()
    {
        return isGrounded;
    }
}
