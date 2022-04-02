using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredefinedDrive : MonoBehaviour
{
    //
    // private BuggyControl anim;
    //
    // [SerializeField] private List<PredefinedInstruction> Sequence;
    // [SerializeField] private float Speed = 2;
    // [SerializeField] private float TurnSpeed = 100;
    // [SerializeField] private float Gravity = 5f;
    //
    // private Vector3 _moveDirection = Vector3.zero;
    // private PredefinedInstruction CurrentSequence;
    //
    //
    //
    // void Start () {
    //     controller = GetComponent<CharacterController>();
    //     anim = gameObject.GetComponentInChildren<Animator>();
    //
    //     CurrentSequence = Sequence[0];
    //     Sequence.RemoveAt(0);
    // }
    //
    // void Update ()
    // {
    //     _moveDirection = Vector3.zero;
    //     
    //     CurrentSequence.Duration -= Time.deltaTime;
    //     if (CurrentSequence.Duration < 0)
    //     {
    //         if (Sequence.Count == 0)
    //             return;
    //         
    //         CurrentSequence = Sequence[0];
    //         Sequence.RemoveAt(0);
    //     }
    //     
    //     switch (CurrentSequence.Behaviour)
    //     {
    //         case PredefinedInstruction.BehaviourTypes.Run:
    //             anim.SetInteger("AnimationPar", 1);
    //             Run(CurrentSequence.Strength1);
    //             break;
    //         case PredefinedInstruction.BehaviourTypes.Wait:
    //             anim.SetInteger("AnimationPar", 0);
    //             controller.Move(_moveDirection * Time.deltaTime);
    //             break;
    //         case PredefinedInstruction.BehaviourTypes.Turn:
    //             anim.SetInteger("AnimationPar", 1);
    //             Turn(CurrentSequence.Strength1);
    //             break;
    //         case PredefinedInstruction.BehaviourTypes.RunAndTurn:
    //             anim.SetInteger("AnimationPar", 1);
    //             Run(CurrentSequence.Strength1);
    //             Turn(CurrentSequence.Strength2);
    //             break;
    //     }
    //     
    //     _moveDirection.y -= Gravity;
    //     controller.Move(_moveDirection * Time.deltaTime);
    //
    // }
    //
    // void Run(float strength)
    // {
    //     _moveDirection += transform.forward * (strength * Speed);
    // }
    //
    // void Turn(float strength)
    // {
    //     transform.Rotate(0, strength * TurnSpeed * Time.deltaTime, 0);
    // }
}
