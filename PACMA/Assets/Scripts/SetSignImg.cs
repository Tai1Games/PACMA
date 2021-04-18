using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSignImg : MonoBehaviour
{
    public List<Texture> textures;
    public static Color[] colores = { Color.red, Color.blue, Color.green };
    public static int numTextures = 0;

    private RawImage img;

    void Start()
    {
        img = GetComponentInChildren<RawImage>();
        if (numTextures == 0) numTextures = textures.Count;
    }

    public int GetTexturesSize() { return textures.Count; }
    public static Color[] GetColors() { return colores; }
    public static Color GetRandomColor() { return colores[Random.Range(0, colores.Length)]; }

    public void SetImg(int id, Color color)
    {
        //Debug.Log("este es mi id de señal: " + id);
        if (img == null) img = GetComponentInChildren<RawImage>();      // puto orden

        if (id < textures.Count - 1)
        {
            img.texture = textures[id];
            img.color = color;
            // rotar por si el cartel apunta al otro lado
            if(img.transform.localScale.y < 0)
                img.transform.localScale = new Vector3(transform.localScale.x, -1 * transform.localScale.y, img.transform.localScale.z);
        }
        else Debug.Log("??? y esta id de señal???");
    }
}