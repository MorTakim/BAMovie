﻿using ProjectTemplate.Core.IoC;
using ProjectTemplate.Core.IoC.Castle;

namespace ProjectTemplate.Application.Bootstrappers
{
    /// <summary>
    /// The bootstrapper
    /// </summary>
    public class Bootstrapper
    {
        /// <summary>
        /// Singleton bootstrapper instance
        /// </summary>
        public static readonly Bootstrapper Instance = new Bootstrapper();

        /// <summary>
        /// Initializes a new bootstrapper instance
        /// </summary>
        private Bootstrapper()
        {
            DependencyContainer.Init(new CastleDependencyContainer());
        }

        /// <summary>
        /// Bootstraps the given bootstrapper using DependencyContainer.Current
        /// </summary>
        /// <param name="bootstrapper"></param>
        /// <returns></returns>
        public Bootstrapper Bootstrap(IBootstrapper bootstrapper)
        {
            bootstrapper.Bootstrap(DependencyContainer.Current);
            return this;
        }

        /// <summary>
        /// Initializes the DependencyContainer at the application level.
        /// Calling this method invalidates any existing dependency configuration.
        /// This method should only be called for test purposes
        /// </summary>
        public Bootstrapper Reset()
        {
            DependencyContainer.Init(new CastleDependencyContainer());
            return this;
        }
    }
}

