using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;   // 追加(DateTimeを使う)
using UnityEngine.UI;

public class Move : MonoBehaviour
{

	public GameObject text;

	// Use this for initialization
	void Start ()
	{
		text = GameObject.Find("Text");

	}

	// Update is called once per frame
	void Update ()
	{
		transform.position += new Vector3 (0, 0, - 0.01f);

		DateTime dateTime = DateTime.Now;
		text.GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB (dateTime.Second/60f, 1f, 1f);
	}
}
