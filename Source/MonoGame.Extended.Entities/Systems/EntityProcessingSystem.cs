﻿using Microsoft.Xna.Framework;

namespace MonoGame.Extended.Entities.Systems
{
    public abstract class EntityProcessingSystem : EntityUpdateSystem
    {
        protected EntityProcessingSystem(Aspect.Builder aspectBuilder) 
            : base(aspectBuilder)
        {
        }

        public override void Update(GameTime gameTime)
        {
            Begin();

            foreach (var entityId in ActiveEntities)
                Process(entityId);

            End();
        }

        public virtual void Begin() { }
        public abstract void Process(int entityId);
        public virtual void End() { }
    }
}