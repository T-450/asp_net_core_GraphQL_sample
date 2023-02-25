namespace ConferencePlanner.GraphQL
{
    using System.Reflection;
    using HotChocolate.Types;
    using HotChocolate.Types.Descriptors;

    public class UseUpperCaseAttribute : ObjectFieldDescriptorAttribute
    {
        public override void OnConfigure(
            IDescriptorContext context,
            IObjectFieldDescriptor descriptor,
            MemberInfo member)
        {
            descriptor.UseUpperCase();
        }
    }
}
