﻿using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Sprites;
using Xunit;

namespace MonoGame.Extended.Entities.Tests
{
    public class AspectBuilderTests
    {
        [Fact]
        public void MatchAllTypes()
        {
            var builder = new Aspect.Builder()
                .All(typeof(Transform2), typeof(Sprite));

            Assert.Equal(2, builder.AllTypes.Count);
            Assert.Contains(typeof(Transform2), builder.AllTypes);
            Assert.Contains(typeof(Sprite), builder.AllTypes);
        }

        [Fact]
        public void MatchAllTypesIsEmpty()
        {
            var builder = new Aspect.Builder()
                .All();

            Assert.Empty(builder.AllTypes);
            Assert.Empty(builder.OneTypes);
            Assert.Empty(builder.ExclusionTypes);
        }

        [Fact]
        public void MatchOneOfType()
        {
            var builder = new Aspect.Builder()
                .One(typeof(Transform2), typeof(Sprite));

            Assert.Equal(2, builder.OneTypes.Count);
            Assert.Contains(typeof(Transform2), builder.OneTypes);
            Assert.Contains(typeof(Sprite), builder.OneTypes);
        }
        
        [Fact]
        public void ExcludeTypes()
        {
            var builder = new Aspect.Builder()
                .Exclude(typeof(Transform2), typeof(Sprite));

            Assert.Equal(2, builder.ExclusionTypes.Count);
            Assert.Contains(typeof(Transform2), builder.ExclusionTypes);
            Assert.Contains(typeof(Sprite), builder.ExclusionTypes);
        }

        [Fact]
        public void BuildAspect()
        {
            var componentManager = new ComponentManager();
            var builder = new Aspect.Builder()
                .All(typeof(Transform2), typeof(Sprite))
                .One(typeof(string))
                .Exclude(typeof(Texture2D));

            var aspect = builder.Build(componentManager);

            Assert.NotEmpty(aspect.AllSet);
            Assert.NotEmpty(aspect.OneSet);
            Assert.NotEmpty(aspect.ExclusionSet);
        }
    }
}