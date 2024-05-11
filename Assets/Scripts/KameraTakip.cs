using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTakip : MonoBehaviour
{
    public Transform hedef;
    public Vector3 offset;
    public float yumusakDegeri = 0.125f;

    private void LateUpdate()
    {
        Vector3 takipPozisyonu = hedef.position + offset;
        transform.position = Vector3.Lerp(transform.position, takipPozisyonu, yumusakDegeri);

        transform.LookAt(hedef);
    }
}
