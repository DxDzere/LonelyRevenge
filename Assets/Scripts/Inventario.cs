using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
	public static Inventario inv = null;

	Items[][] _items = new Items[7][];
    Items functions;

	void Awake()
	{
		if (inv == null) {
			inv = this;
		} else if (inv != null) {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);
	}

	void Start()
	{
		for (int i = 0; i < _items.Length; i++)
		{
			_items [i] = new Items[42];
		}
	}

	void addItem(GameObject item)
	{
		for(int i = 0; i<_items.Length; i++)
        {
            for(int j = 0; j <_items[i].Length; j++)
            {
                if(_items[i][j] == null)
                {
                    _items[i][j] = item;
                    break;
                }
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Item")
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                addItem(GameObject.FindWithTag("Item"));
            }
        }
    }

    public void Use(PlayerBase _player)
    {
        functions.Use(_player);
    }

    public void Throw()
    {
        functions.Throw();
    }

    public void Sell(PlayerBase _player)
    {
        functions.Sell(_player);
    }

    public void Buy(PlayerBase _player)
    {
        functions.Buy(_player);
    }

    public void Upgrade(PlayerBase _player)
    {
        functions.Upgrade(_player);
    }

    public void Repair(PlayerBase _player)
    {
        functions.Repair(_player);
    }
}