using UnityEngine;

namespace Kapu.SaamiRunner
{
    /// <summary>
    /// Part of standard 2d assets
    /// </summary>
    public class Camera2DFollow : MonoBehaviour
    {
        public Transform target;
        public float damping = 1;
        public float lookAheadFactor = 3;
        public float lookAheadReturnSpeed = 0.5f;
        public float lookAheadMoveThreshold = 0.1f;
        
        
        private float m_OffsetZ;
        private Vector3 m_LastTargetPosition;
        private Vector3 m_CurrentVelocity;
        private Vector3 m_LookAheadPos;

        
        private void Start()
        {
            m_LastTargetPosition = target.position;
            m_OffsetZ = (transform.position - target.position).z;
            transform.parent = null;
        }
        
        private void Update()
        {
            // only update lookahead pos if accelerating or changed direction
            var xMoveDelta = (target.position - m_LastTargetPosition).x;

            var updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

            if (updateLookAheadTarget)
            {
                m_LookAheadPos = lookAheadFactor*Vector3.right*Mathf.Sign(xMoveDelta);
            }
            else
            {
                m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime*lookAheadReturnSpeed);
            }

            var aheadTargetPos = target.position + m_LookAheadPos + Vector3.forward*m_OffsetZ;
            var newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);
            newPos.z = transform.position.z;
            
            transform.position = newPos;
            

            m_LastTargetPosition = target.position;
        }

        private void ResetTracking()
        {
            m_LastTargetPosition = transform.position;
            m_OffsetZ = (transform.position - target.position).z;
            m_CurrentVelocity = m_LookAheadPos = Vector3.zero;
        }
    }
}
