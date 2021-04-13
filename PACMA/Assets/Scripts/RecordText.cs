using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordText : MonoBehaviour
{
    private Text textoRecord;

    void Start()
    {
        textoRecord = GetComponent<Text>();
        textoRecord.text = GameManager.instance.getRecord().ToString();
    }
}
