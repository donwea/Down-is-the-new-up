﻿using UnityEngine;
using System.Collections;

public class ActiveTextAtLine : MonoBehaviour {

	
	public TextAsset theText;

	public int startLine;

	public int endLine;

	public TextBoxManager theTextBox;

	public bool destroyWhenActivated;

	public bool requireButtonPress;
	private bool waitForPress;

	// Use this for initialization
	void Start () {
	
		theTextBox = FindObjectOfType<TextBoxManager>();

	}
	
	// Update is called once per frame
	void Update () {

		if(waitForPress && Input.GetButtonDown("Interact"))
		{
			theTextBox.ReloadScript(theText);
			theTextBox.currentLine = startLine;
			theTextBox.endAtLine = endLine;
			theTextBox.EnableTextBox();

			if(destroyWhenActivated)
			{
				Destroy(gameObject);
			}
		}
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "Player")
		{	

			if(requireButtonPress)
			{
				waitForPress = true;
				return;
			}

			theTextBox.ReloadScript(theText);
			theTextBox.currentLine = startLine;
			theTextBox.endAtLine = endLine;
			theTextBox.EnableTextBox();

			if(destroyWhenActivated)
			{
				Destroy(gameObject);
			}
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.name == "Player")
		{
			waitForPress = false;
			
		}
	}
}

