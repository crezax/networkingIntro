using UnityEngine.Networking;

public class BaseConnection : NetworkBehaviour {

  public delegate void StartLocalPlayerDelegate();
  public event StartLocalPlayerDelegate OnLocalPlayerStarted;

  public override void OnStartLocalPlayer() {
    base.OnStartLocalPlayer();

    if (OnLocalPlayerStarted != null) {
      OnLocalPlayerStarted();
    }
  }
}
