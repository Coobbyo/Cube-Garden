using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehaviour : StateMachineBehaviour
{
	[SerializeField] private float timeUntilBored;

	[SerializeField] private int numberOfIdleAnimations;
	[SerializeField] private int numberOfBoredAnimations;

	private bool isBored;
	private float idleTime;
	private int idleAnimation;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		ResetIdle();
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
	    if(!isBored)
		{
			idleTime += Time.deltaTime;
			if(idleTime > timeUntilBored && stateInfo.normalizedTime % 1f < 0.02f)
			{
				isBored = true;
				idleAnimation = Random.Range(-1, numberOfBoredAnimations) + numberOfIdleAnimations;
				idleAnimation = idleAnimation * 2 - 1;

				animator.SetFloat("IdleAnimation", idleAnimation - 1);
			}
		} else if(stateInfo.normalizedTime % 1f > 0.98f)
		{
			ResetIdle();
		}

		animator.SetFloat("IdleAnimation", idleAnimation, 0.2f, Time.deltaTime);
	}

	private void ResetIdle()
	{
		if(isBored)
			idleAnimation--;

		isBored = false;
		idleTime = 0;

		//idleAnimation = Random.Range(0, numberOfIdleAnimations);
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	//{
	//	
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove()
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	//{
	//    // Implement code that processes and affects root motion
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK()
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	//{
	//    // Implement code that sets up animation IK (inverse kinematics)
	//}
}
