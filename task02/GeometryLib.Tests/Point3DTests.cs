using Xunit;

namespace GeometryLib.Tests
{
    public class Point3DTests
    {
        [Theory]
        [InlineData(0, 0, 0, 0, 0, 0, 0)]
        [InlineData(0, 0, 0, 1, 0, 0, 1)]
        [InlineData(1, 2, 3, 4, 5, 6, 5.1961524227)] // sqrt(27)
        [InlineData(-1, -1, -1, 1, 1, 1, 3.4641016151)] // sqrt(12)
        public void Can_calculate_distance_to_another_point(
            double x1, double y1, double z1,
            double x2, double y2, double z2,
            double expected)
        {
            Point3D p1 = new Point3D(x1, y1, z1);
            Point3D p2 = new Point3D(x2, y2, z2);

            double result = p1.DistanceTo(p2);

            Assert.Equal(expected, result, precision: Vector3.Precision);
        }
    }
}
