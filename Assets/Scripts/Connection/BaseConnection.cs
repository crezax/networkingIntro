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

  public delegate void StartClientDelegate();
  public event StartClientDelegate OnClientStarted;

  public override void OnStartClient() {
    base.OnStartClient();

    if (OnClientStarted != null) {
      OnClientStarted();
    }
  }

  public delegate void StartServerDelegate();
  public event StartServerDelegate OnServerStarted;

  public override void OnStartServer() {
    base.OnStartServer();

    if (OnServerStarted != null) {
      OnServerStarted();
    }
  }
}
