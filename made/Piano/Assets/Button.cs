using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, TapBehaviour {

    private ButtonBehaviour handler = null;

    // タッチしたときに呼ばれる。
    public void TapDown(ref RaycastHit hit) {
        if(handler != null){
            handler.TouchDown();
        }
    }

    // タッチを離したときに呼ばれる。
    public void TapUp(ref RaycastHit hit) {
        if(handler != null){
            handler.TouchUp();
        }
    }

    void Start(){
        handler = gameObject.GetComponent(typeof(ButtonBehaviour)) as ButtonBehaviour;
    }
}
