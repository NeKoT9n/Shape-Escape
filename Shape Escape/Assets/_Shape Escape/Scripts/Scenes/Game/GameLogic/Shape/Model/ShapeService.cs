using UniRx;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Shape.Model
{
    public class ShapeService
    {
        public IReadOnlyReactiveCollection<Shape> Shapes => _shapes;

        private readonly ReactiveCollection<Shape> _shapes = new();

        public void AddShape(Shape newShape)
        {
            _shapes.Add(newShape);
            newShape.Died += RemoveShape;
        }

        public void RemoveShape(Shape shape)
        {
            _shapes.Remove(shape);
            shape.Died -= RemoveShape;

        }


    }
}
