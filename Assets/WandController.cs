using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class WandController : MonoBehaviour {

    public UnityEvent OnTriggerStart;
    public UnityEvent OnTriggerEnd;

    public float acceleration = 0.0f;

    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int) trackedObject.index); } }
    private SteamVR_TrackedObject trackedObject;

    private Vector3 prevPosition;

	void Start () {
	   trackedObject = GetComponent<SteamVR_TrackedObject>();
       prevPosition = trackedObject.transform.position;
	}

	void Update () {
        if (controller != null) {
         //   triggerButtonPressed = controller.GetPress(triggerButton);

            if (controller.GetPressDown(triggerButton)) OnTriggerStart.Invoke();
            if (controller.GetPressUp(triggerButton)) OnTriggerEnd.Invoke();
        }
	}

    void FixedUpdate() {
        Vector3 accel = trackedObject.transform.position - prevPosition;
        acceleration = accel.magnitude;
        prevPosition = trackedObject.transform.position;
    }
}
