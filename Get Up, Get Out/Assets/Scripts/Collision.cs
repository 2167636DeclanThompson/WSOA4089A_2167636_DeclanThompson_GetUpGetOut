using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public LayerMask GroundLayer;
    public LayerMask wallLayer;
    public LayerMask blockLayer;
    public LayerMask ceilingLayer;
    public bool onGround;
    public bool onWall;
    public bool onBlock;
    public bool onCeiling;
    public float collisionRadius;
    public Vector2 groundOffset;
    public Vector2 leftOffset;
    public Vector2 rightOffset;
    public Vector2 ceilingOffset;
    public Color gizmoColor = Color.red;
    
    private void Update()
    {
        onGround = Physics2D.OverlapCircle((Vector2)transform.position + groundOffset, collisionRadius, GroundLayer);
        onWall = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, wallLayer)
            || Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, wallLayer);
        onBlock = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, blockLayer)
            || Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, blockLayer);
        onCeiling = Physics2D.OverlapCircle((Vector2)transform.position + ceilingOffset, collisionRadius, ceilingLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere((Vector2)transform.position + groundOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + ceilingOffset, collisionRadius);
    }
}
