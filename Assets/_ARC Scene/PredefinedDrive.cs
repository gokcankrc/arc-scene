using System.Collections.Generic;
using UnityEngine;

public class PredefinedDrive : MonoBehaviour
{
    
    [SerializeField] private BuggyControl buggyControl;
    [SerializeField] private bool UseKeyboardControls;
    [SerializeField] private List<PredefinedInstruction> Sequence;
    
    private PredefinedInstruction CurrentSequence;

    void Start () {
        CurrentSequence = Sequence[0];
        Sequence.RemoveAt(0);
    }
    
    void Update ()
    {
        BuggyControl.Inputs inputs = new BuggyControl.Inputs();

        predefinedDriveUpdate();
        
        if (UseKeyboardControls)
        {
            inputs = new BuggyControl.Inputs
            {
                Horizontal = Input.GetAxis("Horizontal"),
                Vertical = Input.GetAxis("Vertical"),
                Brake = Input.GetButton("Jump"),
                Shift = Input.GetKey(KeyCode.LeftShift) | Input.GetKey(KeyCode.RightShift),
                PageUp = Input.GetKeyDown("page up"),
                PageDown = Input.GetKeyDown("page down")
            };
        }
        
        buggyControl.inputs = inputs;

        void predefinedDriveUpdate()
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
                case PredefinedInstruction.BehaviourTypes.Brake:
                    inputs.Brake = true;
                    break;
                case PredefinedInstruction.BehaviourTypes.Run:
                    inputs.Vertical = CurrentSequence.ForwardSpeed;
                    break;
                case PredefinedInstruction.BehaviourTypes.Wait:
                    break;
                case PredefinedInstruction.BehaviourTypes.Turn:
                    inputs.Horizontal = CurrentSequence.TurnSpeed;
                    break;
                case PredefinedInstruction.BehaviourTypes.RunAndTurn:
                    inputs.Vertical = CurrentSequence.ForwardSpeed;
                    inputs.Horizontal = CurrentSequence.TurnSpeed;
                    break;
            }
        }
    }
}
