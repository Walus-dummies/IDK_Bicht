using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climber : MonoBehaviour
{
    // Variables privadas
    private bool isClimbing;

    // Start is called before the first frame update
    void Start()
    {
        isClimbing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isClimbing = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Stair"))
        {
            isClimbing = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Stair"))
        {
            isClimbing = false;
        }
    }

    public bool IsClimbing()
    {
        return isClimbing;
    }
}
