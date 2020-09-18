using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace Stellar{
    public class Line : MonoBehaviour{
        private LineRenderer line;
        private Vector3 mousePos;
        public Material mat;

        void Update(){
            CreateLine();
        }

        public void CreateLine(){
            if(Input.GetMouseButtonDown(0)){
                if(line == null){
                    DrawLine();
                }
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0;
                line.SetPosition(0, mousePos);
                line.SetPosition(1, mousePos);
            }
            else if(Input.GetMouseButton(0) && line){
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0;
                line.SetPosition(1, mousePos);
            }
        }

        public void DrawLine(){
            line = new GameObject("Line").AddComponent<LineRenderer>();
            line.gameObject.layer = LayerMask.NameToLayer("Default");
            line.material = mat;
            line.positionCount = 2;
            line.startWidth = 1f;
            line.endWidth = 1f;
            line.useWorldSpace = false;
        }
    }

}
