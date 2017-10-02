using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
	public static Inventario inv = null;
    public InventoryItems[][] _items = new InventoryItems[7][];

    public struct InventoryItems
    {
        public Items item;
        public int count;
    }

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
			_items [i] = new InventoryItems[42];
		}
	}

	public void addItem(Items item)
    {
        for (int i = 0; i<_items.Length; i++)
        {
            for(int j = 0; j <_items[i].Length; j++)
            {
                Items auxItem = _items[i][j].item;

				if (auxItem.GetType () == typeof(Consumibles)) 
				{
					if (_items [i] [j].item == null) {
						_items [i] [j].item = item;
						break;
					} else if (_items [i] [j].item == item && _items[i][j].count<100) 
					{
						_items [i] [j].count++;
						break;
					}
				} else if (_items [i] [j].item == null) 
				{
					_items [i] [j].item = item;
					break;
				}
            }
        }
	}
	
    public void Use(int tabIndex, int itemIndex, PlayerBase _player)
    {
        _items[tabIndex][itemIndex].item.Use(_player);
    }

    public void Throw(int tabIndex, int itemIndex)
    {
        _items[tabIndex][itemIndex].item.Throw();
    }

    public void Sell(int tabIndex, int itemIndex, PlayerBase _player)
    {
        _items[tabIndex][itemIndex].item.Sell(_player);
    }

    public void Buy(int tabIndex, int itemIndex, PlayerBase _player)
    {
        _items[tabIndex][itemIndex].item.Buy(_player);
    }

    public void Upgrade(int tabIndex, int itemIndex, PlayerBase _player)
    {
        _items[tabIndex][itemIndex].item.Upgrade(_player);
    }

    public void Repair(int tabIndex, int itemIndex, PlayerBase _player)
    {
        _items[tabIndex][itemIndex].item.Repair(_player);
    }
}