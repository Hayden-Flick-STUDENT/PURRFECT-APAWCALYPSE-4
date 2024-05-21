﻿using rmMinusR.ItemAnvil.UI;
using rmMinusR.Tooltips;
using TMPro;
using UnityEngine;

namespace rmMinusR.ItemAnvil.Tooltips
{

    public sealed class TooltipItemStackName : TooltipPart
    {
        [SerializeField] private GameObject root;
        [SerializeField] private TMP_Text text;

        private ViewInventorySlot dataSource;

        protected override void UpdateTarget(Tooltippable newTarget)
        {
            dataSource = newTarget.GetComponent<ViewInventorySlot>();
            root.SetActive(dataSource != null);

            //Render text if active
            if (root.activeSelf) text.text = dataSource.mostRecentStack.itemType.displayName;
        }
    }

}
