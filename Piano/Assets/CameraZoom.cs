using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {

	public bool zooming;
	public float zoomSpeed;
	public Camera camera;

	// アタッチしたカメラをマウスの位置で
	// 上下キーでズームアウトができる

	void Update(){
		if (zooming){
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			float zoomDistance = zoomSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
			camera.transform.Translate(ray.direction * zoomDistance, Space.World);
		}
	}
}
