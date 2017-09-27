using UnityEngine;
using UnityEngine.Networking;

// channel 0 is TCP by default, 1 is UDP, 0.03 interval gives us over 30 updates
// per second. Without interpolating movement, the movement on client looks shit
// with less updates. Check NetworkManager object in scene for more options
[NetworkSettings(channel = 1, sendInterval = .03f)]
public class MovementControllerConnection : BaseConnection {

  // Server events
  public delegate void CmdMoveTowardsDelegate(Vector2 position);
  public event CmdMoveTowardsDelegate OnCmdMoveTowards;

  // Client events
  public delegate void PositionSyncDelegate(Vector2 position);
  public event PositionSyncDelegate OnPositionSynced;

  [SyncVar(hook = "PositionHook")]
  public Vector2 position;

  public override void OnStartClient() {
    base.OnStartClient();

    PositionHook(position);
  }

  [Command]
  public void CmdMoveTowards(Vector2 position) {
    if (OnCmdMoveTowards != null) {
      OnCmdMoveTowards(position);
    }
  }

  private void PositionHook(Vector2 position) {
    this.position = position;
    if (OnPositionSynced != null) {
      OnPositionSynced(position);
    }
  }
}
