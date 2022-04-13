using System;
using System.Collections.Generic;
using UnityEngine;

public class AirlockAnimator : MonoBehaviour
{
    [SerializeField] private Transform airlock;
    [SerializeField] private float OpenSpeed;
    [SerializeField] private List<Instructions> Sequence;
    
    private Instructions _currentSequence;
    private float MinAngle = 0;
    private float MaxAngle = 90;


    private void Start()
    {
        _currentSequence = Sequence[0];
        Sequence.RemoveAt(0);
    }

    private void Update()
    {
        _currentSequence.Duration -= Time.deltaTime;
        if (_currentSequence.Duration < 0)
        {
            if (Sequence.Count == 0)
                return;
            
            _currentSequence = Sequence[0];
            Sequence.RemoveAt(0);
        }

        Vector3 eulerAngles = airlock.localEulerAngles;
        float xEuler = eulerAngles.x;
        
        switch (_currentSequence.Animation)
        {
            case Instructions.AirlockAnimation.Open:
                xEuler += OpenSpeed * Time.deltaTime;
                break;
            case Instructions.AirlockAnimation.Close:
                xEuler -= OpenSpeed * Time.deltaTime;
                break;
        }

        eulerAngles.x = Mathf.Clamp(xEuler, MinAngle, MaxAngle);
        airlock.localEulerAngles = eulerAngles;
    }
}
    
[Serializable]
public class Instructions
{
    public enum AirlockAnimation
    {
        Wait, Open, Close
    }
    
    public AirlockAnimation Animation;
    public float Duration = 1;
}
