using Ring;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisiableCup : MonoBehaviour
{
    [ChangeColorLabel(0.2f, 1, 1)] public Material myMaterial;
    [ChangeColorLabel(0.2f, 1, 1)] public Material invisiableMaterial;
    [ChangeColorLabel(0.2f, 1, 1)] public MeshRenderer _material;
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(Settings.Tag_Player))
        {
            _material.material = myMaterial;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Settings.Tag_Player))
        {
            _material.material = invisiableMaterial;
        }
    }
}
