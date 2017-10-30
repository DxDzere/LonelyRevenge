using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
	public static Inventario inv = null;
    public List<List<InventoryItems>> _items;
    //public InventoryItems[][] _items = new InventoryItems[7][];

    public class InventoryItems
    {
        public Items item;
        public int itemCant;
    }

	void Awake()
	{
		if (inv == null) {
			inv = this;
		} else if (inv != null) {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);
        _items = new List<List<InventoryItems>>();
	}

	void Start()
	{
		for (int i = 0; i < _items.Count; i++)
		{
            _items[i] = new List<InventoryItems>();
		}
	}

	public void addItem(Items item)
    {
        for (int i = 0; i<_items.Count; i++)
        {
            for(int j = 0; j <_items[i].Count; j++)
            {
                Items auxItem = _items[i][j].item;
                if (_items[i][j]==_items[i][42])
                {
                    if (auxItem.GetType() == typeof(Consumibles))
                    {
                        if (_items[i][j].item == null) {
                            _items[i][j].item = item;
                            break;
                        } else if (_items[i][j].item == item && _items[i][j].itemCant < 100)
                        {
                            _items[i][j].itemCant++;
                            break;
                        }
                    } else if (_items[i][j].item == null)
                    {
                        _items[i][j].item = item;
                        break;
                    }
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
        _items[tabIndex][itemIndex].itemCant -= 1;
        if(_items[tabIndex][itemIndex].itemCant == 0)
        {
            _items[tabIndex].RemoveAt(itemIndex);
        }
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