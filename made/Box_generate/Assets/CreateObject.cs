using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour {
	public GameObject obj;
	public float lifeTime;

	void Start (){
		Destroy(gameObject, lifeTime);
	}

	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit = new RaycastHit();

		//左クリックした場合
		if (Input.GetMouseButtonDown(0)){
			//レイを投げて何かのオブジェクトに当たった場合
			if (Physics.Raycast(ray, out hit)){
				//レイが当たった位置(hit.point)にオブジェクトを生成する
				Instantiate(obj, hit.point, Quaternion.identity);
			}
		}
	}
}
