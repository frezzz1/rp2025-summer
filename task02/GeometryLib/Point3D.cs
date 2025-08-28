﻿namespace GeometryLib
{
    /// <summary>
    /// Точка в трёхмерном пространстве.
    /// </summary>
    public readonly struct Point3D
    {
        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Вычисляет евклидово расстояние до другой точки.
        /// </summary>
        public double DistanceTo(Point3D other)
        {
            double dx = X - other.X;
            double dy = Y - other.Y;
            double dz = Z - other.Z;

            return Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }

        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }
    }
}
