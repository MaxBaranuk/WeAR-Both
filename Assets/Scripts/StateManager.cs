using UnityEngine;
using System.Collections;

public class StateManager : MonoBehaviour 
{
	public static StateManager instance;

	public States states;

	void Awake()
	{
		if (instance == null) 
		{
			instance = this;
		}
        states = States.Start;
    }

    public void StartState()
    {
        states = States.Start;
    }

    public void BrickState()
	{
		states = States.Brick;
		UIManager.instance.next.SetActive (true);
		UIManager.instance.prev.SetActive (false);
		UIManager.instance.clickCount = 0;
		UIManager.instance.currentMode = UIManager.instance._brick;
	}

	public void TileState()
	{
		states = States.Tiles;
		UIManager.instance.next.SetActive (true);
		UIManager.instance.prev.SetActive (false);
		UIManager.instance.clickCount = 0;
		UIManager.instance.currentMode = UIManager.instance._tiles;
	}

	public void ConcreteState()
	{
		states = States.Concrete;
		UIManager.instance.next.SetActive (true);
		UIManager.instance.prev.SetActive (false);
		UIManager.instance.clickCount = 0;
		UIManager.instance.currentMode = UIManager.instance._concrete;
	}

	public void DoreColorState()
	{
		states = States.DoreColor;
		UIManager.instance.next.SetActive (true);
		UIManager.instance.prev.SetActive (false);
		UIManager.instance.clickCount = 0;
		UIManager.instance.currentColor = UIManager.instance._doreCase;

	}

	public void DoreTextureState()
	{
		states = States.DoreTexture;
		UIManager.instance.next.SetActive (true);
		UIManager.instance.prev.SetActive (false);
		UIManager.instance.clickCount = 0;
		UIManager.instance.currentMode = UIManager.instance._mainDore;
	}

	public void MetalColorState()
	{
		states = States.MetalColor;
		UIManager.instance.next.SetActive (true);
		UIManager.instance.prev.SetActive (false);
		UIManager.instance.clickCount = 0;
		UIManager.instance.currentColor = UIManager.instance._metalColor;
	}

	public void WindowFrameState()
	{
		states = States.WindowFrame;
		UIManager.instance.next.SetActive (true);
		UIManager.instance.prev.SetActive (false);
		UIManager.instance.clickCount = 0;
		UIManager.instance.currentColor = UIManager.instance._windowFrame;
	}
}
