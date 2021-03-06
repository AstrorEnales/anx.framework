﻿#region Using Statements
using System;
using System.Collections.Generic;
using System.Globalization;
using ANX.Framework.NonXNA.Development;
using System.ComponentModel;
using ANX.Framework.Design;

#endregion // Using Statements

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework
{
    [PercentageComplete(100)]
    [Developer("xToast")]
    [TestState(TestStateAttribute.TestState.InProgress)]
#if !WINDOWSMETRO
    [Serializable]
    [TypeConverter(typeof(BoundingSphereConverter))]
#endif
    public struct BoundingSphere : IEquatable<BoundingSphere>
    {
        #region fields
   
        public Vector3 Center;
        public float Radius;
 
        #endregion

        #region constructors
        public BoundingSphere(Vector3 center, float radius)
        {
           
            this.Center = center;
            this.Radius = radius;
        }
        #endregion

        #region public methods
        public ContainmentType Contains(BoundingBox box)
        {
            ContainmentType result;
            this.Contains(ref box, out result);
            return result;
        }

        public void Contains(ref BoundingBox box, out ContainmentType result)
        {
            byte value = 0;
            if (Vector3.DistanceSquared(box.Max, this.Center) < this.Radius * this.Radius)
            {
                value++;
            }
            if (Vector3.DistanceSquared(box.Min, this.Center) < this.Radius * this.Radius)
            {
                value++;
            }

            result = value == 0 ? ContainmentType.Disjoint : value == 1 ? ContainmentType.Intersects : ContainmentType.Contains;
        }

        public ContainmentType Contains(BoundingFrustum frustum)
        {
            Vector3[] points = frustum.GetCorners();
            float radiusSquared = this.Radius * this.Radius;

            byte pointsIn = 0;
            for (int i = 0; i < BoundingFrustum.CornerCount; i++)
            {
                float distance = Vector3.DistanceSquared(points[i], this.Center);

                if (distance > radiusSquared)
                    continue;

                if (i != 0 && pointsIn == 0)
                    return ContainmentType.Intersects;

                pointsIn++;
            }

            if (pointsIn == BoundingFrustum.CornerCount)
                return ContainmentType.Contains;

            return ContainmentType.Disjoint;
        }

        public ContainmentType Contains(BoundingSphere sphere)
        {
            ContainmentType result;
            this.Contains(ref sphere, out result);
            return result;
        }

        public void Contains(ref BoundingSphere sphere, out ContainmentType result)
        {
            float distance = Vector3.Distance(this.Center, sphere.Center);
            float bothRadius = this.Radius + sphere.Radius;
            if (distance > bothRadius)
            {
                result = ContainmentType.Disjoint;
                return;
            }
            if (distance + sphere.Radius < this.Radius)
            {
                result = ContainmentType.Contains;
                return;
            }
            result = ContainmentType.Intersects;
        }

        public ContainmentType Contains(Vector3 point)
        {
            ContainmentType result;
            this.Contains(ref point, out result);
            return result;
        }

        public void Contains(ref Vector3 point, out ContainmentType result)
        {
            float distance = Vector3.DistanceSquared(point, this.Center);

            if (distance > this.Radius * this.Radius)
            {
                result = ContainmentType.Disjoint;
                return;
            }
            else if (distance < this.Radius * this.Radius)
            {
                result = ContainmentType.Contains;
                return;
            }

            result= ContainmentType.Intersects;
        }

        public static BoundingSphere CreateFromBoundingBox(BoundingBox box)
        {
            BoundingSphere result;
            CreateFromBoundingBox(ref box, out result);
            return result;
        }

        public static void CreateFromBoundingBox(ref BoundingBox box, out BoundingSphere result)
        {
            result.Center = new Vector3(
                (box.Min.X + box.Max.X) * 0.5f,
                (box.Min.Y + box.Max.Y) * 0.5f,
                (box.Min.Z + box.Max.Z) * 0.5f);
            result.Radius = Vector3.Distance(box.Min, result.Center);
        }

        public static BoundingSphere CreateFromFrustum(BoundingFrustum frustum)
        {
            return CreateFromPoints(frustum.GetCorners());
        }

        //source: monoxna
        public static BoundingSphere CreateFromPoints(IEnumerable<Vector3> points)
        {
            if (points == null)
                throw new ArgumentNullException("points");

            float radius = 0;
            Vector3 center = new Vector3();
            // First, we'll find the center of gravity for the point 'cloud'.
            int num_points = 0; // The number of points (there MUST be a better way to get this instead of counting the number of points one by one?)

            foreach (Vector3 v in points)
            {
                center += v;    // If we actually knew the number of points, we'd get better accuracy by adding v / num_points.
                ++num_points;
            }

            center /= (float)num_points;

            // Calculate the radius of the needed sphere (it equals the distance between the center and the point further away).
            foreach (Vector3 v in points)
            {
                float distance = ((Vector3)(v - center)).Length();

                if (distance > radius)
                    radius = distance;
            }

            return new BoundingSphere(center, radius);
        }

        public static BoundingSphere CreateMerged(BoundingSphere original, BoundingSphere additional)
        {
            BoundingSphere result;
            CreateMerged(ref original, ref additional, out result);
            return result;
        }

        public static void CreateMerged(ref BoundingSphere original, ref BoundingSphere additional, out BoundingSphere result)
        {
            float distance = Vector3.Distance(original.Center, additional.Center);
            if (distance + additional.Radius < original.Radius)
            {
                result = original;
                return;
            }

            distance = Vector3.Distance(additional.Center, original.Center);
            if (distance + original.Radius < additional.Radius)
            {
                result = additional;
                return;
            }

            Vector3 difference = Vector3.Subtract(additional.Center, original.Center);
            difference.Normalize();

            Vector3 additionalNew = additional.Center;
            additionalNew.X += additional.Radius * difference.X;
            additionalNew.Y += additional.Radius * difference.Y;
            additionalNew.Z += additional.Radius * difference.Z;

            Vector3 originalNew = original.Center;
            originalNew.X -= original.Radius * difference.X;
            originalNew.Y -= original.Radius * difference.Y;
            originalNew.Z -= original.Radius * difference.Z;

            difference = Vector3.Subtract(additionalNew, originalNew) / 2;

            result = new BoundingSphere(difference, difference.Length());
        }

        public override int GetHashCode()
        {
            return this.Radius.GetHashCode() + this.Center.GetHashCode();
        }

        public bool Intersects(BoundingBox box)
        {
            bool result;
            Intersects(ref box, out result);
            return result;
        }

        public void Intersects(ref BoundingBox box, out bool result)
        {
            if (Vector3.DistanceSquared(box.Max, this.Center) < this.Radius * this.Radius)
            {
                result = true;
                return;
            }
            if (Vector3.DistanceSquared(box.Min, this.Center) < this.Radius * this.Radius)
            {
                result = true;
                return;
            }
                
            result = false;
        }

        public bool Intersects(BoundingFrustum frustum)
        {
            Vector3[] points = frustum.GetCorners();
            float radiusSquared = this.Radius * this.Radius;
            
            for (int i = 0; i < BoundingFrustum.CornerCount; i++)
            {
                float distance = Vector3.DistanceSquared(points[i], this.Center);

                if (distance > radiusSquared)
                    continue;

                return true;
            }

            return false;
        }

        public bool Intersects(BoundingSphere sphere)
        {
            bool result;
            Intersects(ref sphere, out result);
            return result;
        }

        public void Intersects(ref BoundingSphere sphere, out bool result)
        {
            float distance = Vector3.Distance(this.Center, sphere.Center);
            float bothRadius = this.Radius + sphere.Radius;

            if (distance > bothRadius)
            {
                result = false;
                return;
            }

            result = true;
        }

        public PlaneIntersectionType Intersects(Plane plane)
        {
            PlaneIntersectionType result;
            Intersects(ref plane, out result);
            return result;
        }

        // Source: monoxna
        public void Intersects(ref Plane plane, out PlaneIntersectionType result)
        {
            float distance = Vector3.Dot(plane.Normal, this.Center) + plane.D;

            if (distance > this.Radius)
            {
                result = PlaneIntersectionType.Front;
                return;
            }
            if (distance < -this.Radius)
            {
                result = PlaneIntersectionType.Back;
                return;
            }

            result = PlaneIntersectionType.Intersecting;
        }

        public Nullable<float> Intersects(Ray ray)
        {
            Nullable<float> result;
            Intersects(ref ray, out result);
            return result;
        }

        // Method copied from and descriebed here: 
        // http://wiki.cgsociety.org/index.php/Ray_Sphere_Intersection
        public void Intersects(ref Ray ray, out Nullable<float> result)
        {
            //TODO: Find an other way, this one often is wrong!
            float a;
            Vector3.Dot(ref ray.Direction, ref ray.Direction, out a);

            float b;
            Vector3.Dot(ref ray.Direction, ref ray.Position, out b);
            b += b;

            float c;
            Vector3.Dot(ref ray.Position, ref ray.Position, out c);
            c -= Radius * Radius;

            //Find discriminant
            float disc = b * b - 4 * a * c;

            // if discriminant is negative there are no real roots, so return 
            // false as ray misses sphere
            if (disc < 0)
            {
                result = null;
                return;
            } 
            
            float distSqrt = (float)Math.Sqrt(disc);
            float q;
            if (b < 0)
                q = (-b - distSqrt) / 2.0f;
            else
                q = (-b + distSqrt) / 2.0f;

            // compute t0 and t1
            float t0 = q / a;
            float t1 = c / q;

            // make sure t0 is smaller than t1
            if (t0 > t1)
            {
                // if t0 is bigger than t1 swap them around
                float temp = t0;
                t0 = t1;
                t1 = temp;
            }

            // if t1 is less than zero, the object is in the ray's negative direction
            // and consequently the ray misses the sphere
            if (t1 < 0)
            {
                result = null;
                return;
            }

            // if t0 is less than zero, the intersection point is at t1
            if (t0 < 0)
            {
                result = t1;
                return;
            }
            // else the intersection point is at t0
            else
            {
                //if (float.IsNaN(t0))
                //    result = null;
                //else
                //    result = t0;

                result = t0;

                return;
            }
        }

        public BoundingSphere Transform(Matrix matrix)
        {
            BoundingSphere result;
            Transform(ref matrix, out result);
            return result;
        }

        public void Transform(ref Matrix matrix, out BoundingSphere result)
        {
            result = this;

            result.Radius += Math.Max(matrix.M11, Math.Max(matrix.M22, matrix.M33));
            result.Center.X += matrix.M41;
            result.Center.Y += matrix.M42;
            result.Center.Z += matrix.M43;
        }
                #endregion

        #region ToString
        public override string ToString()
        {
            var culture = CultureInfo.CurrentCulture;
            // This may look a bit more ugly, but String.Format should be avoided cause of it's bad performance!
            return "{Center:" + Center.ToString() + " Radius:" + Radius.ToString(culture) + "}";
        }
        #endregion

        #region IEquatable implementation
        public override bool Equals(Object obj)
        {
            return obj is BoundingSphere && Equals((BoundingSphere)obj);
        }
        public bool Equals(BoundingSphere other)
        {
            return this.Center.Equals(other.Center) && this.Radius == other.Radius;
        }
        #endregion

        #region operator overloading
        public static bool operator ==(BoundingSphere a, BoundingSphere b)
        {
            return (a.Center.X == b.Center.X &&
                a.Center.Y == b.Center.Y &&
                a.Center.Z == b.Center.Z &&
                a.Radius == b.Radius);
        }
        public static bool operator !=(BoundingSphere a, BoundingSphere b)
        {
            return (a.Center.X != b.Center.X ||
                a.Center.Y != b.Center.Y ||
                a.Center.Z != b.Center.Z ||
                a.Radius != b.Radius);
        }
        #endregion
    }
}
