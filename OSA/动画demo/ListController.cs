using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BDT
{
    public class ListController : MonoBehaviour
    {
        [Header("UI引用")] public MyScrollViewAdapter scrollView;
        public Button refreshButton;
        public Button addItemButton;
        public Button clearButton;

        [Header("测试数据")] public int initialItemCount = 50;

        private void Start()
        {
            SetupUI();
            scrollView.Init();
            GenerateTestData();
        }

        private void SetupUI()
        {
            if (refreshButton != null)
                refreshButton.onClick.AddListener(RefreshList);

            if (addItemButton != null)
                addItemButton.onClick.AddListener(AddRandomItem);

            if (clearButton != null)
                clearButton.onClick.AddListener(ClearList);
        }

        private void GenerateTestData()
        {
            var dataList = new List<ItemData>();

            Color[] colors = { Color.red, Color.green, Color.blue, Color.yellow, Color.cyan, Color.magenta };
            string[] titles = { "标题", "项目", "物品", "条目", "元素", "组件" };
            string[] descriptions = { "这是一个描述", "详细信息", "内容说明", "附加信息", "备注说明", "补充描述" };

            for (int i = 0; i < initialItemCount; i++)
            {
                var item = new ItemData(
                    i,
                    $"{titles[i % titles.Length]} {i + 1}",
                    $"{descriptions[i % descriptions.Length]} - 编号 {i + 1}",
                    colors[i % colors.Length]
                );
                dataList.Add(item);
            }

            scrollView.Parameters.dataList = dataList;
            scrollView.RefreshWithAnimation();
        }

        public void RefreshList()
        {
            scrollView.RefreshWithAnimation();
        }

        public void AddRandomItem()
        {
            var newItem = new ItemData(
                scrollView.Parameters.dataList.Count,
                $"新项目 {scrollView.Parameters.dataList.Count + 1}",
                $"这是新添加的项目 - 编号 {scrollView.Parameters.dataList.Count + 1}",
                Random.ColorHSV()
            );

            scrollView.AddItem(newItem);
        }

        public void ClearList()
        {
            scrollView.ClearAll();
        }

        // 在Inspector中调用的测试方法
        [ContextMenu("Test Different Animation Modes")]
        private void TestAnimationModes()
        {
            StartCoroutine(TestAnimationModesCoroutine());
        }

        private System.Collections.IEnumerator TestAnimationModesCoroutine()
        {
            var modes = System.Enum.GetValues(typeof(AnimationDelayController.DelayMode));

            foreach (AnimationDelayController.DelayMode mode in modes)
            {
                Debug.Log($"Testing animation mode: {mode}");
                scrollView.Parameters.animationDelayMode = mode;
                scrollView.RefreshWithAnimation();
                yield return new WaitForSeconds(2f);
            }
        }
    }
}