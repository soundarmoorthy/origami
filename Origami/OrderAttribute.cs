using System;
namespace Origami
{
    public class OrderAttribute : Attribute
    {
        public readonly int Index;
        public readonly bool Include;
        public OrderAttribute(int index, bool include = true)
        {
            this.Index = index;
            this.Include = include;
        }
    }
}