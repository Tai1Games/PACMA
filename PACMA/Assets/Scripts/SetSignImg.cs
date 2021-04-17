using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class SetSignImg : MonoBehaviour
{
    [SerializeField] private List<Texture> textures;
    [Range (0, 3)] public int lastHospitalImg = 3;

    private RawImage img;
    private int act = 0;

    public Color[] colores = { Color.red, Color.blue, Color.green };

    void Start()
    {
        // signsPath = Application.dataPath + signsPath;
        //textures = new List<Texture>();
        //RellenaArrayTexturas();
        img = GetComponentInChildren<RawImage>();
    }

    public Color[] GetColors() { return colores; }
    public Color GetRandomColor() { return colores[Random.Range(0, colores.Length)]; }

    private void Update()
    {
        if (textures.Count > 0)
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("NICE");
                act = (act + Random.Range(0, 113)) % (textures.Count - 1);     // -1 porque la ultima es blank
                SetImg(act, GetRandomColor());
            }
    }

    public void SetImg(int id, Color color)
    {
        if (id < lastHospitalImg) Debug.Log("Es un hospital");
        else Debug.Log("No es un hospital");

        if (id < textures.Count - 1)
        {
            img.texture = textures[act];
            img.color = color;
        }
    }


    //private int signalsCount = 30;
    //private string signsPath = "/Sprites/Carteles/cut/tile0";

    //void RellenaArrayTexturas() {
    //    Sprite[] sprites = new Sprite[signalsCount];
    //    for (int i = 0; i < signalsCount; i++)
    //    {
    //        sprites[i] = Resources.Load(signsPath + i.ToString() + ".png") as Sprite;
    //        //Debug.Log(signsPath + i.ToString() + ".png");
    //        textures.Add(SpriteToTexture(sprites[i]));
    //    }
    //}

    //static Texture2D SpriteToTexture(Sprite sprite)
    //{
    //    Texture2D croppedTexture = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
    //    Color[] pixels = sprite.texture.GetPixels((int)sprite.textureRect.x,
    //                                            (int)sprite.textureRect.y,
    //                                            (int)sprite.textureRect.width,
    //                                            (int)sprite.textureRect.height);
    //    croppedTexture.SetPixels(pixels);
    //    croppedTexture.Apply();
    //    return croppedTexture;
    //}
}