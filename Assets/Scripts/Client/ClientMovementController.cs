using UnityEngine;

public class ClientMovementController : ClientBehaviour<MovementControllerConnection> {
  protected override void Awake() {
    base.Awake();
    ConnectionBehaviour.OnPositionSynced += ConnectionBehaviour_OnPositionSynced;
  }

  protected virtual void Update() {
    if (!ConnectionBehaviour.hasAuthority) {
      // Check if object has authority - in this case, is a local player
      return;
    }

    if (Input.GetMouseButton(0)) {
      // This is REALLY NOT good, should limit to X numbers per sec or sth
      ConnectionBehaviour.CmdMoveTowards(
        Camera.main.ScreenToWorldPoint(Input.mousePosition)
      );
    }
  }

  private void ConnectionBehaviour_OnPositionSynced(Vector2 position) {
    transform.position = position;
  }
}
