using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class BearTackle : ActionTask {

		private Rigidbody rb;
		public float strength;
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
			StartCoroutine(Tackle());
			
		}

		private IEnumerator Tackle()
		{
			yield return new WaitForSeconds(2);
            rb.AddForce(agent.transform.forward * strength, ForceMode.Impulse);
            EndAction(true);
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}