using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSignImg : MonoBehaviour
{
    [SerializeField] private static List<Texture> textures;
    public static int lastHospitalImg = 3;
    public static Color[] colores = { Color.red, Color.blue, Color.green };

    private RawImage img;

    void Start()
    {
        if (textures == null) textures = new List<Texture>();
        img = GetComponentInChildren<RawImage>();
    }

    public static int GetTexturesSize() { return textures.Count; }
    public static Color[] GetColors() { return colores; }
    public static Color GetRandomColor() { return colores[Random.Range(0, colores.Length)]; }

    public void SetImg(int id, Color color)
    {
        if (id < lastHospitalImg) Debug.Log("Es un hospital");
        else Debug.Log("No es un hospital");

        if (id < textures.Count - 1)
        {
            img.texture = textures[id];
            img.color = color;
            img.transform.localScale = new Vector3(transform.localScale.x, img.transform.localScale.y, img.transform.localScale.z);
        }
    }
}