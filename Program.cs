using System;

namespace BuilderPatternExample
{
    
    public class GeometricFigure
    {
        public string Type { get; set; }
        public string Color { get; set; }
        public double Size { get; set; }

        public override string ToString()
        {
            return $"Figure Type: {Type}, Color: {Color}, Size: {Size}";
        }
    }

    
    public interface IFigureBuilder
    {
        void SetType(string type);
        void SetColor(string color);
        void SetSize(double size);
        GeometricFigure GetFigure();
    }

    
    public class FigureBuilder : IFigureBuilder
    {
        private GeometricFigure _figure = new GeometricFigure();

        public void SetType(string type)
        {
            _figure.Type = type;
        }

        public void SetColor(string color)
        {
            _figure.Color = color;
        }

        public void SetSize(double size)
        {
            _figure.Size = size;
        }

        public GeometricFigure GetFigure()
        {
            return _figure;
        }
    }

    
    public class FigureDirector
    {
        private readonly IFigureBuilder _builder;

        public FigureDirector(IFigureBuilder builder)
        {
            _builder = builder;
        }

        public GeometricFigure BuildSquare()
        {
            _builder.SetType("Square");
            _builder.SetColor("Red");
            _builder.SetSize(5.0);
            return _builder.GetFigure();
        }

        public GeometricFigure BuildCircle()
        {
            _builder.SetType("Circle");
            _builder.SetColor("Blue");
            _builder.SetSize(10.0);
            return _builder.GetFigure();
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            
            IFigureBuilder builder = new FigureBuilder();
            FigureDirector director = new FigureDirector(builder);

            GeometricFigure square = director.BuildSquare();
            GeometricFigure circle = director.BuildCircle();

            Console.WriteLine(square);
            Console.WriteLine(circle);
        }
    }
}
