using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class ControlsTeacher : MonoBehaviour
{
	public CanvasRenderer flechaDer;
	public CanvasRenderer flechaIz;
	public CanvasRenderer flechaRecto;

	public RectTransform BarraVolumen;
	public float minValueBarra = 0.1f;
	public float sensibilidadBarra = 100;
	public CanvasRenderer[] numeros;

	public CanvasRenderer Tickverde;
	private int progreso = 0;
	private float volActual = 0;
	private bool dejaDeGritar = false;

	void Start()
	{
		flechaDer.SetAlpha(0);
		flechaIz.SetAlpha(0);
		flechaRecto.SetAlpha(0);
		BarraVolumen.anchorMin = new Vector2(BarraVolumen.anchorMin.x, minValueBarra);
		foreach (CanvasRenderer num in numeros)
		{
			num.SetAlpha(0);
		}
		Tickverde.SetAlpha(0);
	}

	void Update()
	{

		if (progreso >= 4)
		{
			Tickverde.SetAlpha(1);
			Debug.Log("Cambiando Escena");
		}
		else
		{
			foreach (CanvasRenderer num in numeros)
			{
				num.SetAlpha(0);
			}
			numeros[progreso].SetAlpha(1);
		}

		if (!dejaDeGritar) BarraVolumen.anchorMin = new Vector2(BarraVolumen.anchorMin.x, (volActual * sensibilidadBarra / (1 - minValueBarra)) + minValueBarra);

		if (!dejaDeGritar && volActual >= 1)
		{
			progreso++;
			dejaDeGritar = true; //por favor para ya
		}
	}

	public void sendCommand(string command)
	{
		switch (command)
		{
			case "derecha":
				if (flechaDer.GetAlpha() < 1f) progreso++;
				flechaDer.SetAlpha(1);
				break;
			case "izquierda":
				if (flechaIz.GetAlpha() < 1f) progreso++;
				flechaIz.SetAlpha(1);
				break;
			case "recto":
				if (flechaRecto.GetAlpha() < 1f) progreso++;
				flechaRecto.SetAlpha(1);
				break;
		}
	}

	public void actualizaVolumen(float vol)
	{
		volActual = vol;
	}
}
