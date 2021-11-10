﻿using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class CircleCollider : Collider
    {
        private float _collisionRadius;

        public float CollisionRadius
        {
            get { return _collisionRadius; }
            set { _collisionRadius = value; }
        }

        public CircleCollider(float collisionRadius, Actor owner) : base(owner, ColliderType.CIRCLE)
        {
            _collisionRadius = collisionRadius;
        }

        public override bool CheckCollisionCircle(CircleCollider other)
        {
            if (other.Owner == Owner)
                return false;

            //Find the distance between the two actors
            float distance = Vector3.Distance(other.Owner.LocalPosition, Owner.LocalPosition);
            //Find the length of the radii combined
            float combinedRadii = other.CollisionRadius + CollisionRadius;

            return distance <= combinedRadii;
        }

        public override bool CheckCollisionAABB(AABBCollider other)
        {
            //Retunr false if this collider is checking collision againts itself
            if (other.Owner == Owner)
                return false;

            //get the direction fromt this collider to teh aabb
            Vector3 direction = Owner.LocalPosition - other.Owner.LocalPosition;

            //Clamp the direction vector to be withn the bounds of the AABB
            direction.X = Math.Clamp(direction.X, -other.Width/2, other.Width/2);
            direction.Y = Math.Clamp(direction.Y, -other.Height/2, other.Height/2);

            //Add the direction vector to the AABB center to hget the closest point to the circle
            Vector3 closestPoint = other.Owner.LocalPosition + direction;

            //Find the distance from the circl'es center to the closest point 
            float distanceFromClosestPoint = Vector3.Distance(Owner.LocalPosition, closestPoint);

            //Return whether or not the distance is less than the circles radius
            return distanceFromClosestPoint <= CollisionRadius;
        }

        public override void Draw()
        {
            base.Draw();
            Raylib.DrawCircleLines((int)Owner.LocalPosition.X, (int)Owner.LocalPosition.Y, CollisionRadius, Color.GOLD);
        }
    }
}