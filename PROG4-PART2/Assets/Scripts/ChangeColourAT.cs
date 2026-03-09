using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ChangeColourAT : ActionTask {

		public Material redMat;
		public Material whiteMat;
		public Transform obstacle;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
            agent.GetComponent<Renderer>().material = whiteMat;
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

			agent.GetComponent<Renderer>().material = redMat;
			EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
			//float dist = Vector3.Distance(agent.transform.position, obstacle.transform.position);
			//float redness = Mathf.Lerp(0, 1, dist);
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}