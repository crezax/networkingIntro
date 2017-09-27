using System;
using UnityEngine;

public abstract class ClientBehaviour<T> : MonoBehaviour where T : BaseConnection {
  private T connectionBehaviour;

  public T ConnectionBehaviour {
    get {
      if (connectionBehaviour == null) {
        connectionBehaviour = GetComponent<T>();
      }
      return connectionBehaviour;
    }
  }

  protected virtual void Awake() {
    if (ConnectionBehaviour == null) {
      throw new Exception(this + " is missing a script of type " + typeof(T));
    }
    ConnectionBehaviour.OnLocalPlayerStarted += OnStartLocalPlayer;
  }

  protected virtual void OnStartLocalPlayer() { }
}
