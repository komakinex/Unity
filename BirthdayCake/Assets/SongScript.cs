using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongScript : MonoBehaviour {

	private AudioSource audio;

	// Use this for initialization
	void Start () {
		audio = gameObject.GetComponent<AudioSource>();

	}
}
