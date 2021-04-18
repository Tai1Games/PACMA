using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosCartel : MonoBehaviour
{
    /// <summary>
    /// Aqu� va el empty colocado en la posici�n donde ir� el poste
    /// </summary>
    [SerializeField] GameObject posicionCartel;

    public Vector3 GetPos() { return posicionCartel.transform.position; }
}
