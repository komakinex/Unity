﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kaitenCamera : MonoBehaviour {
	GameObject targetObj;
	Vector3 targetPos;

	// Use this for initialization
	void Start () {
		targetObj = GameObject.Find("TargetObject");
		targetPos = targetObj.transform.position;
	}

	// Update is called once per frame
	void Update () {

		// targetの移動分、カメラも移動する
		transform.position += targetObj.transform.position - targetPos;
		targetPos = targetObj.transform.position;

		// マウスの右クリックを押している間
		if (Input.GetMouseButton(1)){

			//マウスの移動量
			float  mouseInputX = Input.GetAxis("Mouse X");
			float  mouseInputY = Input.GetAxis("Mouse Y");

			//targetの位置のy軸を中心に、公転する
			transform.RotateAround(targetPos, Vector3.up, mouseInputX * Time.deltaTime * 200f);

			//カメラの垂直移動（角度制限なし）
			transform.RotateAround(targetPos, transform.right, mouseInputY * Time.deltaTime * 200f);

		}
	}
}
