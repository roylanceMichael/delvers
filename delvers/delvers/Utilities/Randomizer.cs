using System;
using System.Linq;

namespace delvers.Utilities
{
	public static class Randomizer
	{
		private static readonly Random Random = new Random();

		public static int GetRandomValue(int start, int end)
		{
			return Random.Next(start, end);
		}

		public static bool InheritsImplementsOrIs(this Type child, Type parent)
		{
			if (child == null || parent == null)
			{
				return false;
			}

			if (child == parent)
			{
				return true;
			}

			parent = ResolveGenericTypeDefinition(parent);

			var currentChild = child.IsGenericType
														 ? child.GetGenericTypeDefinition()
														 : child;

			while (currentChild != typeof(object))
			{
				if (parent == currentChild || HasAnyInterfaces(parent, currentChild))
					return true;

				currentChild = currentChild.BaseType != null
											 && currentChild.BaseType.IsGenericType
													 ? currentChild.BaseType.GetGenericTypeDefinition()
													 : currentChild.BaseType;

				if (currentChild == null)
					return false;
			}
			return false;
		}

		private static bool HasAnyInterfaces(Type parent, Type child)
		{
			return child.GetInterfaces()
					.Any(childInterface =>
					{
						var currentInterface = childInterface.IsGenericType
								? childInterface.GetGenericTypeDefinition()
								: childInterface;

						return currentInterface == parent;
					});
		}

		private static Type ResolveGenericTypeDefinition(Type parent)
		{
			bool shouldUseGenericType = !(parent.IsGenericType && parent.GetGenericTypeDefinition() != parent);

			if (parent.IsGenericType && shouldUseGenericType)
				parent = parent.GetGenericTypeDefinition();
			return parent;
		}
	}
}
