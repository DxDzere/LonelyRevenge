using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
	//public static Inventario inv = null;

	Items[][] _items = new Items[7][];
	[SerializeField]JSONLoader _loader;

	/*void Awake()
	{
		if (inv == null) {
			inv = this;
		} else if (inv != null) {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);
	}*/

	void Start()
	{
		for (int i = 0; i < _items.Length; i++)
		{
			_items [i] = new Items[42];
		}
		addItem (_loader);
		Debug.Log(_items[0][0].itemName);
	}

	void addItem(JSONLoader _loader)
	{
		_items [0] [0] = _loader.armasArray [0];
	}

		
}