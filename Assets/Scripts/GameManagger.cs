using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagger : MonoBehaviour
{
	public static GameManagger instancia = null;
	public GameObject instanciaPersonaje;
	public GameObject instanciaInventario;

	void Awake()
	{
		if (instancia == null) {
            instancia = this;
		} else if (instancia != null) {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);
		//iniciaPrsonaje ();
		iniciaInventario ();
	}

	/*void iniciaPersonaje()
	{
		if (personaje.pj == null)
		{
			Instantiate (instanciaPersonaje);
		}
	}*/

	void iniciaInventario()
	{
		if (Inventario.inv == null)
		{
			Instantiate (instanciaInventario);
		}
	}

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
