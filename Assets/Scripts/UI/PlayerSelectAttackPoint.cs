using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkCloudGame
{
    public class PlayerSelectAttackPoint : MonoBehaviour
    {
        [SerializeField] GameObject targetImagePrefab;
        [SerializeField] Camera _camera;
        Vector3 mousePosition;

        public delegate void OnPlayerSelectAttackPoint(Vector3 targetPosition);
        public static OnPlayerSelectAttackPoint playerSelectAttackPoint;
       
        void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {                
                targetImagePrefab.SetActive(true);
                mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
                targetImagePrefab.transform.position = new Vector3(mousePosition.x, mousePosition.y);
                playerSelectAttackPoint?.Invoke(targetImagePrefab.transform.position);
            }
        }
    }
}
