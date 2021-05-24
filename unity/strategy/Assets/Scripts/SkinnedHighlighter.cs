using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class SkinnedHighlighter : MonoBehaviour
    {
        public SkinnedMeshRenderer Renderer;
        public CapsuleCollider Collider;
        public Material OriginalMat;
        public Material HighlightMat;
        public Boolean Selected = false;
        public Boolean MouseOver = false;

        private void Start()
        {
            Selected = false;
            EnableHighlight();
        }

        private void Update()
        {
            if (MouseOver && Input.GetMouseButtonDown(0))
            {
                Select();
            }
        }
        private void OnMouseOver()
        {
            MouseOver = true;
            EnableHighlight();
        }

        private void OnMouseExit()
        {
            MouseOver = false;
            if (!Selected)
                EnableHighlight();
        }

        public void Select()
        {
            Selected = !Selected;
            EnableHighlight();
        }

        public void EnableHighlight()
        {
            // a single material
            //Renderer.material = Selected || MouseOver ? HighlightMat : OriginalMat;
            //Renderer.material.SetFloat("_Selected", Selected ? 1.0f : 0.0f);

            // multiple materials
            var mats = Renderer.materials;
            for(int i = 0; i < mats.Length; i++)
            {
                mats[i] = Selected || MouseOver ? HighlightMat : OriginalMat;
                mats[i].SetFloat("_Selected", Selected ? 1.0f : 0.0f);
            }
            Renderer.materials = mats;
        }
    }
}
