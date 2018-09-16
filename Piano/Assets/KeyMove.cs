using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMove : MonoBehaviour {

	void Update () {
		// W.S.D.A押すと移動
		if (Input.GetKey(KeyCode.W)){
			transform.position += new Vector3(0, 0, 10 * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.S)){
			transform.position += new Vector3(0, 0,- 10 * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.D)){
			transform.position += new Vector3(10 * Time.deltaTime, 0, 0);
		}
		if (Input.GetKey(KeyCode.A)){
			transform.position += new Vector3(- 10 * Time.deltaTime, 0, 0);
		}

		// 押すと伸びる
		if(Input.GetKey(KeyCode.I)){
		transform.localScale += new Vector3(0,0,1 * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.K)){
		transform.localScale += new Vector3(0,0,-1 * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.L)){
		transform.localScale += new Vector3(1 * Time.deltaTime,0,0);
		}
		if(Input.GetKey(KeyCode.J)){
		transform.localScale += new Vector3(-1 * Time.deltaTime,0,0);
		}
	}
}
