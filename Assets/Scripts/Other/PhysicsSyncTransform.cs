using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsSyncTransform : MonoBehaviour
{
    void Update()
    {
        Physics.SyncTransforms();
    }
}
