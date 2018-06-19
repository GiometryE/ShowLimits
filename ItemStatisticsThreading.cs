using ColossalFramework.UI;
using ICities;
using UnityEngine;

namespace ItemStatistics
{
    public class ItemStatisticsThreading : ThreadingExtensionBase
    {
        private bool _processed = false;

        public override void OnUpdate(float realTimeDelta, float simulationTimeDelta)
        {
            if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Input.GetKey(KeyCode.I))
            {
                // cancel if they key input was already processed in a previous frame
                if (_processed) return;

                _processed = true;

                // compose message
                int treeCount = TreeManager.instance.m_treeCount;
                int maxTreeCount = TreeManager.MAX_TREE_COUNT;

                int buildingCount = BuildingManager.instance.m_buildingCount;
                int maxBuildingCount = BuildingManager.MAX_BUILDING_COUNT;

                string message = $"Trees: {treeCount} of {maxTreeCount}\nBuildings: {buildingCount} of {maxBuildingCount}";

                // display message
                ExceptionPanel panel = UIView.library.ShowModal<ExceptionPanel>("ExceptionPanel");
                panel.SetMessage("Item Statistics", message, false);
            }
            else
            {
                // not both keys pressed: Reset processed state
                _processed = false;
            }
        }
    }
}
