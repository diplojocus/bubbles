using UnityEngine;
using System.Collections;

public class GloopController : MonoBehaviour {

	public WandController wandLeft;
    public WandController wandRight;
    private Hv_bubbles_LibWrapper _bubbles;

	void Start() {
        // OSCHandler.Instance.Init();
        _bubbles = GetComponent<Hv_bubbles_LibWrapper>();
	}

	void FixedUpdate() {
        // OSCHandler.Instance.SendMessageToClient("Pd", "/wand/left/accel", wandLeft.acceleration);
        _bubbles.accel = wandLeft.acceleration;
	}

    public void OnTriggerStart() {
        // OSCHandler.Instance.SendMessageToClient("Pd", "/wand/left/trigger", 1);
        _bubbles.trigger = 1.0f;
    }

    public void OnTriggerEnd() {
        // OSCHandler.Instance.SendMessageToClient("Pd", "/wand/left/trigger", 0);
        _bubbles.trigger = 0.0f;
    }
}
