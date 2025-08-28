using System;

using Xunit;

namespace GeometryLib.Tests
{
    public class Sphere3DTests
    {
        [Fact]
        public void Cannot_create_sphere_with_non_positive_radius()
        {
            var center = new Point3D(0, 0, 0);

            Assert.Throws<ArgumentOutOfRangeException>(() => new Sphere3D(center, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Sphere3D(center, -5));
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(2.5, 5)]
        public void Can_get_diameter(double radius, double expected)
        {
            var sphere = new Sphere3D(new Point3D(0, 0, 0), radius);
            Assert.Equal(expected, sphere.Diameter, 10);
        }

        [Theory]
        [InlineData(1, 4 * Math.PI)]
        [InlineData(2, 16 * Math.PI)]
        public void Can_get_area(double radius, double expected)
        {
            var sphere = new Sphere3D(new Point3D(0, 0, 0), radius);
            Assert.Equal(expected, sphere.Area, 10);
        }

        [Theory]
        [InlineData(1, (4.0 / 3.0) * Math.PI)]
        [InlineData(2, (32.0 / 3.0) * Math.PI)]
        public void Can_get_volume(double radius, double expected)
        {
            var sphere = new Sphere3D(new Point3D(0, 0, 0), radius);
            Assert.Equal(expected, sphere.Volume, 10);
        }

        [Theory]
        [InlineData(0, 0, 0, 1, 2, 0, 0, 1)]
        [InlineData(0, 0, 0, 5, 10, 0, 0, 5)]
        [InlineData(0, 0, 0, 3, 0, 0, 0, 0)]
        public void Can_calculate_distance_to_point(
            double cx, double cy, double cz, double radius,
            double px, double py, double pz, double expected)
        {
            var sphere = new Sphere3D(new Point3D(cx, cy, cz), radius);
            var point = new Point3D(px, py, pz);

            double result = sphere.DistanceTo(point);
            Assert.Equal(expected, result, 10);
        }

        [Theory]
        [InlineData(0, 0, 0, 1, 3, 0, 0, 1, 1)]
        [InlineData(0, 0, 0, 2, 10, 0, 0, 3, 5)]
        [InlineData(0, 0, 0, 5, 0, 0, 0, 2, 0)]
        public void Can_calculate_distance_to_another_sphere(
            double x1, double y1, double z1, double r1,
            double x2, double y2, double z2, double r2,
            double expected)
        {
            var s1 = new Sphere3D(new Point3D(x1, y1, z1), r1);
            var s2 = new Sphere3D(new Point3D(x2, y2, z2), r2);

            double result = s1.DistanceTo(s2);
            Assert.Equal(expected, result, 10);
        }

        [Theory]
        [InlineData(0, 0, 0, 5, 1, 1, 1, true)]
        [InlineData(0, 0, 0, 5, 10, 0, 0, false)]
        public void Can_check_if_contains_point(
            double cx, double cy, double cz, double radius,
            double px, double py, double pz, bool expected)
        {
            var sphere = new Sphere3D(new Point3D(cx, cy, cz), radius);
            var point = new Point3D(px, py, pz);

            Assert.Equal(expected, sphere.Contains(point));
        }

        [Theory]
        [InlineData(0, 0, 0, 5, 8, 0, 0, 5, true)]
        [InlineData(0, 0, 0, 5, 12, 0, 0, 5, false)]
        [InlineData(0, 0, 0, 5, 0, 0, 0, 1, true)]
        public void Can_check_if_intersects_with_another_sphere(
            double x1, double y1, double z1, double r1,
            double x2, double y2, double z2, double r2,
            bool expected)
        {
            var s1 = new Sphere3D(new Point3D(x1, y1, z1), r1);
            var s2 = new Sphere3D(new Point3D(x2, y2, z2), r2);

            Assert.Equal(expected, s1.IntersectsWith(s2));
        }

        [Theory]
        [InlineData(0, 0, 0, 5, 1, 0, 0, 1, true)]
        [InlineData(0, 0, 0, 5, 4, 0, 0, 2, false)]
        public void Can_check_if_contains_another_sphere(
            double x1, double y1, double z1, double r1,
            double x2, double y2, double z2, double r2,
            bool expected)
        {
            var s1 = new Sphere3D(new Point3D(x1, y1, z1), r1);
            var s2 = new Sphere3D(new Point3D(x2, y2, z2), r2);

            Assert.Equal(expected, s1.Contains(s2));
        }
    }
}
