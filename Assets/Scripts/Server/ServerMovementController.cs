using UnityEngine;

public class ServerMovementController : ServerBehaviour<MovementControllerConnection> {

  private Vector2 target;
  private float speed = 2f;

  protected override void Awake() {
    base.Awake();

    ConnectionBehaviour.OnCmdMoveTowards += ConnectionBehaviour_OnCmdMoveTowards;
    target = transform.position;
  }

  protected virtual void Update() {
    Vector2 moveVector = (target - (Vector2)transform.position).normalized * speed * Time.deltaTime;

    if (Vector2.Distance(target, transform.position) < moveVector.magnitude) {
      transform.position = target;
    } else {
      transform.position += (Vector3)moveVector;
    }

    transform.position = new Vector2(
      // Set bounds to (-10, 10) on both X and Y
      Mathf.Min(10, Mathf.Max(transform.position.x, -10)),
      Mathf.Min(10, Mathf.Max(transform.position.y, -10))
    );

    // Set syncvar, NOT GOOD TO DO IF THERE ARE MANY OBJECTS LIKE THIS
    ConnectionBehaviour.position = transform.position;
  }

  private void ConnectionBehaviour_OnCmdMoveTowards(Vector2 position) {
    target = position;
  }
}
