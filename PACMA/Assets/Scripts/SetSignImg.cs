using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class SetSignImg : MonoBehaviour
{
    [SerializeField]
    private string signsPath = "Assets/Sprites/Carteles/signals.png";

    private List<Texture> textures;
    private RawImage img;
    private int act = 0;

    void Start()
    {
        textures = new List<Texture>();
        RellenaArrayTexturas();
        img = GetComponent<RawImage>();
    }

    private void Update()
    {
// ---------------------------------------- ESTO NO DEBE ESTAR AQUÍ -------------------------------------------------------------------------------------------------------------------
        if (textures.Count == 0)
        {
            textures = new List<Texture>();
            RellenaArrayTexturas();
            img = GetComponent<RawImage>();
        }
// ---------------------------------------- ESTO NO DEBE ESTAR AQUÍ -------------------------------------------------------------------------------------------------------------------

        if (textures.Count > 0)
            if (Input.GetKeyDown(KeyCode.Space))
            {
                act = ++act % textures.Count;
                img.texture = textures[act];
            }
    }

    void RellenaArrayTexturas() {
        Sprite[] sprites = Resources.LoadAll<Sprite>(signsPath);
        Debug.Log(sprites.Length);
        foreach (Sprite s in sprites) {
            textures.Add(SpriteToTexture(s));
        }
    }

    static Texture2D SpriteToTexture(Sprite sprite)
    {
        Texture2D croppedTexture = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
        Color[] pixels = sprite.texture.GetPixels((int)sprite.textureRect.x,
                                                (int)sprite.textureRect.y,
                                                (int)sprite.textureRect.width,
                                                (int)sprite.textureRect.height);
        croppedTexture.SetPixels(pixels);
        croppedTexture.Apply();
        return croppedTexture;
    }
}