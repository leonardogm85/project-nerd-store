using NerdStore.Core.Domain;

namespace NerdStore.Catalog.Domain.Entities
{
    public class Dimension : IValueObject
    {
        public double Width { get; }
        public double Height { get; }
        public double Depth { get; }

        protected Dimension()
        {
        }

        public Dimension(double width, double height, double depth)
        {
            Width = width;
            Height = height;
            Depth = depth;

            Validate();
        }

        private void Validate()
        {
            AssertionConcern.AssertArgumentGreaterThan(
                Width,
                0,
                "The width must be greater than 0.");

            AssertionConcern.AssertArgumentGreaterThan(
                Height,
                0,
                "The height must be greater than 0.");

            AssertionConcern.AssertArgumentGreaterThan(
                Depth,
                0,
                "The depth must be greater than 0.");
        }

        public override string ToString()
        {
            return $"{Width}w x {Height}h x {Depth}d";
        }
    }
}
