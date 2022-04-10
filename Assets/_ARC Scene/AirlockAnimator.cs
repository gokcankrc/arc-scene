using System;
using System.Collections.Generic;
using UnityEngine;

public class AirlockAnimator : MonoBehaviour
{
    [SerializeField] private Transform airlock;
    [SerializeField] private float OpenSpeed;
    [SerializeField] private float MagicScaleNumber = 75f;
    [SerializeField] private List<Instructions> Sequence;
    
    private Instructions _currentSequence;


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

        Vector3 scaleVector = airlock.localScale;
        float zScale = scaleVector.z;
        
        switch (_currentSequence.Animation)
        {
            case Instructions.AirlockAnimation.Open:
                zScale -= OpenSpeed * Time.deltaTime;
                break;
            case Instructions.AirlockAnimation.Close:
                zScale += OpenSpeed * Time.deltaTime;
                break;
        }

        scaleVector.z = Mathf.Clamp(zScale, 0, MagicScaleNumber);
        airlock.localScale = scaleVector;
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
