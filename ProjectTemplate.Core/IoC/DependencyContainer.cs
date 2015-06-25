﻿using ProjectTemplate.Core.IoC;

namespace ProjectTemplate.Core.IoC
{
    /// <summary>
    /// A well-known class that other objects can use to find common services.
    /// </summary>
    public static class DependencyContainer
    {
        /// <summary>
        /// The current IDependencyContainer of the application.
        /// </summary>
        public static IDependencyContainer Current { get; private set; }

        /// <summary>
        /// Initializes the DependencyContainer at the application level.
        /// Calling this method invalidates any existing dependency configuration.
        /// </summary>
        /// <param name="container"></param>
        public static void Init(IDependencyContainer container)
        {
            Current = container;
        }
    }
}
