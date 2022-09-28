using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalog.Domain.Entities
{
    public class Dimension
    {
        public double Width { get; private set; }
        public double Height { get; private set; }
        public double Depth { get; private set; }

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

        public override string ToString() => $"{Width}w x {Height}h x {Depth}d";
    }
}
