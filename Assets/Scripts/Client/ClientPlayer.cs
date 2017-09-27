public class ClientPlayer : ClientBehaviour<PlayerConnection> {

  public static ClientPlayer LocalPlayer { get; private set; }

  protected override void OnStartLocalPlayer() {
    base.OnStartLocalPlayer();

    if (LocalPlayer != null) {
      Destroy(gameObject);
      return;
    }

    LocalPlayer = this;
  }
}
