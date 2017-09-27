using UnityEngine;

public class CameraFollow : MonoBehaviour {

  protected virtual void LateUpdate() {
    if (ClientPlayer.LocalPlayer != null) {
      transform.position = new Vector3(
        ClientPlayer.LocalPlayer.transform.position.x,
        ClientPlayer.LocalPlayer.transform.position.y,
        -10
      );
    }
  }
}
