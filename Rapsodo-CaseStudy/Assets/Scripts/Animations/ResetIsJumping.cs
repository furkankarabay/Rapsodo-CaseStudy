using UnityEngine;

namespace Rapsodo.MazeGame
{
    public class ResetIsJumping : StateMachineBehaviour
    {
        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool("isJumping", false);
        }
    }

}
