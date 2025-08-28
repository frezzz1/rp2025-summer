namespace GeometryLib
{
    /// <summary>
    /// Шар в трёхмерном пространстве.
    /// </summary>
    public class Sphere3D
    {
        public Point3D Center { get; }
        public double Radius { get; }

        public Sphere3D(Point3D center, double radius)
        {
            if (radius <= 0)
                throw new ArgumentOutOfRangeException(nameof(radius), "Radius must be positive");

            Center = center;
            Radius = radius;
        }

        /// <summary>
        /// Диаметр шара.
        /// </summary>
        public double Diameter => Radius * 2;

        /// <summary>
        /// Площадь поверхности шара.
        /// </summary>
        public double Area => 4 * Math.PI * Radius * Radius;

        /// <summary>
        /// Объём шара.
        /// </summary>
        public double Volume => (4.0 / 3.0) * Math.PI * Math.Pow(Radius, 3);

        /// <summary>
        /// Расстояние от точки до поверхности шара.
        /// </summary>
        public double DistanceTo(Point3D p)
        {
            double distanceToCenter = Center.DistanceTo(p);
            double distanceToSurface = distanceToCenter - Radius;

            return distanceToSurface < 0 ? 0 : distanceToSurface;
        }

        /// <summary>
        /// Расстояние между поверхностями двух шаров.
        /// </summary>
        public double DistanceTo(Sphere3D other)
        {
            double centerDistance = Center.DistanceTo(other.Center);
            double surfaceDistance = centerDistance - (Radius + other.Radius);

            return surfaceDistance < 0 ? 0 : surfaceDistance;
        }

        /// <summary>
        /// Проверяет, находится ли точка внутри шара.
        /// </summary>
        public bool Contains(Point3D p)
        {
            return Center.DistanceTo(p) <= Radius + Vector3.Tolerance;
        }

        /// <summary>
        /// Проверяет, пересекаются ли два шара.
        /// </summary>
        public bool IntersectsWith(Sphere3D other)
        {
            double centerDistance = Center.DistanceTo(other.Center);
            return centerDistance <= (Radius + other.Radius + Vector3.Tolerance);
        }

        /// <summary>
        /// Проверяет, находится ли другой шар полностью внутри этого шара.
        /// </summary>
        public bool Contains(Sphere3D other)
        {
            double centerDistance = Center.DistanceTo(other.Center);
            return centerDistance + other.Radius <= Radius + Vector3.Tolerance;
        }

        public override string ToString()
        {
            return $"Sphere(Center={Center}, Radius={Radius})";
        }
    }
}
