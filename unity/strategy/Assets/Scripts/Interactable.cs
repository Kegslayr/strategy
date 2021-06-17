using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Interactable: MonoBehaviour
    {
        public float Radius = 3f;
        public bool Focused = false;

        private bool _hasInteracted = false;
        private Transform _target;

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, Radius);
        }

        private void Update()
        {
            if (Focused && !_hasInteracted)
            {
                float distance = Vector3.Distance(_target.position, transform.position);
                if (distance <= Radius)
                {
                    _hasInteracted = true;
                    Interact(this.gameObject);
                }
            }
        }

        public void OnFocused(Transform target)
        {
            Focused = true;
            _target = target;
            _hasInteracted = false;
        }

        public void ClearFocus()
        {
            Focused = false;
            _target = null;
            _hasInteracted = false;
        }

        public virtual void Interact(GameObject interactable)
        {
            Debug.Log($"{_target.transform.name} interacting with {transform.name}");
        }
    }
}
