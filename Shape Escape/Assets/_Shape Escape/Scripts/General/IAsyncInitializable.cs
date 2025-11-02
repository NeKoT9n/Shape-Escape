using Cysharp.Threading.Tasks;
using System.Collections;
using UnityEngine;

namespace Assets._Shape_Escape.Scripts.General
{
    public interface IAsyncInitializable
    {
        public UniTask Initialize();
    }
}