using System;
using System.Collections.Generic;
using UnityEditor;
using Object = UnityEngine.Object;

namespace Space3x.NavigateBack.Editor
{
    public class GenericNavigator<T> where T : class
    {
        private Stack<WeakReference<T>> _backStack = new Stack<WeakReference<T>>();
        private Stack<WeakReference<T>> _forwardStack = new Stack<WeakReference<T>>();
        private T _activeItem;
        
        public GenericNavigator()
        {
            RegisterCallbacks(true);
        }

        private void RegisterCallbacks(bool register)
        {
            Selection.selectionChanged -= OnSelectionChanged;
            if (register)
                Selection.selectionChanged += OnSelectionChanged;
        }
        
        private void OnSelectionChanged()
        {
            T activeItem = Selection.activeObject as T;
            if (activeItem == null || _activeItem == activeItem) return;
            TryPeekFrom(ref _backStack, out T backPeek);
            
            if (_activeItem != null && (backPeek == null || backPeek != _activeItem))
                _backStack.Push(new WeakReference<T>(_activeItem));
            
            _activeItem = activeItem;
            _forwardStack.Clear();
        }
        
        private bool TryPeekFrom(ref Stack<WeakReference<T>> stack, out T value)
        {
            if (stack.TryPeek(out WeakReference<T> weakReference))
            {
                if (weakReference.TryGetTarget(out value))
                    return value != null;
            }
            value = null;
            return false;
        }

        private bool TryPopTargetFrom(ref Stack<WeakReference<T>> stack, out T value)
        {
            value = null;
            while (stack.Count > 0)
            {
                if (!stack.TryPop(out WeakReference<T> weakReference))
                    return false;
                
                if (weakReference.TryGetTarget(out T target) && target != null)
                {
                    value = target;
                    return true;
                }
            }

            return false;
        }

        private void Navigate(int steps = -1)
        {
            switch (Math.Sign(steps))
            {
                case -1:
                    if (_activeItem != null && TryPopTargetFrom(ref _backStack, out T target))
                    {
                        _forwardStack.Push(new WeakReference<T>(_activeItem));
                        _activeItem = target;
                    }
                    break;
                        
                case 1:
                    if (_activeItem != null && TryPopTargetFrom(ref _forwardStack, out target))
                    {
                        _backStack.Push(new WeakReference<T>(_activeItem));
                        _activeItem = target;
                    }
                    break;
                default:
                    break;
            }
            SelectTransform(_activeItem);
        }

        private void SelectTransform(T target)
        {
            Selection.activeObject = target as Object;
        }
        
        public void Back() => Navigate(_backStack.Count > 0 ? -1 : 0);
        
        public bool CanGoBack() => _backStack.Count > 0;
        
        public void Forward() => Navigate(_forwardStack.Count > 0 ? 1 : 0);
        
        public bool CanGoForward() => _forwardStack.Count > 0;
    }
}
