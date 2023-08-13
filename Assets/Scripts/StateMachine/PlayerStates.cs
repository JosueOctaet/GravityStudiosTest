using UnityEngine;
using UnityEngine.UI;

namespace PlayerStates
{
    public class Idle : State
    {
        StateMachine StateMachine;
        Animator Animator;

        public Idle(StateMachine stateMachine, Animator animator)
        {
            StateMachine = stateMachine;
            Animator = animator;
        }

        public override void Enter()
        {
            Animator.Play(StateMachine.GetCurrentStateName());
        }

        public override void Execute()
        {
        }

        public override void Exit()
        {
        }
    }

    public class WalkSide : State
    {
        StateMachine StateMachine;
        Animator Animator;

        public WalkSide(StateMachine stateMachine, Animator animator)
        {
            StateMachine = stateMachine;
            Animator = animator;
        }

        public override void Enter()
        {
            Animator.Play(StateMachine.GetCurrentStateName());
        }

        public override void Execute()
        {
        }

        public override void Exit()
        {
        }
    }

    public class WalkUpDown : State
    {
        StateMachine StateMachine;
        Animator Animator;

        public WalkUpDown(StateMachine stateMachine, Animator animator)
        {
            StateMachine = stateMachine;
            Animator = animator;
        }

        public override void Enter()
        {
            Animator.Play(StateMachine.GetCurrentStateName());
        }

        public override void Execute()
        {
        }

        public override void Exit()
        {
        }
    }

    public class Run : State
    {
        StateMachine StateMachine;
        Animator Animator;

        public Run(StateMachine stateMachine, Animator animator)
        {
            StateMachine = stateMachine;
            Animator = animator;
        }

        public override void Enter()
        {
            Animator.Play(StateMachine.GetCurrentStateName());
        }

        public override void Execute()
        {
        }

        public override void Exit()
        {
        }
    }

    public class Attack : State
    {
        StateMachine StateMachine;
        Animator Animator;

        public Attack(StateMachine stateMachine, Animator animator)
        {
            StateMachine = stateMachine;
            Animator = animator;
        }

        public override void Enter()
        {
            Animator.Play(StateMachine.GetCurrentStateName());
        }

        public override void Execute()
        {
        }

        public override void Exit()
        {
        }
    }

    public class AttackDown : State
    {
        StateMachine StateMachine;
        Animator Animator;

        public AttackDown(StateMachine stateMachine, Animator animator)
        {
            StateMachine = stateMachine;
            Animator = animator;
        }

        public override void Enter()
        {
            Animator.Play(StateMachine.GetCurrentStateName());
        }

        public override void Execute()
        {
        }

        public override void Exit()
        {
        }
    }

    public class Hit : State
    {
        StateMachine StateMachine;
        Animator Animator;

        public Hit(StateMachine stateMachine, Animator animator)
        {
            StateMachine = stateMachine;
            Animator = animator;
        }

        public override void Enter()
        {
            Animator.Play(StateMachine.GetCurrentStateName());
        }

        public override void Execute()
        {
        }

        public override void Exit()
        {
        }
    }

    public class Death : State
    {
        StateMachine StateMachine;
        Animator Animator;

        public Death(StateMachine stateMachine, Animator animator)
        {
            StateMachine = stateMachine;
            Animator = animator;
        }

        public override void Enter()
        {
            Animator.Play(StateMachine.GetCurrentStateName());
        }

        public override void Execute()
        {
        }

        public override void Exit()
        {
        }
    }
}