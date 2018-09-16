using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTest : MonoBehaviour {

	public LayerMask mask;

	void Ray(){
		Ray ray = new Ray(transform.position, transform.forward);
		Ray moueRay = Camera.main.ScreenPointToRay(Input.mousePosition);

		// 2.
// Rayが衝突したコライダーの情報を得る
RaycastHit hit;
// Rayが衝突したかどうか
if(Physics.Raycast(ray, out hit, 10.0f, mask)) {
	// Examples
	// 衝突したオブジェクトの色を赤に変える
	hit.collider.GetComponent<MeshRenderer>().material.color = Color.red;
	// 衝突したオブジェクトを消す
	Destroy(hit.collider.gameObject);
	// Rayの衝突地点に、このスクリプトがアタッチされているオブジェクトを移動させる
	this.transform.position = hit.point;
	// Rayの原点から衝突地点までの距離を得る
	float dis = hit.distance;
	// 衝突したオブジェクトのコライダーを非アクティブにする
	hit.collider.enabled = false;
} 


		Debug.DrawRay(ray.origin, ray.direction, Color.red, 3.0f);
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
