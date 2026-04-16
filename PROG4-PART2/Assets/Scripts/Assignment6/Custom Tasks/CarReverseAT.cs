using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.UIElements;


namespace NodeCanvas.Tasks.Actions {

	public class CarReverseAT : ActionTask {
        private Rigidbody rb;
		public float duration;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            rb = agent.GetComponent<Rigidbody>();
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
		
			rb.linearVelocity = -agent.transform.forward * duration;
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}