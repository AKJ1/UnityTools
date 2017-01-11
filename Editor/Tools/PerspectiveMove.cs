using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Editor
{
    /// <summary>
    /// Global editor script that allows moving objects with CTRL+SHIFT+ARROWKEYS 
    /// inside the scene view. Relative to the current perspective.
    /// </summary>
    public static class PerspectiveMove
    {
        private enum WorldDir
        {
            Left,Right,Backward,Forward,Empty   
        }

        static Dictionary<WorldDir, Quaternion> dirRotations = new Dictionary<WorldDir, Quaternion>(){
                {WorldDir.Left, Quaternion.Euler(0,-90, 0)},
                {WorldDir.Right, Quaternion.Euler(0,90, 0)},
                {WorldDir.Forward, Quaternion.Euler(0,0, 0)},
                {WorldDir.Backward, Quaternion.Euler(0,180, 0)},
            };

        #region Hotkey Callers

        [MenuItem("GAM01/LevelEditor/Move Left %#LEFT")]
        public static void MoveLeft()
        {
            MoveSelection(WorldDir.Left);
        }

        [MenuItem("GAM01/LevelEditor/Move Right %#RIGHT")]
        public static void MoveRight()
        {
            MoveSelection(WorldDir.Right);
        }

        [MenuItem("GAM01/LevelEditor/Move Forward %#UP")]
        public static void MoveForward()
        {
            MoveSelection(WorldDir.Forward);
        }

        [MenuItem("GAM01/LevelEditor/Move Back %#DOWN")]
        public static void MoveBack()
        {
            MoveSelection(WorldDir.Backward);
        }

        #endregion

        private static void MoveSelection(WorldDir dir)
        {
            Vector3 forwardDir = GetRelativeDireciton();
            for (int i = 0; i < Selection.gameObjects.Length; i++)
            {

                if (Selection.gameObjects[i].transform.parent == null)
                {
//                    Debug.Log((dirRotations[dir] * forwardDir).normalized);
//                    Debug.Log("BEFORE : " + Selection.gameObjects[i].transform.position + "\n AFTER : " +
//                              (Selection.gameObjects[i].transform.position + (dirRotations[dir]*forwardDir).normalized));
                    Selection.gameObjects[i].transform.position += (dirRotations[dir] * forwardDir).normalized;

                }
                else
                {
                    if (!Selection.gameObjects.Contains(Selection.gameObjects[i].transform.parent.gameObject))
                    {
//                        Debug.Log((dirRotations[dir] * forwardDir).normalized);
                        Selection.gameObjects[i].transform.position += (dirRotations[dir]*forwardDir).normalized;
                    }
                }
            }
            UpdateBlocks();
        }

        public static Vector3 GetRelativeDireciton()
        {
            if (Camera.current != null)
            {
                var cameraRotation = Camera.current.transform.rotation * Vector3.forward;

                cameraRotation = cameraRotation.SubvectorXZ();

                if (Math.Abs(Mathf.Abs(cameraRotation.z) - Mathf.Abs(cameraRotation.x)) < 0.001f)
                {
                    return Vector3.zero;
                }
                else
                {
                    cameraRotation = Mathf.Abs(cameraRotation.z) > Mathf.Abs(cameraRotation.x)
                        ? cameraRotation.SubvectorZ()
                        : cameraRotation.SubvectorX();
                }

                return cameraRotation;
            }
            return Vector3.zero;
        }
    }
}
