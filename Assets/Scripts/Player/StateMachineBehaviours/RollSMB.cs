using UnityEngine;

public class RollSMB : SceneLinkedSMB<PlayerController>
{
    public override void OnSLStatePostEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        switch (m_MonoBehaviour.direction) {
            case 0:     m_MonoBehaviour.SetMoveVector(new Vector2(m_MonoBehaviour.rollSpeed, 0));   break;
            case 90:    m_MonoBehaviour.SetMoveVector(new Vector2(0, m_MonoBehaviour.rollSpeed));   break;
            case 180:   m_MonoBehaviour.SetMoveVector(new Vector2(-m_MonoBehaviour.rollSpeed, 0));  break;
            default:    m_MonoBehaviour.SetMoveVector(new Vector2(0, -m_MonoBehaviour.rollSpeed));  break;
        }
    }
}
