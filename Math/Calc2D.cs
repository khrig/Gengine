using System;

namespace Gengine.Math {
    public static class Calc2D {
        public static PointF GetRightPointingAngledPoint(int degrees) {
            double angle = System.Math.PI*degrees/180.0;
            double sinAngle = System.Math.Sin(angle);
            double cosAngle = System.Math.Cos(angle);

            float xAngle = (float) sinAngle;
            float yAngle = (float) cosAngle;

            return new PointF(xAngle, yAngle);
        }

        public static PointF GetRandomDirection(Random random) {
            double azimuth = random.NextDouble()*2*3.14;
            return new PointF((float) System.Math.Cos(azimuth), (float) System.Math.Sin(azimuth));
        }

        public static PointF GetAngledPoint(int degrees) {
            double angle = System.Math.PI*degrees/180.0;
            double sinAngle = System.Math.Sin(angle);
            double cosAngle = System.Math.Cos(angle);

            double xAngle = sinAngle;
            double yAngle = cosAngle;

            return new PointF((float) xAngle, (float) yAngle);
        }
    }
}
