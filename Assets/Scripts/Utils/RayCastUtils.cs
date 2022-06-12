using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkCloudGame
{
    public static class RayCastUtils
    {
        public static RaycastHit2D CalculateRaycast(Vector2 origin, Vector2 direction, float rayLength, LayerMask mask)
        {
            RaycastHit2D hit = Physics2D.Raycast(origin, direction, rayLength, mask);
            
            return hit;
        }
    }
}
