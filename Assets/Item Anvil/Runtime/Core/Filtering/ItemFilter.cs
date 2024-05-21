using System;

namespace rmMinusR.ItemAnvil
{

    [Serializable]
    public abstract class ItemFilter
    {
        public abstract bool Matches(ReadOnlyItemStack itemStack);

        public abstract ItemFilter Clone();
    }

}