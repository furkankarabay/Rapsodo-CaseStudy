using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;

    private void LateUpdate()
    {
        transform.LookAt(transform.position + playerCamera.forward);
    }
}
