using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    enum ColliderType 
    {
        CIRCLE,
        AABB
    }


    abstract class Collider
    {
        private Actor _owner;
        private ColliderType _colliderType;

        //Gets the type of collider that is being set
        public ColliderType ColliderType
        {
            get { return _colliderType; }
        }

        //Sets the owner of the collider
        public Actor Owner 
        { 
            get { return _owner; }
            set { _owner = value; }
        }

        //Constructor for Actor owner and the collidertype
        public Collider(Actor owner, ColliderType colliderType)
        {
            _owner = owner;
            _colliderType = colliderType;
        }

        //Checks for which type of collision has occured
        public bool CheckCollision(Actor other)
        {
            //if collidertype is circle...
            if (other.Collider.ColliderType == ColliderType.CIRCLE)
                //...return circle collider
                return CheckCollisionCircle((CircleCollider)other.Collider);
            //...else if collider type is AABB...
            else if (other.Collider.ColliderType == ColliderType.AABB)
                //..return AABB collider
                return CheckCollisionAABB((AABBCollider)other.Collider);

            return false;
        }

        //Checks for circle collision if no collision returns false
        public virtual bool CheckCollisionCircle(CircleCollider other) { return false; }

        //Checks for AABB collision if no collision returns false
        public virtual bool CheckCollisionAABB(AABBCollider other) { return false; }

        //Draws collider to scene
        public virtual void Draw()
        {

        }
    }
}
