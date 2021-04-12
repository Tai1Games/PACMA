using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManger : MonoBehaviour
{
	public Material[] arrayMateriales;

	public Color[] colores;

	public int offset = 0;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		for (int i = 0; i < arrayMateriales.Length; i++)
		{
			arrayMateriales[i].color = colores[(i + offset)%colores.Length];
		}
	}
}
