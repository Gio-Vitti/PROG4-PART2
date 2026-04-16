using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class CarChargeAT : ActionTask
	{

		//private NavMeshAgent navAgent;
		public float speed = 30f;
		public MeshRenderer dangerZone;
		Vector3 destination;
		private Rigidbody rb;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit()
		{
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute()
		{
			rb = agent.GetComponent<Rigidbody>();
			destination = agent.transform.forward.normalized;
			
			StartCoroutine(EndTask());

		}

		//Called once per frame while the action is active.
		protected override void OnUpdate()
		{
			rb.linearVelocity = destination * speed;

		}
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Wall"))
            {
                agent.transform.position = new Vector3(-17, 0.22f, 20);
                EndAction(true);
            }
        }

        private IEnumerator EndTask()
		{
			yield return new WaitForSeconds(3);
			rb.linearVelocity = Vector3.zero;
			EndAction(true);
		}

        

        //Called when the task is disabled.
        protected override void OnStop()
		{
			
			rb.linearVelocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
			rb.freezeRotation = true;
			agent.transform.eulerAngles = new Vector3(0, agent.transform.eulerAngles.y, 0);

		}

		//Called when the task is paused.
		protected override void OnPause()
		{

		}

		
	}
}