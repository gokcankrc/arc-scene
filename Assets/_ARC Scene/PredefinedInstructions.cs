using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PredefinedInstructions : MonoBehaviour
{
    private Animator anim;
    private CharacterController controller;

    [SerializeField] private List<PredefinedInstruction> Sequence;
    [SerializeField] private float Speed = 2;
    [SerializeField] private float TurnSpeed = 100;
    [SerializeField] private float Gravity = 5f;
    
    private Vector3 _moveDirection = Vector3.zero;
    private PredefinedInstruction CurrentSequence;
    
    

    void Start ()
    {
        controller = GetComponent<CharacterController>();
        anim = gameObject.GetComponentInChildren<Animator>();

        CurrentSequence = Sequence[0];
        Sequence.RemoveAt(0);
    }

    void Update ()
    {
        _moveDirection = Vector3.zero;

        predefinedInstructionsUpdate();
        
        _moveDirection.y -= Gravity;
        controller.Move(_moveDirection * Time.deltaTime);


        void predefinedInstructionsUpdate()
        {
            
            CurrentSequence.Duration -= Time.deltaTime;
            if (CurrentSequence.Duration < 0)
            {
                if (Sequence.Count == 0)
                    return;
            
                CurrentSequence = Sequence[0];
                Sequence.RemoveAt(0);
            }
        
            switch (CurrentSequence.Behaviour)
            {
                case PredefinedInstruction.BehaviourTypes.Run:
                    anim.SetInteger("AnimationPar", 1);
                    Run(CurrentSequence.ForwardSpeed);
                    break;
                case PredefinedInstruction.BehaviourTypes.Wait:
                    anim.SetInteger("AnimationPar", 0);
                    controller.Move(_moveDirection * Time.deltaTime);
                    break;
                case PredefinedInstruction.BehaviourTypes.Turn:
                    anim.SetInteger("AnimationPar", 1);
                    Turn(CurrentSequence.TurnSpeed);
                    break;
                case PredefinedInstruction.BehaviourTypes.RunAndTurn:
                    anim.SetInteger("AnimationPar", 1);
                    Run(CurrentSequence.ForwardSpeed);
                    Turn(CurrentSequence.TurnSpeed);
                    break;
            }
        }
    }

    void Run(float strength)
    {
        _moveDirection += transform.forward * (strength * Speed);
    }

    void Turn(float strength)
    {
        transform.Rotate(0, strength * TurnSpeed * Time.deltaTime, 0);
    }
    
}

[Serializable]
public class PredefinedInstruction
{
    public enum BehaviourTypes
    {
        Run, Wait, Turn, RunAndTurn, Brake
    }

    public enum SequenceEffects
    {
        WaitUntilDone,
        // ContinueSequence,
    }
    
    public SequenceEffects SequenceEffect;
    public BehaviourTypes Behaviour;
    public float Duration = 1;
    [FormerlySerializedAs("Strength1")] public float ForwardSpeed = -999;
    [FormerlySerializedAs("Strength2")] public float TurnSpeed = -999;  // used for run and turn
}
