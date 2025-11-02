using Assets._Shape_Escape.Scripts.General;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Shape.Model;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Teams;
using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Shape.Presentor
{
    public class ShapeContainerPresentor : IInitializable, IDisposable
    {
        private readonly ShapeService _shapeService;
        private readonly ShapeSpawner _shapeFactory;
        private readonly TeamColorContainer _colorContainer;
        private readonly Transform _shapesParent;
        private readonly Dictionary<Shape, ShapePresentor> _presentors = new();

        private readonly CompositeDisposable _compositeDisposable = new();
        public ShapeContainerPresentor(ShapeService shapeContainer, ShapeSpawner shapeFactory,TeamColorContainer colorContainer, Transform ShapesParent)
        {
            _shapeService = shapeContainer;
            _shapeFactory = shapeFactory;
            _colorContainer = colorContainer;
            _shapesParent = ShapesParent;
        }

        public void Initialize()
        {
            foreach (var shape in _shapeService.Shapes)
            {
                AddPresentor(shape);
            }

           _compositeDisposable.Clear();
           _compositeDisposable.Add(_shapeService.Shapes.ObserveAdd().Subscribe(e => AddPresentor(e.Value)));
           _compositeDisposable.Add(_shapeService.Shapes.ObserveRemove().Subscribe(e =>  RemovePresentor(e.Value)));
                                                                                           
        }
        private void AddPresentor(Shape value)
        {
            ShapeView newView = _shapeFactory.Create(value, _shapesParent);

            var presentor = new ShapePresentor(value, _colorContainer, newView); //TODO: Create ZenjectFactory
            presentor.Initialize();
            _presentors.Add(value, presentor);
            
        }

        private void RemovePresentor(Shape value)
        {
            _presentors[value].Dispose();
            _presentors.Remove(value);
        }


        public void Dispose()
        {
            _compositeDisposable.Dispose();
        }
    }
}
