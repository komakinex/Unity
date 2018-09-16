using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface TapBehaviour {
    // タッチしたときに呼ばれる。
    void TapDown(ref RaycastHit hit);
    // タッチを離したときに呼ばれる。
    void TapUp(ref RaycastHit hit);
}
