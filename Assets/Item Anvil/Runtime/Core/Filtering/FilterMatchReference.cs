﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace rmMinusR.ItemAnvil
{

    [Serializable]
    public sealed class FilterMatchReference : ItemFilter
    {
        public bool matchType = true;
        public MatchMode matchQuantity = MatchMode.Ignore;
        public MatchMode matchInstanceProperties = MatchMode.Fuzzy;

        public ItemStack stack;

        public enum MatchMode
        {
            Ignore = 0,
            Fuzzy,
            Exact
        }

        public override bool Matches(ReadOnlyItemStack itemStack)
        {
            //Attempt to match type
            if (matchType && itemStack.itemType != stack.itemType) return false;

            //Attempt to match quantity
            switch (matchQuantity)
            {
                case MatchMode.Exact:
                    if (itemStack.quantity != stack.quantity) return false;
                    break;

                case MatchMode.Fuzzy:
                    if (itemStack.quantity < stack.quantity) return false;
                    break;

                case MatchMode.Ignore:
                    break;

                default: throw new NotImplementedException();
            }

            //Attempt to match instance properties
            if (matchInstanceProperties != MatchMode.Ignore)
            {
                HashSet<Type> ownTypes = new HashSet<Type>(stack.instanceProperties.Select(i => i.GetType()));
                HashSet<Type> otherTypes = new HashSet<Type>(itemStack.instanceProperties.Select(i => i.GetType()));
                switch (matchInstanceProperties)
                {
                    case MatchMode.Exact:
                        if (!ownTypes.SetEquals(otherTypes)) return false;
                        break;

                    case MatchMode.Fuzzy:
                        //Given stack contains all properties listed in example
                        if (!otherTypes.IsSupersetOf(ownTypes)) return false;
                        break;

                    default: throw new NotImplementedException();
                }
            }

            return true;
        }

        public override ItemFilter Clone()
        {
            return (ItemFilter)MemberwiseClone();
        }
    }

}