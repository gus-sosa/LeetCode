<Query Kind="Program" />

void Main()
{
	var obj = new MyHashMap();
	(obj.Get(8)==-1).Dump();
	obj.Remove(1);
	obj.Put(2,1);
	(obj.Get(8)==-1).Dump();
	(obj.Get(2)==1).Dump();
	obj.Remove(2);
	(obj.Get(2)==-1).Dump();
}

public class MyHashMap
{
	private int[] arr;
	private bool[] occupied;
	private const int arr_size = 1000001;
	/** Initialize your data structure here. */
	public MyHashMap()
	{
		arr = new int[arr_size];
		occupied = new bool[arr_size];
	}

	/** value will always be non-negative. */
	public void Put(int key, int value)
	{
		arr[key] = value;
		occupied[key] = true;
	}

	/** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
	public int Get(int key)
	{
		if (!occupied[key])
		{
			return -1;
		}
		return arr[key];
	}

	/** Removes the mapping of the specified value key if this map contains a mapping for the key */
	public void Remove(int key)
	{
		occupied[key] = false;
	}
}