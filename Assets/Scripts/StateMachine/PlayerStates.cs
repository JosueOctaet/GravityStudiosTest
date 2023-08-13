using UnityEngine;

namespace PlayerStates
{
    // This class defines the behavior of the Idle state
    public class Idle : State
    {
        StateMachine StateMachine;
        Animator Animator;

        // Constructor to initialize the state machine and animator
        public Idle(StateMachine stateMachine, Animator animator)
        {
            StateMachine = stateMachine;
            Animator = animator;
        }

        // Method called when entering this state
        public override void Enter()
        {
            // Play the animation for this state
            Animator.Play(StateMachine.GetCurrentStateName());
        }

        // Method called every frame while in this state
        public override void Execute()
        {
            // No behavior defined for this method
        }

        // Method called when exiting this state
        public override void Exit()
        {
            // No behavior defined for this method
        }
    }

    // This class defines the behavior of the WalkSide state
    public class WalkSide : State
    {
        StateMachine StateMachine;
        Animator Animator;

        // Constructor to initialize the state machine and animator
        public WalkSide(StateMachine stateMachine, Animator animator)
        {
            StateMachine = stateMachine;
            Animator = animator;
        }

        // Method called when entering this state
        public override void Enter()
        {
            // Play the animation for this state
            Animator.Play(StateMachine.GetCurrentStateName());
        }

        // Method called every frame while in this state
        public override void Execute()
        {
            // No behavior defined for this method
        }

        // Method called when exiting this state
        public override void Exit()
        {
            // No behavior defined for this method

        }
    }

    // This class defines the behavior of the WalkUpDown state
    public class WalkUpDown : State
    {
        StateMachine StateMachine;
        Animator Animator;

        // Constructor to initialize the state machine and animator
        public WalkUpDown(StateMachine stateMachine, Animator animator)
        {
            StateMachine = stateMachine;
            Animator = animator;
        }

        // Method called when entering this state
        public override void Enter()
        {
            // Play the animation for this state
            Animator.Play(StateMachine.GetCurrentStateName());
        }

        // Method called every frame while in this state
        public override void Execute()
        {
            // No behavior defined for this method
        }

        // Method called when exiting this state
        public override void Exit()
        {
            // No behavior defined for this method

        }
    }

    // This class defines the behavior of the Run state
    public class Run : State
    {
        StateMachine StateMachine;
        Animator Animator;

        // Constructor to initialize the state machine and animators
        public Run(StateMachine stateMachine, Animator animator)
        {
            StateMachine = stateMachine;
            Animator = animator;
        }

        // Method called when entering this state
        public override void Enter()
        {
            // Play the animation for this state
            Animator.Play(StateMachine.GetCurrentStateName());
        }

        // Method called every frame while in this state
        public override void Execute()
        {
            // No behavior defined for this method
        }

        // Method called when exiting this state
        public override void Exit()
        {
            // No behavior defined for this method

        }
    }

    // This class defines the behavior of the Attack state
    public class Attack : State
    {
        StateMachine StateMachine;
        Animator Animator;

        // Constructor to initialize the state machine and animator
        public Attack(StateMachine stateMachine, Animator animator)
        {
            StateMachine = stateMachine;
            Animator = animator;
        }

        // Method called when entering this state
        public override void Enter()
        {
            // Play the animation for this state
            Animator.Play(StateMachine.GetCurrentStateName());
        }

        // Method called every frame while in this state
        public override void Execute()
        {
            // No behavior defined for this method
        }

        // Method called when exiting this state
        public override void Exit()
        {
            // No behavior defined for this method

        }
    }

    // This class defines the behavior of the AttackDown state
    public class AttackDown : State
    {
        StateMachine StateMachine;
        Animator Animator;

        // Constructor to initialize the state machine and animator
        public AttackDown(StateMachine stateMachine, Animator animator)
        {
            StateMachine = stateMachine;
            Animator = animator;
        }

        // Method called when entering this state
        public override void Enter()
        {
            // Play the animation for this state
            Animator.Play(StateMachine.GetCurrentStateName());
        }

        // Method called every frame while in this state
        public override void Execute()
        {
            // No behavior defined for this method
        }

        // Method called when exiting this state
        public override void Exit()
        {
            // No behavior defined for this method

        }
    }

    // This class defines the behavior of the Hit state
    public class Hit : State
    {
        StateMachine StateMachine;
        Animator Animator;

        // Constructor to initialize the state machine and animator
        public Hit(StateMachine stateMachine, Animator animator)
        {
            StateMachine = stateMachine;
            Animator = animator;
        }

        // Method called when entering this state
        public override void Enter()
        {
            // Play the animation for this state
            Animator.Play(StateMachine.GetCurrentStateName());
        }

        // Method called every frame while in this state
        public override void Execute()
        {
            // No behavior defined for this method
        }

        // Method called when exiting this state
        public override void Exit()
        {
            // No behavior defined for this method

        }
    }

    // This class defines the behavior of the Deathc state
    public class Death : State
    {
        StateMachine StateMachine;
        Animator Animator;

        // Constructor to initialize the state machine and animator
        public Death(StateMachine stateMachine, Animator animator)
        {
            StateMachine = stateMachine;
            Animator = animator;
        }

        // Method called when entering this state
        public override void Enter()
        {
            // Play the animation for this state
            Animator.Play(StateMachine.GetCurrentStateName());
        }

        // Method called every frame while in this state
        public override void Execute()
        {
            // No behavior defined for this method
        }

        // Method called when exiting this state
        public override void Exit()
        {
            // No behavior defined for this method

        }
    }
}