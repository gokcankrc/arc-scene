using UnityEngine;

public class SceneSettings : MonoBehaviour
{
    [SerializeField] private float m_TimeScale;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = m_TimeScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
