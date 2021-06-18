using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform cam;

    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
