using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(MeshRenderer))]
    [RequireComponent(typeof(Collider))]
    public class Highlighter: MonoBehaviour
    {
        private MeshRenderer _renderer;

        public Material OriginalMat;
        public Material HighlightMat;
        public Boolean Selected = false;
        public Boolean MouseOver = false;

        private void Start()
        {
            _renderer = GetComponent<MeshRenderer>();
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
            _renderer.material = Selected || MouseOver ? HighlightMat : OriginalMat;
            _renderer.material.SetFloat("_Selected", Selected ? 1.0f : 0.0f);
        }
    }
}
